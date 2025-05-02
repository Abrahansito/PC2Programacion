using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC2Programacion.Data.Migrations
{
    /// <inheritdoc />
    public partial class Pet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_Adopters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCompleto = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Contacto = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Adopters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Adoptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PetId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdopterId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdoptionDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Adoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_Adoptions_t_Adopters_AdopterId",
                        column: x => x.AdopterId,
                        principalTable: "t_Adopters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Edad = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EstadoAdopcion = table.Column<bool>(type: "INTEGER", nullable: false),
                    AdoptionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_Pets_t_Adoptions_AdoptionId",
                        column: x => x.AdoptionId,
                        principalTable: "t_Adoptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_Adoptions_AdopterId",
                table: "t_Adoptions",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Adoptions_PetId",
                table: "t_Adoptions",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Pets_AdoptionId",
                table: "t_Pets",
                column: "AdoptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_Adoptions_t_Pets_PetId",
                table: "t_Adoptions",
                column: "PetId",
                principalTable: "t_Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_Adoptions_t_Adopters_AdopterId",
                table: "t_Adoptions");

            migrationBuilder.DropForeignKey(
                name: "FK_t_Adoptions_t_Pets_PetId",
                table: "t_Adoptions");

            migrationBuilder.DropTable(
                name: "t_Adopters");

            migrationBuilder.DropTable(
                name: "t_Pets");

            migrationBuilder.DropTable(
                name: "t_Adoptions");
        }
    }
}
