using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CrudApi.Migrations {
    public partial class InitialCreate : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new {
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", nullable: true),
                    NomeMae = table.Column<string>(type: "varchar(80)", nullable: true),
                    NomePai = table.Column<string>(type: "varchar(80)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(14)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Colaborador", x => x.Cpf);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Colaborador");
        }
    }
}
