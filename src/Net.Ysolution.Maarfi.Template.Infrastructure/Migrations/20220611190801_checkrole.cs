using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net.Ysolution.Maarfi.Template.Infrastructure.Migrations
{
    public partial class checkrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "id",
                schema: "dbo",
                table: "com_user_roles");

            migrationBuilder.DropIndex(
                name: "IX_com_user_roles_user_id",
                schema: "dbo",
                table: "com_user_roles");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "dbo",
                table: "com_user_roles");

            migrationBuilder.AlterColumn<Guid>(
                name: "creator",
                schema: "dbo",
                table: "com_users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "changer",
                schema: "dbo",
                table: "com_users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role_id",
                schema: "dbo",
                table: "com_users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "creator",
                schema: "dbo",
                table: "com_user_roles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "changer",
                schema: "dbo",
                table: "com_user_roles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "creator",
                schema: "dbo",
                table: "com_roles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "changer",
                schema: "dbo",
                table: "com_roles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "creator",
                schema: "dbo",
                table: "com_modules",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "changer",
                schema: "dbo",
                table: "com_modules",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_user_roles",
                schema: "dbo",
                table: "com_user_roles",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.CreateIndex(
                name: "IX_com_users_role_id",
                schema: "dbo",
                table: "com_users",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_com_users_com_roles_role_id",
                schema: "dbo",
                table: "com_users",
                column: "role_id",
                principalSchema: "dbo",
                principalTable: "com_roles",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_com_users_com_roles_role_id",
                schema: "dbo",
                table: "com_users");

            migrationBuilder.DropIndex(
                name: "IX_com_users_role_id",
                schema: "dbo",
                table: "com_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_user_roles",
                schema: "dbo",
                table: "com_user_roles");

            migrationBuilder.DropColumn(
                name: "role_id",
                schema: "dbo",
                table: "com_users");

            migrationBuilder.AlterColumn<string>(
                name: "creator",
                schema: "dbo",
                table: "com_users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "changer",
                schema: "dbo",
                table: "com_users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "creator",
                schema: "dbo",
                table: "com_user_roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "changer",
                schema: "dbo",
                table: "com_user_roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "dbo",
                table: "com_user_roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "creator",
                schema: "dbo",
                table: "com_roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "changer",
                schema: "dbo",
                table: "com_roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "creator",
                schema: "dbo",
                table: "com_modules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "changer",
                schema: "dbo",
                table: "com_modules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "id",
                schema: "dbo",
                table: "com_user_roles",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_com_user_roles_user_id",
                schema: "dbo",
                table: "com_user_roles",
                column: "user_id");
        }
    }
}
