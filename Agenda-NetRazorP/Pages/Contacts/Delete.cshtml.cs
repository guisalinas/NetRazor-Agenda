using Agenda_NetRazorP.Data;
using Agenda_NetRazorP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda_NetRazorP.Pages.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly Agenda_NetRazorDataContext _DataContext;

        public DeleteModel(Agenda_NetRazorDataContext dataContext)
        {
            _DataContext = dataContext;
        }

        [BindProperty]
        public NewContactVM contactVM { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            contactVM = new NewContactVM()
            {
                CategoriesList = await _DataContext.Categories.ToListAsync(),
                Contact = await _DataContext.Contacts.FindAsync(id)
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var contactDB = await _DataContext.Contacts.FindAsync(contactVM.Contact.Id);
            if(contactDB == null)
            {
                return NotFound();
            }

            _DataContext.Contacts.Remove(contactDB);
            await _DataContext.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
