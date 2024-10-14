using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainServiceAPI.Models;

namespace TrainServiceAPI.Data.Map
{
    public class VehicleMap : IEntityTypeConfiguration<VehicleModels>
    {
        public void Configure(EntityTypeBuilder<VehicleModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TipoDeVeiculo).IsRequired();
            builder.Property(x => x.CodVeiculo).IsRequired();
            //builder.Property(x => x.Status).IsRequired();
        }
    }
}


