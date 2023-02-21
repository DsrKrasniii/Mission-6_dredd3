using Microsoft.EntityFrameworkCore;
using MoveEntryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_6_dredd3.Models
{
    public class DataBaseContext : DbContext
    {
        //Constructor
        public DataBaseContext (DbContextOptions<DataBaseContext> options) : base (options)
        {
            // blank
        }

        public DbSet<MovieEntry> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        // seed Category Data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );

            mb.Entity<MovieEntry>().HasData(
                new MovieEntry
                {
                    MovieID = 1,
                    CategoryId = 1,
                    Title = "The Patriot",
                    LentTo = "",
                    Year = 2000,
                    Director = "Roland Emmerich",
                    Rating = "R",
                    Edited = false,
                    Notes = ""
                },
                new MovieEntry
                {
                    MovieID = 2,
                    CategoryId = 4,
                    Title = "Finding Nemo",
                    LentTo = "",
                    Year = 2003,
                    Director = "Andrew Stanton",
                    Rating = "G",
                    Edited = false,
                    Notes = "Classic"
                },
                new MovieEntry
                {
                    MovieID = 3,
                    CategoryId = 5,
                    Title = "A Quiet Place",
                    LentTo = "Joe Johnson",
                    Year = 2018,
                    Director = "Roland Emmerich",
                    Rating = "PG-13",
                    Edited = true,
                    Notes = ""
                }
            ) ;
        }
    }
}
