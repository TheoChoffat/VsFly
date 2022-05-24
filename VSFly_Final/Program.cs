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
            ctx.PilotSet.Add(pilot1);
            ctx.SaveChanges();

            Pilot p = ctx.PilotSet.Where(p => p.Surname == "Emilie Teodoro").FirstOrDefault();

            Flight f1 = new Flight()
            {
                Seats = 100,
                Departure = "PAY",
                Destination = "LAX",
                Date = new DateTime(2022, 08, 12),
                PilotId = 1,
                FreeSeats = 20,
                pilot = p

            };

            ctx.FlightSet.Add(f1);

            ctx.SaveChanges();

            Console.WriteLine("======================");

            Console.WriteLine(f1.Departure);
            Console.WriteLine(f1.Destination);
            Console.WriteLine(f1.FlightNo);

            Console.WriteLine("======================");

            foreach (Flight flight in ctx.FlightSet)
            {
                Console.WriteLine("Date: {0} Destination: {1} Seats: {2}", flight.Date, flight.Destination, flight.Seats);
            }

            Passenger passenger1 = new Passenger { Surname = "Vouillamoz", Firstname = "Hugo" };

            Passenger passenger2 = new Passenger { Surname = "Morel", Firstname = "Benjamin" };

            ctx.PassengerSet.Add(passenger1);

            ctx.PassengerSet.Add(passenger2);

            ctx.SaveChanges();

            Console.WriteLine("======================");
            Console.WriteLine(passenger1.Surname + " " + passenger1.Firstname);


            Booking book1 = new Booking { Flight = ctx.FlightSet.Find(1), Passenger = passenger1 };

            Booking book2 = new Booking { Flight = ctx.FlightSet.Find(1), Passenger = passenger2 };


            ctx.BookingSet.Add(book1);

            ctx.BookingSet.Add(book2);

            ctx.SaveChanges();

            Console.WriteLine("======================");
            Console.WriteLine(book1.FlightNo + " " + passenger1.Firstname);


        }

    }
}

