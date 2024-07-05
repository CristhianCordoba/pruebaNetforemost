using Microsoft.EntityFrameworkCore;
using PruebaApi.Models;

namespace pruebaGestores.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<DeudoresModel> DeudoresModel { get; set; }
        public DbSet<ModeGestoresSaldos> GestoresSaldos { get; set; }
        public DbSet<ModeGestores> Gestores { get; set; }

    }
}