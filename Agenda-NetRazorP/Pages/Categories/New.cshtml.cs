using Agenda_NetRazorP.Data;
using Agenda_NetRazorP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda_NetRazorP.Pages.Categories
{
    public class NewModel : PageModel
    {
        private readonly Agenda_NetRazorDataContext _DataContext;

        public NewModel(Agenda_NetRazorDataContext dataContext)
        {
            _DataContext = dataContext;
        }

        [BindProperty]
        public Category category { get; set; }

        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _DataContext.Categories.AddAsync(category);
                await _DataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
