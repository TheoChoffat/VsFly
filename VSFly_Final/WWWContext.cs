using System;
using Microsoft.EntityFrameworkCore;

namespace VSFly
{
	public class WWWContext : DbContext
	{
		public WWWContext() { }


	public virtual DbSet<Booking> BookingSet { get; set; }
		public virtual DbSet<Flight> FlightSet { get; set; }
		public virtual DbSet<Passenger> PassengerSet { get; set; }
		public virtual DbSet<Pilot> PilotSet { get; set; }

		public static string ConnectionString { get; set; } = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\VSFly\test2.mdf;" +
												  "Trusted_Connection=True;App=EFCoreApp2021;MultipleActiveResultSets=true";

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
			builder.UseSqlServer(ConnectionString);
        }

		protected override void OnModelCreating(ModelBuilder builder)
        {
			builder.Entity<Booking>().HasKey(x => new { x.FlightNo, x.PassengerId });

        }
	}
}

	
