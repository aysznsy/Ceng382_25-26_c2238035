
using Week5Project.Data;
using Week5Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Week5Project.Pages.Classes
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolDbContext _context;

        public DetailsModel(SchoolDbContext context)
        {
            _context = context;
        }

        public Class Class { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Class = await _context.Classes.FirstOrDefaultAsync(m => m.Id == id);

            if (Class == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
