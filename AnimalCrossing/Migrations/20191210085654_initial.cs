using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalCrossing.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.SpeciesId);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    ProfilePicture = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    SpeciesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.CatId);
                    table.ForeignKey(
                        name: "FK_Cats_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "SpeciesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaReviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rating = table.Column<int>(nullable: false),
                    ReviewDate = table.Column<DateTime>(nullable: false),
                    ReviewingCatId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaReviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_CaReviews_Cats_ReviewingCatId",
                        column: x => x.ReviewingCatId,
                        principalTable: "Cats",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatDate",
                columns: table => new
                {
                    CatDateId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HostId = table.Column<int>(nullable: false),
                    GuestId = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatDate", x => x.CatDateId);
                    table.ForeignKey(
                        name: "FK_CatDate_Cats_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Cats",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatDate_Cats_HostId",
                        column: x => x.HostId,
                        principalTable: "Cats",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaReviews_ReviewingCatId",
                table: "CaReviews",
                column: "ReviewingCatId");

            migrationBuilder.CreateIndex(
                name: "IX_CatDate_GuestId",
                table: "CatDate",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_CatDate_HostId",
                table: "CatDate",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_Cats_SpeciesId",
                table: "Cats",
                column: "SpeciesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaReviews");

            migrationBuilder.DropTable(
                name: "CatDate");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
