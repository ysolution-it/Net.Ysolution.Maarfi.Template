using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net.Ysolution.Maarfi.Template.Infrastructure.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "com_modules",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    changer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    changed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("com_modules_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "com_roles",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    arabic_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    english_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    changer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    changed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("com_roles_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "com_users",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    changer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    changed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("com_users_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "com_user_roles",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    changer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    changed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("com_user_roles_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_com_user_roles_com_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "dbo",
                        principalTable: "com_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_com_user_roles_com_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "com_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_com_user_roles_role_id",
                schema: "dbo",
                table: "com_user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_com_user_roles_user_id",
                schema: "dbo",
                table: "com_user_roles",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "com_modules",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "com_user_roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "com_roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "com_users",
                schema: "dbo");
        }
    }
}
