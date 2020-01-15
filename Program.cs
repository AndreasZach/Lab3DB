using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DB
{

    class Program
    {
        static void Main(string[] args)
        {
            var dbComms = new DBCommunication();
            var businessRepo = new BusinessRepository();

            dbComms.InsertBusinesses(businessRepo.businesses);

            // Calls the method required to complete the first assignment
            dbComms.PrintAll();
            Console.ReadKey(true);
            Console.Clear();

            // Calls the method required to complete the second assignment
            dbComms.PrintCafes();
            Console.ReadKey(true);
            Console.Clear();

            // Calls the method required to complete the third assignment
            dbComms.UpdateXYZCoffeeBar();
            Console.ReadKey(true);
            Console.Clear();

            // Calls the method required to complete the fourth assignment
            dbComms.Update456CookiesShop();
            Console.ReadKey(true);
            Console.Clear();

            // Calls the method required to complete the fifth assignment
            dbComms.PrintGreaterThan4Stars();
            Console.ReadKey(true);
        }
    }
}
