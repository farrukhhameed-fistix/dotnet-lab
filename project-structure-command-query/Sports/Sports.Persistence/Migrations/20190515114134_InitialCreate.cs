using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sports.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AthleteTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TestId = table.Column<Guid>(nullable: false),
                    AthleteId = table.Column<Guid>(nullable: false),
                    Distance = table.Column<decimal>(nullable: false),
                    FitnessRating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteTests", x => x.Id);
                    table.UniqueConstraint("AK_AthleteTests_AthleteId", x => x.AthleteId);
                    table.ForeignKey(
                        name: "FK_AthleteTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Athletes_AthleteTests_Id",
                        column: x => x.Id,
                        principalTable: "AthleteTests",
                        principalColumn: "AthleteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AthleteTests_TestId",
                table: "AthleteTests",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.DropTable(
                name: "AthleteTests");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
