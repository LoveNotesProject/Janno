using System.Threading.Tasks;
using Janno.Data.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Janno.Pages.Profile.Setting {

  public class ProfileSettingIndex : PageModel {

    private UserContext UserContext;
    private UserManager UserManager;

    [BindProperty]
    public User User { get; set; }

    public ProfileSettingIndex(UserContext userContext, UserManager userManager) {
      this.UserContext = userContext;
      this.UserManager = userManager;
    }

    public async Task<IActionResult> OnGetAsync() {
      this.User = await this.UserManager.GetUserAsync(HttpContext.User);
      return Page();
    }

    public async Task<PartialViewResult> OnGetProfileSettingUniversalViewAsync() {
      this.User = await this.UserManager.GetUserAsync(HttpContext.User);
      this.ViewData["User"] = this.User;
      
      return new PartialViewResult {
        ViewName = "/Pages/Profile/Setting/Partial/ProfileSettingUniversalPartial.cshtml",
        ViewData = this.ViewData
      };
    }

    public async Task<PartialViewResult> OnGetProfileSettingInterestViewAsync() {
      this.User = await this.UserManager.GetUserAsync(HttpContext.User);
      this.ViewData["User"] = this.User;
      
      return new PartialViewResult {
        ViewName = "/Pages/Profile/Setting/Partial/ProfileSettingInterestPartial.cshtml",
        ViewData = this.ViewData
      };
    }

    public async Task<PartialViewResult> OnGetProfileSettingPictureViewAsync() {
      // ups, bei jeden get/post request muss der user neu geladen werden
      this.User = await this.UserManager.GetUserAsync(HttpContext.User);

      // hier ist der fehler
      // du sagst hier, bitte lade die ProfileSettingPicturePartial.cshtml Datei -> OKE, aber mit welchen Daten?
      // ViewDate is leer

      this.ViewData["User"] = this.User; // wir packen user in die viewdate rein

      return new PartialViewResult {
        ViewName = "/Pages/Profile/Setting/Partial/ProfileSettingPicturePartial.cshtml",
        ViewData = this.ViewData // leer :(
      };
    }

  }

}