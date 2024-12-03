﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consommation.Migrations
{
    /// <inheritdoc />
    public partial class ChangeChampCommentairepourrecharge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recharges_Commentaires_CommentaireId",
                table: "Recharges");

            migrationBuilder.AlterColumn<int>(
                name: "CommentaireId",
                table: "Recharges",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Recharges_Commentaires_CommentaireId",
                table: "Recharges",
                column: "CommentaireId",
                principalTable: "Commentaires",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recharges_Commentaires_CommentaireId",
                table: "Recharges");

            migrationBuilder.AlterColumn<int>(
                name: "CommentaireId",
                table: "Recharges",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recharges_Commentaires_CommentaireId",
                table: "Recharges",
                column: "CommentaireId",
                principalTable: "Commentaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
