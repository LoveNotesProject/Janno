using System.Threading.Tasks;
using Janno.Data.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Janno.Pages.Dashboard {

  [Authorize(Roles = "User")]
  public class DashboardIndexModel : PageModel {

    private readonly UserManager UserManager;
    private readonly UserContext UserContext;

    [BindProperty]
    public User User { get; set; }

    [BindProperty]
    public int NotificationCount { get; set; }

    [BindProperty]
    public int ProfileLikesCount { get; set; }

    [BindProperty]
    public int ProfileVisitsCount { get; set; }

    public DashboardIndexModel(UserManager userManager, UserContext userContext) {
      this.UserManager = userManager;
      this.UserContext = userContext;
    }

    public async Task<IActionResult> OnGetAsync() {
      this.User = await this.UserManager.GetUserAsync(HttpContext.User);

      return Page();
    }

  }

}