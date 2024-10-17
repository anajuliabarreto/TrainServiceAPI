using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainServiceAPI.Models;

namespace TrainServiceAPI.Data.Map
{
    public class TrainMap : IEntityTypeConfiguration<TrainModels>
    { 
        public void Configure(EntityTypeBuilder<TrainModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NumeroTrem).IsRequired(); 
            builder.Property(x => x.LocalDeDestino).IsRequired();
            builder.Property(x => x.LocalDeOrigem).IsRequired();
        }
    }
}

