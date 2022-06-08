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

            Passenger passenger1 = new Passenger { Surname = "Vouillamoz", Firstname = "Hugo" };

            Passenger passenger2 = new Passenger { Surname = "Morel", Firstname = "Benjamin" };

            ctx.Passenger.Add(passenger1);

            ctx.Passenger.Add(passenger2);

            ctx.SaveChanges();

            Console.WriteLine("======================");
            Console.WriteLine(passenger1.Surname + " " + passenger1.Firstname);


            Booking book1 = new Booking { Flight = ctx.Flight.Find(1), Passenger = passenger1 };

            Booking book2 = new Booking { Flight = ctx.Flight.Find(1), Passenger = passenger2 };


            ctx.Booking.Add(book1);

            ctx.Booking.Add(book2);

            ctx.SaveChanges();

            Console.WriteLine("======================");
            Console.WriteLine(book1.FlightNo + " " + passenger1.Firstname);


        }

    }
}

