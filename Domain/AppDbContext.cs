using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure StudentId as FK for StudentAddress
           /* modelBuilder.Entity<BookingDetail>()
                .HasOne(s => s.Booking)
                .WithOne(a => a.BookingDetail)
                .HasForeignKey<BookingDetail>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);*/

          

        }

    }
}
