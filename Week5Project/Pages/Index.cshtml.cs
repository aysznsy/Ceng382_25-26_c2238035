using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Week5Project.Models;

namespace Week5Project.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ClassInformationModel NewClass { get; set; } = new();

         public List<ClassInformationModel> ClassList { get; set; } = new();
         

        public int? EditId { get; set; }

        public static List<ClassInformationModel> StaticClassList { get; set; } = new();

        public void OnGet()
        {
            ClassList = StaticClassList;
        }

        public IActionResult OnPostAdd()
        {
            if (!ModelState.IsValid)
            {
                ClassList = StaticClassList;
                return Page();
            }

            StaticClassList.Add(NewClass);
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var item = StaticClassList.FirstOrDefault(x => x.Id == id);
            if (item != null)
                StaticClassList.Remove(item);

            return RedirectToPage();
        }

        public IActionResult OnPostEdit(int id)
        {
            var classToEdit = StaticClassList.FirstOrDefault(c => c.Id == id);
            if (classToEdit != null)
            {
                NewClass = new ClassInformationModel
                {
                    Id = classToEdit.Id,
                    ClassName = classToEdit.ClassName,
                    StudentCount = classToEdit.StudentCount,
                    Description = classToEdit.Description
                };
                EditId = id;
            }

            ClassList = StaticClassList;
            return Page();
        }

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                ClassList = StaticClassList;
                return Page();
            }

            var existing = StaticClassList.FirstOrDefault(x => x.Id == NewClass.Id);
            if (existing != null)
            {
                existing.ClassName = NewClass.ClassName;
                existing.StudentCount = NewClass.StudentCount;
                existing.Description = NewClass.Description;
            }

            return RedirectToPage();
        }
    }
}
