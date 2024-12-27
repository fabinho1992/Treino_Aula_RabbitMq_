using E_Commerce_Shoes.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Shoes.Infraestrutura
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Compra> Compras { get; set; }
    }
}
