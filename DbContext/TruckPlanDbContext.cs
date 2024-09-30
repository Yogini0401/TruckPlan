using DFDSTruckPlan.Models;
using Microsoft.EntityFrameworkCore;

namespace DFDSTruckPlan.DbContext
{
    public class TruckPlanDbContext(DbContextOptions<TruckPlanDbContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
    {
        public DbSet<TruckPlan> TruckPlans { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<GPSPosition> GPSPositions { get; set; }
        public DbSet<GPSDevice> GPSDevices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationships
            modelBuilder.Entity<TruckPlan>()
        .HasOne(tp => tp.Driver)
        .WithMany()  // No navigation property on Driver side
        .HasForeignKey("DriverId");  // Explicit foreign key

            modelBuilder.Entity<TruckPlan>()
                .HasOne(tp => tp.Truck)
                .WithMany()  // No navigation property on Truck side
                .HasForeignKey("TruckId");  // Explicit foreign key

            // Relationships for Truck
            modelBuilder.Entity<Truck>()
                .HasOne(t => t.GPSDevice)
                .WithMany()  // No navigation property on GPSDevice side
                .HasForeignKey("GPSDeviceId");  // Explicit foreign key

            // Relationships for GPSDevice
            modelBuilder.Entity<GPSDevice>()
                .HasMany(gd => gd.GPSPositions)
                .WithOne()  // No navigation property on GPSPosition side
                .HasForeignKey("GPSDeviceId");  // Explicit foreign key

            base.OnModelCreating(modelBuilder);

            // Seed Driver data
            modelBuilder.Entity<Driver>().HasData(
                new Driver { Id = 1, Name = "John Doe", Birthdate = new DateTime(1970, 5, 15) },
                new Driver { Id = 2, Name = "Jane Smith", Birthdate = new DateTime(1985, 7, 20) }
            );

            // Seed Truck data
            modelBuilder.Entity<Truck>().HasData(
                new Truck { Id = 1, GPSDeviceId = 1 },
                new Truck { Id = 2, GPSDeviceId = 2 }
            );

            // Seed GPSDevice data
            modelBuilder.Entity<GPSDevice>().HasData(
                new GPSDevice { Id = 1 },
                new GPSDevice { Id = 2 }
            );

            // Seed GPSPosition data
            modelBuilder.Entity<GPSPosition>().HasData(
                new GPSPosition { Id = 1, Latitude = 52.5200, Longitude = 13.4050, TimeStamp = DateTime.Now, GPSDeviceId = 1 },
                new GPSPosition { Id = 2, Latitude = 48.8566, Longitude = 2.3522, TimeStamp = DateTime.Now, GPSDeviceId = 1 },
                new GPSPosition { Id = 3, Latitude = 51.5074, Longitude = -0.1278, TimeStamp = DateTime.Now, GPSDeviceId = 2 }
            );

            // Seed TruckPlan data
            modelBuilder.Entity<TruckPlan>().HasData(
                new TruckPlan { Id = 1, DriverId = 1, TruckId = 1, StartTime = DateTime.Now.AddHours(-5), EndTime = DateTime.Now },
                new TruckPlan { Id = 2, DriverId = 2, TruckId = 2, StartTime = DateTime.Now.AddHours(-6), EndTime = DateTime.Now }
            );
        }
    }
}
