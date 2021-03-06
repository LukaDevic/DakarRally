// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.LeaderboardEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Leaderboards");
                });

            modelBuilder.Entity("Domain.Entities.RaceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int>("RaceStatus")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Domain.Entities.VehicleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DistanceCoverdInKm")
                        .HasColumnType("int");

                    b.Property<int>("FinishedRaceInHours")
                        .HasColumnType("int");

                    b.Property<double>("HeavyMalfunctionChance")
                        .HasColumnType("float");

                    b.Property<bool>("HeavyMalfunctionOccured")
                        .HasColumnType("bit");

                    b.Property<int?>("LeaderboardEntityId")
                        .HasColumnType("int");

                    b.Property<double>("LightMalfunctionChance")
                        .HasColumnType("float");

                    b.Property<int>("LightMalfunctionsTimesOccured")
                        .HasColumnType("int");

                    b.Property<DateTime>("ManufacturingDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RaceEntityId")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("RepairmentTime")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleSubType")
                        .HasColumnType("int");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeaderboardEntityId");

                    b.HasIndex("RaceEntityId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Domain.Entities.VehicleEntity", b =>
                {
                    b.HasOne("Domain.Entities.LeaderboardEntity", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("LeaderboardEntityId");

                    b.HasOne("Domain.Entities.RaceEntity", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("RaceEntityId");
                });

            modelBuilder.Entity("Domain.Entities.LeaderboardEntity", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Domain.Entities.RaceEntity", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
