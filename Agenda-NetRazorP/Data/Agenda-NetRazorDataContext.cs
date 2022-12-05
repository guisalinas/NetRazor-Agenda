using Agenda_NetRazorP.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Agenda_NetRazorP.Data
{
    public class Agenda_NetRazorDataContext : DbContext
    {
        public Agenda_NetRazorDataContext(DbContextOptions<Agenda_NetRazorDataContext> options) : base(options)
        {
            //
        }

        //Models:
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
