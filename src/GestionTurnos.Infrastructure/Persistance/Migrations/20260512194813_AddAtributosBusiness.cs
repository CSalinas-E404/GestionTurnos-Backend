using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionTurnos.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddAtributosBusiness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Branches_BranchId",
                table: "Staffs");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "Staffs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId",
                table: "Staffs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "LinkPhoto",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_BusinessId",
                table: "Staffs",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Branches_BranchId",
                table: "Staffs",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Businesses_BusinessId",
                table: "Staffs",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Branches_BranchId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Businesses_BusinessId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_BusinessId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "LinkPhoto",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Staffs");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "Staffs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Branches_BranchId",
                table: "Staffs",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
