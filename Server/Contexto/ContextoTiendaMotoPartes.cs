using Basededatos.Shared.models;
using Microsoft.EntityFrameworkCore;

namespace Basededatos.Server.Contexto
{
    public class ContextoTiendaMotoPartes : DbContext
    {
        public ContextoTiendaMotoPartes(DbContextOptions<ContextoTiendaMotoPartes> options) : base(options) 
        {
            
        }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Ventas> ventas { get; set; } 
        public DbSet<Inventario> inventarios { get; set; }
    }
}
