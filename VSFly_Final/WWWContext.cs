using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace VSFly
{
	public class WWWContext : DbContext
	{
		public WWWContext() { }


		public virtual DbSet<Booking> Booking { get; set; }
		public virtual DbSet<Flight> Flight { get; set; }
		public virtual DbSet<Passenger> Passenger { get; set; }
		public virtual DbSet<Pilot> Pilot { get; set; }

		public static string ConnectionString { get; set; } = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\VSFly_Final\VSFly_final.mdf;" +
												  "Trusted_Connection=True;App=EFCoreApp2021;MultipleActiveResultSets=true";

		//public static string ConnectionString { get; set; } = @"Server=(localDB)\MSSQLLocalDB;Database=VSFly_DB;" +
		//										  "Trusted_Connection=True;App=VSFly;MultipleActiveResultSets=true";

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

	
