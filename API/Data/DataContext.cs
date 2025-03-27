using API.Entidades;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<ListaCards> ListaCards { get; set; }
    }
}