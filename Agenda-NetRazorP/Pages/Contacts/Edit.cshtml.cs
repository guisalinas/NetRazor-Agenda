using Agenda_NetRazorP.Data;
using Agenda_NetRazorP.Models;
using Agenda_NetRazorP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda_NetRazorP.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly Agenda_NetRazorDataContext _DataContext;

        public EditModel(Agenda_NetRazorDataContext dataContext)
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
            var contactDB= await _DataContext.Contacts.FindAsync(contactVM.Contact.Id);

            contactDB.Name = contactVM.Contact.Name;
            contactDB.Email = contactVM.Contact.Email;
            contactDB.PhoneNumber = contactVM.Contact.PhoneNumber;
            contactDB.CategoryId = contactVM.Contact.CategoryId;
            contactDB.CreationDate = contactVM.Contact.CreationDate;

            await _DataContext.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
