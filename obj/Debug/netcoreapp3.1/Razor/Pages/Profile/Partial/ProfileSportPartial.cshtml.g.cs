#pragma checksum "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4be7d5d693ff56bdc21907c53e6a53bf81a1455"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Janno.Pages.Profile.Partial.Pages_Profile_Partial_ProfileSportPartial), @"mvc.1.0.view", @"/Pages/Profile/Partial/ProfileSportPartial.cshtml")]
namespace Janno.Pages.Profile.Partial
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\_ViewImports.cshtml"
using Janno;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
using Janno.Data.User;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4be7d5d693ff56bdc21907c53e6a53bf81a1455", @"/Pages/Profile/Partial/ProfileSportPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e90ed4b067f0df54d228f577bb4b587b357e3edc", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Profile_Partial_ProfileSportPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
  
  var user = (User) ViewData["User"];
  var userSport = await this.UserManager.GetUserSportAsync(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral("<div class=\"profile-interest-container\">\r\n  <div class=\"mdc-layout-grid__inner\">\r\n");
#nullable restore
#line 19 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Swim) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          pool
        </i>
        <h6 class=""mdc-typography--body1"">Schwimmen</h6>
      </div>
");
#nullable restore
#line 26 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Row) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          rowing
        </i>
        <h6 class=""mdc-typography--body1"">Rudern</h6>
      </div>
");
#nullable restore
#line 34 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Football) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          sports_football
        </i>
        <h6 class=""mdc-typography--body1"">Football</h6>
      </div>
");
#nullable restore
#line 42 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Soccerball) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          sports_soccer
        </i>
        <h6 class=""mdc-typography--body1"">Fußball</h6>
      </div>
");
#nullable restore
#line 50 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Volleyball) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          sports_volleyball
        </i>
        <h6 class=""mdc-typography--body1"">Volleyball</h6>
      </div>
");
#nullable restore
#line 58 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Basketball) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          sports_basketball
        </i>
        <h6 class=""mdc-typography--body1"">Basketball</h6>
      </div>
");
#nullable restore
#line 66 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Tennis) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          sports_tennis
        </i>
        <h6 class=""mdc-typography--body1"">Tennis</h6>
      </div>
");
#nullable restore
#line 74 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Baseball) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          sports_baseball
        </i>
        <h6 class=""mdc-typography--body1"">Baseball</h6>
      </div>
");
#nullable restore
#line 82 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Gym) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          fitness_center
        </i>
        <h6 class=""mdc-typography--body1"">Fitness</h6>
      </div>
");
#nullable restore
#line 90 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 91 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Hockey) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          sports_hockey
        </i>
        <h6 class=""mdc-typography--body1"">Hockey</h6>
      </div>
");
#nullable restore
#line 98 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 99 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Rugby) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          sports_rugby
        </i>
        <h6 class=""mdc-typography--body1"">Rugby</h6>
      </div>
");
#nullable restore
#line 106 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 107 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Golf) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          sports_golf
        </i>
        <h6 class=""mdc-typography--body1"">Golf</h6>
      </div>
");
#nullable restore
#line 114 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.MiniGolf) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          golf_course
        </i>
        <h6 class=""mdc-typography--body1"">Minigolf</h6>
      </div>
");
#nullable restore
#line 122 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Hike) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          landscape
        </i>
        <h6 class=""mdc-typography--body1"">Klettern/ Wandern</h6>
      </div>
");
#nullable restore
#line 130 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 131 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
     if (userSport.Bowling) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""mdc-layout-grid__cell--span-6 mdc-layout-grid__cell--span-4-tablet mdc-layout-grid__cell--span-2-phone"">
        <i class=""material-icons"">
          group_work
        </i>
        <h6 class=""mdc-typography--body1"">Bowling</h6>
      </div>
");
#nullable restore
#line 138 "C:\Users\Christoph Lotz\RiderProjects\janno\Pages\Profile\Partial\ProfileSportPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("  </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591