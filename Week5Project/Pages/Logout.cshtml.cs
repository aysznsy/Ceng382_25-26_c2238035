using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Week5Project.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
         
            HttpContext.Session.Clear();

            Response.Cookies.Delete("AuthToken");
            Response.Cookies.Delete("Username");
            Response.Cookies.Delete("SessionId");

            
            return RedirectToPage("/Login");
        }
    }
}
