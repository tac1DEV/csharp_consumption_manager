using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consommation.Migrations
{
    /// <inheritdoc />
    public partial class Ajoutdestablesdemonprojet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DistanceTot = table.Column<int>(type: "int", nullable: false),
                    DistanceCumul = table.Column<int>(type: "int", nullable: false),
                    ChargeBatterie = table.Column<int>(type: "int", nullable: false),
                    Autonomie = table.Column<int>(type: "int", nullable: false),
                    Reset = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Recharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Durée = table.Column<int>(type: "int", nullable: false),
                    KwChargé = table.Column<int>(type: "int", nullable: false),
                    PrixKwh = table.Column<int>(type: "int", nullable: false),
                    PuChargéKwH = table.Column<int>(type: "int", nullable: false),
                    Coût = table.Column<int>(type: "int", nullable: false),
                    RatioBatterie = table.Column<int>(type: "int", nullable: false),
                    CommentaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recharges_Commentaires_CommentaireId",
                        column: x => x.CommentaireId,
                        principalTable: "Commentaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Trajets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Action = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destination = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VitesseMoy = table.Column<int>(type: "int", nullable: false),
                    ConsoMoy100 = table.Column<int>(type: "int", nullable: false),
                    ConsoCumul = table.Column<int>(type: "int", nullable: false),
                    EnergieRecup = table.Column<int>(type: "int", nullable: true),
                    ConsoClim = table.Column<int>(type: "int", nullable: true),
                    CommentaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trajets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trajets_Commentaires_CommentaireId",
                        column: x => x.CommentaireId,
                        principalTable: "Commentaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Recharges_CommentaireId",
                table: "Recharges",
                column: "CommentaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Trajets_CommentaireId",
                table: "Trajets",
                column: "CommentaireId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recharges");

            migrationBuilder.DropTable(
                name: "Trajets");

            migrationBuilder.DropTable(
                name: "Voitures");

            migrationBuilder.DropTable(
                name: "Commentaires");
        }
    }
}
