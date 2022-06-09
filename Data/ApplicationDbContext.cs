using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieProApp.Models.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MovieProApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=MovieProApp; User Id=postgres; Password=myViktory@99");
            }
        }*/

        //actual table
        public DbSet<Collection> Collection { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieCollection> MovieCollection { get; set; }
    }
}
