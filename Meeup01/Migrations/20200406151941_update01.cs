using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meeup01.Migrations
{
    public partial class update01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suspects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    MobileNo = table.Column<string>(maxLength: 15, nullable: false),
                    CitizenId = table.Column<string>(maxLength: 13, nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Nationality = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suspects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suspects_CitizenId",
                table: "Suspects",
                column: "CitizenId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suspects");
        }
    }
}
