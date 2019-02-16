﻿// <auto-generated />
using DN_DotNET_gram.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DN_DotNET_gram.Migrations
{
    [DbContext(typeof(DotNetgramDBContext))]
    partial class DotNetgramDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DN_DotNET_gram.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details");

                    b.Property<string>("Name");

                    b.Property<string>("URL");

                    b.HasKey("ID");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Details = "Squirrel's With Lightsabers",
                            Name = "Jason",
                            URL = "https://via.placeholder.com/150"
                        },
                        new
                        {
                            ID = 2,
                            Details = "Bob Ross",
                            Name = "Jason",
                            URL = "https://via.placeholder.com/150"
                        },
                        new
                        {
                            ID = 3,
                            Details = "Deathstar Sunrise",
                            Name = "Jason",
                            URL = "https://via.placeholder.com/150"
                        },
                        new
                        {
                            ID = 4,
                            Details = "Volcano",
                            Name = "Jason",
                            URL = "https://via.placeholder.com/150"
                        },
                        new
                        {
                            ID = 5,
                            Details = "Glacier",
                            Name = "Jason",
                            URL = "https://via.placeholder.com/150"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
