﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainServiceAPI.Data;

#nullable disable

namespace TrainServiceAPI.Migrations
{
    [DbContext(typeof(TrainServiceDBContext))]
    partial class TrainServiceDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrainModelsVehicleModels", b =>
                {
                    b.Property<int>("TrensId")
                        .HasColumnType("int");

                    b.Property<int>("VeiculosId")
                        .HasColumnType("int");

                    b.HasKey("TrensId", "VeiculosId");

                    b.HasIndex("VeiculosId");

                    b.ToTable("TrainModelsVehicleModels", (string)null);
                });

            modelBuilder.Entity("TrainServiceAPI.Models.TrainModels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHoraPartida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ferrovia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalDeDestino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalDeOrigem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroTrem")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Trens", (string)null);
                });

            modelBuilder.Entity("TrainServiceAPI.Models.VehicleModels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodVeiculo")
                        .HasColumnType("int");

                    b.Property<string>("TipoDeVeiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Veiculos", (string)null);
                });

            modelBuilder.Entity("TrainModelsVehicleModels", b =>
                {
                    b.HasOne("TrainServiceAPI.Models.TrainModels", null)
                        .WithMany()
                        .HasForeignKey("TrensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainServiceAPI.Models.VehicleModels", null)
                        .WithMany()
                        .HasForeignKey("VeiculosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
