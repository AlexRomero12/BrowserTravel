using BrowserTravel.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrowserTravel
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
    }
}
