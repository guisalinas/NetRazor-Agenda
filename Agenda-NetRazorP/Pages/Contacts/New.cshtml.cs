using Agenda_NetRazorP.Data;
using Agenda_NetRazorP.Models;
using Agenda_NetRazorP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Agenda_NetRazorP.Pages.Contacts
{
    public class NewModel : PageModel
    {
        private readonly Agenda_NetRazorDataContext _DataContext;

        public NewModel(Agenda_NetRazorDataContext dataContext)
        {
            _DataContext = dataContext;
        }

        [BindProperty]
        public NewContactVM contactVM { get; set; }

        public async Task<IActionResult> OnGet()
        {
            contactVM = new NewContactVM()
            {
                CategoriesList = await _DataContext.Categories.ToListAsync(),
                Contact = new Contact()
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            //contactVM.CategoriesList = await _DataContext.Categories.ToListAsync();
            await _DataContext.Contacts.AddAsync(contactVM.Contact);
            await _DataContext.SaveChangesAsync();
            return RedirectToPage("Index");
        }
        
    }
}
