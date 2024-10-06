using Invantory.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Invantory.Data
{
    public class InvantoryContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        //public DbSet<Location> Locations { get; set; }
        //public DbSet<Place> Places { get; set; }
        //public DbSet<Section> Sections { get; set; }

        public InvantoryContext(DbContextOptions<InvantoryContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    //Fluent Api 
        //    //One-To-Many 
        //    //Cascade Ilgili oldugu FK Silinirse her seyi siler

        //    modelBuilder.Entity<Item>()
        //        .HasOne(i => i.Place)
        //        .WithMany(p => p.Items)
        //        .HasForeignKey(i => i.PlaceId)
        //        .OnDelete(DeleteBehavior.Cascade);


        //    modelBuilder.Entity<Place>()
        //       .HasOne(p => p.Section)
        //       .WithMany(s => s.Places)
        //       .HasForeignKey(p => p.SectionId)
        //       .OnDelete(DeleteBehavior.Cascade);


        //    modelBuilder.Entity<Section>()
        //       .HasOne(s => s.Location)
        //       .WithMany(l => l.Sections)
        //       .HasForeignKey(s => s.LocationId)
        //       .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
