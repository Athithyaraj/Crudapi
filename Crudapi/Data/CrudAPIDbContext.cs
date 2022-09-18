using Crudapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Crudapi.Data
{
    public class CrudAPIDbContext: DbContext
    {
        public CrudAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
