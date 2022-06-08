using System;
using System.Linq;

namespace VSFly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var ctx = new WWWContext();

            var e = ctx.Database.EnsureCreated();
            Console.WriteLine(e);
            Pilot pilot1 = new Pilot()
            {
                Surname = "Emilie Teodoro",
                Salary = 10000
            };
            ctx.Pilot.Add(pilot1);
            ctx.SaveChanges();

            Pilot p = ctx.Pilot.Where(p => p.Surname == "Emilie Teodoro").FirstOrDefault();

            Flight f1 = new Flight()
            {
                Seats = 100,
                Departure = "PAY",
                Destination = "LAX",
                Date = new DateTime(2022, 08, 12),
                PilotId = 1,
                SeatsAvailable = 20,
                pilot = p,
                Price = 200

            };

            ctx.Flight.Add(f1);

            ctx.SaveChanges();

            Console.WriteLine("======================");

            Console.WriteLine(f1.Departure);
            Console.WriteLine(f1.Destination);
            Console.WriteLine(f1.FlightNo);

            Console.WriteLine("======================");

            foreach (Flight flight in ctx.Flight)
            {
                Console.WriteLine("Date: {0} Destination: {1} Seats: {2}", flight.Date, flight.Destination, flight.Seats);
            }

            Passenger passenger3 = new Passenger { Surname = "Papilloud", Firstname = "Doriane" };

            Passenger passenger4 = new Passenger { Surname = "Solliard", Firstname = "Mégane" };

            ctx.Passenger.Add(passenger3);

            ctx.Passenger.Add(passenger4);

            ctx.SaveChanges();

           

            Booking book3 = new Booking { Flight = ctx.Flight.Find(1), Passenger = passenger3 };

            Booking book4 = new Booking { Flight = ctx.Flight.Find(1), Passenger = passenger4 };


            ctx.Booking.Add(book3);

            ctx.Booking.Add(book4);

            ctx.SaveChanges();

            Console.WriteLine("======================");
            Console.WriteLine(book3.FlightNo + " " + passenger4.Firstname);


        }

    }
}

