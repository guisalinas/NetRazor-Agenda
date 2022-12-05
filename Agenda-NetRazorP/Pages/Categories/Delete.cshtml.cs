using Agenda_NetRazorP.Data;
using Agenda_NetRazorP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda_NetRazorP.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly Agenda_NetRazorDataContext _DataContext;

        public DeleteModel(Agenda_NetRazorDataContext dataContext)
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
            if (categoryDB == null)
            {
                return NotFound();
            }
            _DataContext.Categories.Remove(categoryDB);
            await _DataContext.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
