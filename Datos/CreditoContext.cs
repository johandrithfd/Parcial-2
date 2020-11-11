using Microsoft.EntityFrameworkCore;
using Entidad;

namespace Datos
{
    public class CreditoContext : DbContext
    {
        public CreditoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Credito> Creditos { get; set; }
        public DbSet<Abono> Abonos { get; set; }

        protected override void  OnModelCreating(ModelBuilder constructoDeModelo)
        {
            constructoDeModelo.Entity<Abono>()
                    .HasOne<Credito>()
                    .WithMany()
                    .HasForeignKey(A => A.CreditoId);
        }
    }
}