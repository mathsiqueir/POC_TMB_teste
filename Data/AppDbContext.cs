using Microsoft.EntityFrameworkCore;
using POC_TMB.Models;

namespace POC_TMB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<OrderModel> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar a entidade primeiro
            modelBuilder.Entity<OrderModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Cliente).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Produto).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Valor).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Status).IsRequired().HasMaxLength(20);
                entity.Property(e => e.DataCriacao).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // CORREÇÃO: Use uma data fixa para HasData
            modelBuilder.Entity<OrderModel>().HasData(
                new OrderModel
                {
                    Id = Guid.Parse("8a7b6f5c-0e3d-4c1b-9d7a-1b2c3d4e5f6a"),
                    Cliente = "Matheus Siqueira",
                    Produto = "Teste Tmb",
                    Valor = 1000,
                    Status = "Pendente",
                    DataCriacao = new DateTime(2024, 1, 1, 10, 0, 0, DateTimeKind.Utc)
                },
                new OrderModel
                {
                    Id = Guid.Parse("f4a3e2d1-c0b9-4a8e-9d6c-5b4a3c2d1e0f"),
                    Cliente = "Julia Gomyde",
                    Produto = "Teste Tmb",
                    Valor = 1500,
                    Status = "Concluido",
                    DataCriacao = new DateTime(2024, 1, 2, 14, 30, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}