using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelsApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<HotelReview> HotelReviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        modelBuilder.Entity<HotelReview>().HasData(
            new HotelReview
            {
                Id = 1,
                HotelName = "Grand Hotel Warszawa",
                Location = "Warszawa",
                Description = "Świetna lokalizacja, czyste pokoje",
                VisitDate = new DateTime(2023, 5, 15),
                Rating = 8.5f,
                ImageUrl = "https://www.ahstatic.com/photos/3384_ho_00_p_1024x768.jpg",
                UserName = "admin@example.com"
            },
            new HotelReview
            {
                Id = 2,
                HotelName = "Sea View Resort",
                Location = "Gdańsk",
                Description = "Piękny widok na morze",
                VisitDate = new DateTime(2023, 6, 10),
                Rating = 9.2f,
                ImageUrl = "https://nautilius-premium-best-sea-view-gdansk.booked.com.pl/data/Photos/OriginalPhoto/10891/1089139/1089139603/Nautilius-Premium-Best-Sea-View-Apartment-Gdansk-Exterior.JPEG",
                UserName = "guest@example.com"
            },
            new HotelReview
            {
                Id = 3, 
                HotelName = "Zabrze Asylum Silent Hill",
                Location = "Zabrze",
                Description = "Apartament full wypas",
                VisitDate = new DateTime(2011, 6, 10),
                Rating = 10.0f,
                ImageUrl = "https://d-art.ppstatic.pl/kadry/k/r/c5/e1/530497b9f389e_o_full.jpg",
                UserName = "norbi@paczkow.com"
            }
        );
    }
}