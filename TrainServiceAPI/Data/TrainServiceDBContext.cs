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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrainMap());
            modelBuilder.ApplyConfiguration(new VehicleMap());
        }

    }
}
