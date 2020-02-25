using System;
using CacheManager.Core;
using EFSecondLevelCache.Core;
using Janno.Data.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Janno {

  public class Startup {

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.AddDbContext<UserContext>(options =>
        options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

      #region Cache

      services.AddEFSecondLevelCache();

      services.AddSingleton(typeof(ICacheManager<>), typeof(BaseCacheManager<>));
      services.AddSingleton(typeof(ICacheManagerConfiguration),
        new CacheManager.Core.ConfigurationBuilder()
          .WithJsonSerializer()
          .WithMicrosoftMemoryCacheHandle("MemoryCache1")
          .WithExpiration(ExpirationMode.Sliding, TimeSpan.FromMinutes(15))
          .DisableStatistics()
          .DisablePerformanceCounters()
          .Build());

      services.AddResponseCaching();

      #endregion Cache      

      #region Identity + Cookie

      // Identity
      services.AddIdentity<User, IdentityRole>(options => options.Stores.MaxLengthForKeys = 128)
        .AddUserStore<UserStore>()
        .AddUserManager<UserManager>()
        .AddEntityFrameworkStores<UserContext>()
        .AddDefaultTokenProviders();

      services.Configure<IdentityOptions>(options => {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;

        // User settings
        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
      });

      services.ConfigureApplicationCookie(options => {
        options.Cookie.Name = "janno";
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // SSL
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.MaxAge = TimeSpan.FromHours(10);

        options.LoginPath = new PathString("/Login");
        options.LogoutPath = new PathString("/Logout");
        options.AccessDeniedPath = new PathString("/Dashboard");
        options.ExpireTimeSpan = TimeSpan.FromHours(12);
        options.SlidingExpiration = true;

        // Not creating a new object since ASP.NET Identity has created
        // one already and hooked to the OnValidatePrincipal event.
        // See https://github.com/aspnet/AspNetCore/blob/5a64688d8e192cacffda9440e8725c1ed41a30cf/src/Identity/src/Identity/IdentityServiceCollectionExtensions.cs#L56
//        options.Events.OnRedirectToLogin = context => {
//          context.Response.StatusCode = StatusCodes.Status401Unauthorized;
//          return Task.CompletedTask;
//        };
      });

      services.Configure<CookiePolicyOptions>(options => {
        options.CheckConsentNeeded = context => false; // true = random session id
        options.MinimumSameSitePolicy = SameSiteMode.Strict;
      });

      services.AddTransient<IUserStore, UserStore>();

      #endregion Identity + Cookie

      // Session
      services.AddSession(options => { options.Cookie.Name = "janno"; });

      // Misc
      services.AddAntiforgery(options => { options.HeaderName = "XSRF-TOKEN"; }); // https://www.talkingdotnet.com/handle-ajax-requests-in-asp-net-core-razor-pages/

      // Authorization
      services.AddAuthorization(options => {
        options.AddPolicy("RequireUserRole",
          policy => policy.RequireRole("User"));
      });

      // Page
//      services.AddRazorPages();
      services.AddRazorPages().AddRazorPagesOptions(options => {
        options.Conventions.AuthorizeFolder("/Dashboard", "RequireUserRole");
      });

      services.AddControllersWithViews().AddRazorRuntimeCompilation();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      } else {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseResponseCaching();
      app.UseRouting();

      app.UseCookiePolicy();
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseSession();

      app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
    }

  }

}