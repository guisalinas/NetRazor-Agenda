using Agenda_NetRazorP.Data;
using Agenda_NetRazorP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda_NetRazorP.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly Agenda_NetRazorDataContext _DataContext;

        public EditModel(Agenda_NetRazorDataContext dataContext)
        {
            _DataContext = dataContext;
        }

        [BindProperty]
        public Category category { get; set; }
        public async void OnGet(int Id)
        {
            category = await _DataContext.Categories.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            var categoryDB = await _DataContext.Categories.FindAsync(category.Id);
            categoryDB.Name = category.Name;
            categoryDB.CreationDate = category.CreationDate;

            await _DataContext.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
