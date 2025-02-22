using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaTecnica.Logica.Models;

namespace PruebaTecnica.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Busqueda> Busquedas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                options.UseNpgsql(connectionString); // 🔹 Cambia a PostgreSQL
            }
        }
    }
}
