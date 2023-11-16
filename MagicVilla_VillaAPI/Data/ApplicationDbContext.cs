using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "This is the first villa",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 400,
                    Sqft = 300,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa
                {
                    Id = 2,
                    Name = "Royal Pool Villa",
                    Details = "This is the second villa",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 400,
                    Sqft = 300,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa
                {
                    Id = 3,
                    Name = "Diamond Villa",
                    Details = "This is the third villa",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 400,
                    Sqft = 300,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa
                {
                    Id = 4,
                    Name = "Diamond Poll Villa",
                    Details = "This is the fourth villa",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 400,
                    Sqft = 300,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa
                {
                    Id = 5,
                    Name = "Luxury Villa",
                    Details = "This is the fifth villa",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 400,
                    Sqft = 300,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                }
                );
        }
    }
}
