using System.Threading;
using System.Threading.Tasks;
using EFSecondLevelCache.Core;
using EFSecondLevelCache.Core.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Janno.Data.User {

#pragma warning disable 108,114

  public class UserContext : IdentityDbContext<User> {

    public UserContext(DbContextOptions<UserContext> options)
      : base(options) {
    }

    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) {
      base.OnModelCreating(builder);

      RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) builder.Entity<User>(), "User");
      builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
      builder.Entity<IdentityRole>().ToTable("Roles");
    }

    public override int SaveChanges() {
      var changedEntityNames = this.GetChangedEntityNames();

      this.ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
      var result = base.SaveChanges();
      this.ChangeTracker.AutoDetectChangesEnabled = true;

      this.GetService<IEFCacheServiceProvider>().InvalidateCacheDependencies(changedEntityNames);

      return result;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {
      var changedEntityNames = this.GetChangedEntityNames();

      this.ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
      var result = base.SaveChangesAsync(cancellationToken);
      this.ChangeTracker.AutoDetectChangesEnabled = true;

      this.GetService<IEFCacheServiceProvider>().InvalidateCacheDependencies(changedEntityNames);

      return result;
    }

  }

}