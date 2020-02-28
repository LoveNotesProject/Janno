using System.IO;
using System.Threading.Tasks;
using Janno.Data.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace Janno.Pages.Search {

  public class SearchIndexModel : PageModel {

    private readonly UserManager UserManager;
    private readonly UserContext UserContext;

    [BindProperty]
    public User User { get; set; }


    public SearchIndexModel(UserManager userManager, UserContext userContext) {
      this.UserManager = userManager;
      this.UserContext = userContext;
    }


    public async Task<IActionResult> OnGetAsync() {
      this.User = await this.UserManager.GetUserAsync(HttpContext.User);

      return Page();
    }

    public async Task<JsonResult> OnPostSearchSinglePerson() {
      this.User = await this.UserManager.GetUserAsync(HttpContext.User);

      var stream = new MemoryStream();
      await Request.Body.CopyToAsync(stream);
      stream.Position = 0;
      using (var reader = new StreamReader(stream)) {
        var requestBody = await reader.ReadToEndAsync();
        if (requestBody.Length > 0) {
          var json = JObject.Parse(requestBody);
          if (!json.ContainsKey("gender")) {
            return new JsonResult(new {
              message = "Ein Unbekannter Fehler ist aufgetreten",
              success = false
            });
          }

          if (!json.ContainsKey("distance")) {
            return new JsonResult(new {
              message = "Ein Unbekannter Fehler ist aufgetreten",
              success = false
            });
          }

          if (!json.ContainsKey("minimumAge")) {
            return new JsonResult(new {
              message = "Ein Unbekannter Fehler ist aufgetreten",
              success = false
            });
          }

          if (!json.ContainsKey("maximumAge")) {
            return new JsonResult(new {
              message = "Ein Unbekannter Fehler ist aufgetreten",
              success = false
            });
          }


          return new JsonResult(new {
            message = "Bild erfolgreich hochgeladen",
            success = true
          });
        }
      }

      return new JsonResult(new {
        message = "Ein Unbekannter Fehler ist aufgetreten.",
        success = false
      });
    }

    public async Task<JsonResult> OnPostSearchGroup() {
      return new JsonResult(new {
        message = "Ein Unbekannter Fehler ist aufgetreten.",
        success = false
      });
    }

  }

}