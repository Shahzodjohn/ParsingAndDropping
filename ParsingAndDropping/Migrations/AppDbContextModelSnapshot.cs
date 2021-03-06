// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParsingAndDropping.Context;

namespace ParsingAndDropping.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParsingAndDropping.Entities.Dropping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DATA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GTIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KLASYFIKACJAGPC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NAZWAPRODUKTU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("POBIERZ")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Droppings");
                });
#pragma warning restore 612, 618
        }
    }
}
