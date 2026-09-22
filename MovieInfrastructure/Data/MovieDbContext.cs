using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using MovieDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieInfrastructure.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<StudioDetails> StudioDetails { get; set; }
        public DbSet<Country> Countries { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var _connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Studio)
                .WithMany(s => s.Movies)
                .HasForeignKey(m => m.StudioId);
            modelBuilder.Entity<Studio>()
                .HasOne(s => s.Country)
                .WithMany(c => c.Studios)
                .HasForeignKey(s => s.CountryId);
            modelBuilder.Entity<Studio>()
                .HasOne(s => s.StudioDetails)
                .WithOne(sd => sd.Studio)
                .HasForeignKey<StudioDetails>(sd => sd.StudioId);
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .UsingEntity(j => j.ToTable("MovieActors"));
            //data seeding
            modelBuilder.Entity<Country>()
                .HasData(
                    new Country { Id = 1, Name = "USA" },
                    new Country { Id = 2, Name = "UK" },
                    new Country { Id = 3, Name = "France" }
                );
        }
    }
}
