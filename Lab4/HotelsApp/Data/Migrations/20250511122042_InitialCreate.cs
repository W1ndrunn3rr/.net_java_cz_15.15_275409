using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelsApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HotelName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    VisitDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Rating = table.Column<float>(type: "REAL", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelReviews", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "HotelReviews",
                columns: new[] { "Id", "Description", "HotelName", "ImageUrl", "Location", "Rating", "UserName", "VisitDate" },
                values: new object[,]
                {
                    { 1, "Świetna lokalizacja, czyste pokoje", "Grand Hotel Warszawa", "https://www.ahstatic.com/photos/3384_ho_00_p_1024x768.jpg", "Warszawa", 8.5f, "admin@example.com", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Piękny widok na morze", "Sea View Resort", "https://nautilius-premium-best-sea-view-gdansk.booked.com.pl/data/Photos/OriginalPhoto/10891/1089139/1089139603/Nautilius-Premium-Best-Sea-View-Apartment-Gdansk-Exterior.JPEG", "Gdańsk", 9.2f, "guest@example.com", new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Apartament full wypas", "Zabrze Asylum Silent Hill", "https://d-art.ppstatic.pl/kadry/k/r/c5/e1/530497b9f389e_o_full.jpg", "Zabrze", 10f, "norbi@paczkow.com", new DateTime(2011, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelReviews");
        }
    }
}
