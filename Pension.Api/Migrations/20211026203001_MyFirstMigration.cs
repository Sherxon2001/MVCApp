using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pension.Api.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "database",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brithday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PINFLNumber = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mahalla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForTwoYears = table.Column<bool>(type: "bit", nullable: false),
                    ForFourteenYears = table.Column<bool>(type: "bit", nullable: false),
                    Support = table.Column<bool>(type: "bit", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfficialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialDisignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialSignatrue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_database", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "database");
        }
    }
}
