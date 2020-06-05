using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientAPI.WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    DtCadastro = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 5, 0, 47, 6, 974, DateTimeKind.Local).AddTicks(6337)),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    CGC = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Logradouro = table.Column<string>(maxLength: 200, nullable: false),
                    Cep = table.Column<string>(maxLength: 8, nullable: false),
                    Numero = table.Column<string>(maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(maxLength: 30, nullable: false),
                    Cidade = table.Column<string>(maxLength: 30, nullable: false),
                    Estado = table.Column<string>(maxLength: 2, nullable: false),
                    Complemento = table.Column<string>(maxLength: 30, nullable: false),
                    Principal = table.Column<bool>(nullable: false, defaultValue: false),
                    Clienteid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Clientes_Clienteid",
                        column: x => x.Clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(maxLength: 9, nullable: false),
                    DDD = table.Column<string>(maxLength: 2, nullable: false),
                    Clienteid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Telefones_Clientes_Clienteid",
                        column: x => x.Clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_Clienteid",
                table: "Enderecos",
                column: "Clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_Clienteid",
                table: "Telefones",
                column: "Clienteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
