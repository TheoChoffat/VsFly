using System;
using Microsoft.EntityFrameworkCore;

public class WWWContext:DbContext
{
	public WWWContext()
	{

	public virtual DbSet<Booking> BookingSet { get; set; }
	public virtual DbSet<Flight> FlightSet { get; set; }
	public virtual DbSet<Passenger> PassengerSet { get; set; }
	public virtual DbSet<Pilot> PilotSet { get; set; }
}
}
