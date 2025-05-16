using Week5Project.Data;
using Week5Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Week5Project.Pages.Classes
{
    public class IndexModel : PageModel
    {
        private readonly SchoolDbContext _context;

        public IndexModel(SchoolDbContext context)
        {
            _context = context;
        }

        public IList<Class> ClassList { get; set; } = new List<Class>();

        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }

        private const int PageSize = 10;

        public async Task OnGetAsync(int? currentPage)
        {
            CurrentPage = currentPage ?? 1;

            var query = _context.Classes
                .Where(c => !c.IsDeleted)
                .AsQueryable();

            int totalItems = await query.CountAsync();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            ClassList = await query
                .OrderBy(c => c.Id)
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }

        public List<object> GetPaginationPages()
        {
            var pages = new List<object>();

            if (TotalPages <= 7)
            {
                for (int i = 1; i <= TotalPages; i++) pages.Add(i);
            }
            else
            {
                pages.Add(1);
                if (CurrentPage > 4) pages.Add("...");
                for (int i = Math.Max(2, CurrentPage - 1); i <= Math.Min(TotalPages - 1, CurrentPage + 1); i++)
                    pages.Add(i);
                if (CurrentPage < TotalPages - 3) pages.Add("...");
                pages.Add(TotalPages);
            }

            return pages;
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}