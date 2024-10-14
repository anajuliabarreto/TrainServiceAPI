using Microsoft.EntityFrameworkCore;
using TrainServiceAPI.Models;
using TrainServiceAPI.Data.Map;

namespace TrainServiceAPI.Data
{
    public class TrainServiceDBContext : DbContext
    {
        public TrainServiceDBContext(DbContextOptions<TrainServiceDBContext> options)
            : base(options)
        {
        }

        public DbSet<TrainModels> Trens { get; set; }
        public DbSet<VehicleModels> Veiculos { get; set; }
        public DbSet<TrainComposition> TremVeiculo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrainMap());
            modelBuilder.ApplyConfiguration(new VehicleMap());

            modelBuilder.Entity<TrainComposition>()
            .HasKey(tc => new { tc.TremId, tc.VeiculoId }); //Chave primária composta

            modelBuilder.Entity<TrainComposition>()
                .HasOne(tc => tc.Trens)
                .WithMany(t => t.TremVeiculo)
                .HasForeignKey(ct => ct.TremId);

            modelBuilder.Entity<TrainComposition>()
                .HasOne(tc => tc.Veiculos)
                .WithMany(v => v.TremVeiculo)
                .HasForeignKey(tc => tc.VeiculoId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
