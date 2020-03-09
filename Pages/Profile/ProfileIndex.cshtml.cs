using System;
using System.IO;
using System.Threading.Tasks;
using Janno.Data.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace Janno.Pages.Profile {

  public class ProfileIndexModel : PageModel {

    private UserContext UserContext;
    private UserManager UserManager;

    [BindProperty]
    public User User { get; set; }

    public ProfileIndexModel(UserContext userContext, UserManager userManager) {
      this.UserContext = userContext;
      this.UserManager = userManager;
    }

    public async Task<IActionResult> OnGetAsync() {
      this.User = await this.UserManager.GetUserAsync(HttpContext.User);
      return Page();
    }
    
    public async Task<PartialViewResult> OnGetProfileInterestViewAsync() {
      this.User = await this.UserManager.GetUserAsync(HttpContext.User);
      Console.WriteLine("this user id : " + this.User.Id);
      this.ViewData["User"] = this.User;
      return new PartialViewResult {
        ViewName = "/Pages/Profile/Partial/ProfileInterestPartial.cshtml",
        ViewData = this.ViewData
      };
    }
    
    public async Task<PartialViewResult> OnGetProfileSettingInterestViewAsync() {
      this.User = await this.UserManager.GetUserAsync(HttpContext.User);
      Console.WriteLine("this user id : " + this.User.Id);
      this.ViewData["User"] = this.User;
      return new PartialViewResult {
        ViewName = "/Pages/Profile/Setting/Partial/ProfileSettingInterestPartial.cshtml",
        ViewData = this.ViewData
      };
    }

    public async Task<PartialViewResult> OnGetProfileSportViewAsync() {
      this.User = await this.UserManager.GetUserAsync(HttpContext.User);
      this.ViewData["User"] = this.User;
      return new PartialViewResult {
        ViewName = "/Pages/Profile/Partial/ProfileSportPartial.cshtml",
        ViewData = this.ViewData
      };
    }
    
    

  }

}