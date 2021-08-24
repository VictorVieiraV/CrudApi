using CrudApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace CrudApi.Migrations {
    [DbContext(typeof(CrudApiContext))]
    partial class CrudApiContextModelSnapshot : ModelSnapshot {
        protected override void BuildModel(ModelBuilder modelBuilder) {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrudApi.Models.Colaborador", b => {
                b.Property<string>("Cpf")
                    .HasColumnType("varchar(11)");

                b.Property<DateTime>("DataNascimento")
                    .HasColumnType("date");

                b.Property<string>("Email")
                    .HasColumnType("varchar(80)");

                b.Property<string>("Nome")
                    .HasColumnType("varchar(80)");

                b.Property<string>("NomeMae")
                    .HasColumnType("varchar(80)");

                b.Property<string>("NomePai")
                    .HasColumnType("varchar(255)");

                b.Property<string>("Telefone")
                    .HasColumnType("varchar(14)");

                b.HasKey("Cpf");

                b.ToTable("Colaborador");
            });
#pragma warning restore 612, 618
        }
    }
}
