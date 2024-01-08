using EstudoWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudoWeb.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { 
           
        }
        public DbSet<ContactsModel> contacts { get; set; }
    }
}
