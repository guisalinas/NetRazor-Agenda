using Agenda_NetRazorP.Data;
using Agenda_NetRazorP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda_NetRazorP.Pages.Categories
{
    public class DetailModel : PageModel
    {
        private readonly Agenda_NetRazorDataContext _DataContext;

        public DetailModel(Agenda_NetRazorDataContext dataContext)
        {
            _DataContext = dataContext;
        }

        [BindProperty]
        public Category category { get; set; }

        public async void OnGet(int Id)
        {
            category = await _DataContext.Categories.FindAsync(Id);
        }
    }
}
