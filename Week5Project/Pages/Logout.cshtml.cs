using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Week5Project.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Clear session
            HttpContext.Session.Clear();

            // Delete login-related cookies
            Response.Cookies.Delete("AuthToken");
            Response.Cookies.Delete("Username");
            Response.Cookies.Delete("SessionId");

            // Redirect to login
            return RedirectToPage("/Login");
        }
    }
}
