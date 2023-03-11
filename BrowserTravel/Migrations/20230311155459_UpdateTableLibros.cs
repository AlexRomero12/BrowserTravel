// <copyright file="20230311155459_UpdateTableLibros.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Migrations;

namespace BrowserTravel.Migrations
{
    public partial class UpdateTableLibros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Editoriales_EditorialIDId",
                table: "Libros");

            migrationBuilder.RenameColumn(
                name: "EditorialIDId",
                table: "Libros",
                newName: "EditorialId");

            migrationBuilder.RenameIndex(
                name: "IX_Libros_EditorialIDId",
                table: "Libros",
                newName: "IX_Libros_EditorialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Editoriales_EditorialId",
                table: "Libros",
                column: "EditorialId",
                principalTable: "Editoriales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Editoriales_EditorialId",
                table: "Libros");

            migrationBuilder.RenameColumn(
                name: "EditorialId",
                table: "Libros",
                newName: "EditorialIDId");

            migrationBuilder.RenameIndex(
                name: "IX_Libros_EditorialId",
                table: "Libros",
                newName: "IX_Libros_EditorialIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Editoriales_EditorialIDId",
                table: "Libros",
                column: "EditorialIDId",
                principalTable: "Editoriales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
