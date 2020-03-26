using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationAPIService.Migrations
{
    public partial class InitailDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLevels",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLevelCode = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    UserLevelName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMatrices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLevel = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    FunctionCode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMatrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "varchar(10)", nullable: false),
                    UserLevel = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    NameTH = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NameEN = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Department = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Hash = table.Column<string>(type: "text", nullable: true),
                    Salt = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(nullable: false),
                    IPAddress = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastUsage = table.Column<DateTime>(nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: true),
                    LastLogout = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLevels");

            migrationBuilder.DropTable(
                name: "UserMatrices");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
