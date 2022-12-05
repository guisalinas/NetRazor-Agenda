using Agenda_NetRazorP.Data;
using Agenda_NetRazorP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda_NetRazorP.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly Agenda_NetRazorDataContext _DataContext;

        public IndexModel(Agenda_NetRazorDataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public IEnumerable<Contact> contacts { get; set; }

        public async Task OnGet()
        {
            contacts = await _DataContext.Contacts.Include(c => c.Category).ToListAsync();

        }
    }
}
