using System.Threading.Tasks;
using Janno.Data.User;
using Janno.Data.User.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Janno.Pages {
  
  [AllowAnonymous]
  public class LoginIndexModel : PageModel {

    private readonly SignInManager<User> _SignInManager;

    [BindProperty]
    public UserLoginInput UserLoginInput { get; set; }


    public LoginIndexModel(SignInManager<User> signInManager) {
      this._SignInManager = signInManager;
    }

    public LocalRedirectResult OnGetAsync() {
      return !HttpContext.User.Identity.IsAuthenticated ? null : LocalRedirect("/Dashboard");
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null) {
      if (!ModelState.IsValid) return Page();

      returnUrl ??= Url.Content("~/Dashboard");
      var result = await _SignInManager.PasswordSignInAsync(UserLoginInput.UserName, UserLoginInput.Password, UserLoginInput.RememberMe, true);

      if (result.Succeeded) {
        if (Url.IsLocalUrl(returnUrl)) {
          return Redirect(returnUrl);
        }

        return LocalRedirect("/Dashboard");
      }

      ModelState.AddModelError(string.Empty, "Benutzername oder Passwort ist falsch.");

      return Page();
    }

  }
}