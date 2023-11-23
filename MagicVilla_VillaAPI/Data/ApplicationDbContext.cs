using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<Villa> Villas { get; set; }

        //For seeding Dataif empty
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "The path is simply the set of properties used to traverse the object's structure, separated by dots. Here's a live example:",
                    Occupancy = 5,
                    SqFt = 500,
                    ImageUrl = "",
                    Amenity = "Wifi, Pool, AC",
                    Rate = 600,
                    CreatedDate = DateTime.Now,
                },
                 new Villa()
                 {
                     Id = 2,
                     Name = "Hilton Conclave Villa",
                     Details = "The path is simply the set of properties used to traverse the object's structure, separated by dots. Here's a live example:",
                     Occupancy = 10,
                     SqFt = 1500,
                     ImageUrl = "",
                     Amenity = "Wifi, Pool, AC",
                     Rate = 600,
                     CreatedDate = DateTime.Now,
                 },
                  new Villa()
                  {
                      Id = 3,
                      Name = "Taj Villa",
                      Details = "The path is simply the set of properties used to traverse the object's structure, separated by dots. Here's a live example:",
                      Occupancy = 4,
                      SqFt = 9000,
                      ImageUrl = "",
                      Amenity = "Wifi, Pool, AC",
                      Rate = 600,
                      CreatedDate = DateTime.Now,
                  }
                );
        }
    }
}
