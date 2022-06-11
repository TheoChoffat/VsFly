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
        
            
            ctx.SaveChanges();
      

        }

    }
}

