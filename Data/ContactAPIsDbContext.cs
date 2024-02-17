using Microsoft.EntityFrameworkCore;
using WEBAPI.Models;

namespace WEBAPI.Data
{
    public class ContactAPIsDbContext: DbContext
    {
        public ContactAPIsDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Contacts> Contacts { get; set; }
    }
}
