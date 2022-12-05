using Agenda_NetRazorP.Data;
using Agenda_NetRazorP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda_NetRazorP.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Agenda_NetRazorDataContext _DataContext;

        public IndexModel(Agenda_NetRazorDataContext dataContext)
        {
            _DataContext = dataContext;
        }
        
        public IEnumerable<Category> Categories { get; set; }

        public async Task OnGet()
        {
            Categories = await _DataContext.Categories.ToListAsync();

        }
    }
}
