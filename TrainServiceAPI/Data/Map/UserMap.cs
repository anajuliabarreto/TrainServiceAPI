using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainServiceAPI.Models;

namespace TrainServiceAPI.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModels>
    {
        public void Configure (EntityTypeBuilder<UserModels> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeUsuario).IsRequired();
            builder.Property(x => x.SenhaUsuario).IsRequired();
        }
    }
}
