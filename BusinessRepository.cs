using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DB
{
    class BusinessRepository
    {
        public List<Business> businesses = new List<Business>();

        /// <summary>
        /// Creates a collection of "Business" objects when an instance of this class is created.
        /// </summary>
        public BusinessRepository()
        {
            businesses.Add
            (
                new Business
                (
                     "5c39f9b5df831369c19b6bca",
                     "Sun Bakery Trattoria",
                     4,
                     new List<string> { "Pizza", "Pasta", "Italian", "Coffee", "Sandwiches" }
                )
            );
            businesses.Add
            (
                new Business
                (
                    "5c39f9b5df831369c19b6bcb",
                    "Blue Bagels Grill",
                     3,
                     new List<string> { "Bagels", "Cookies", "Sandwiches"}
                )
            );
            businesses.Add
            (
                new Business(
                    "5c39f9b5df831369c19b6bcc",
                    "Hot Bakery Cafe",
                    4,
                    new List<string> { "Bakery", "Cafe", "Coffee", "Dessert"}
                 )
            );
            businesses.Add
            (
                new Business(
                    "5c39f9b5df831369c19b6bcd",
                    "XYZ Coffee Bar",
                    5,
                    new List<string> { "Coffee", "Cafe", "Bakery", "Chocolates" }
                )
            );
            businesses.Add
            (
                new Business
                (
                     "5c39f9b5df831369c19b6bce",
                     "456 Cookies Shop",
                     4,
                     new List<string> { "Bakery", "Cookies", "Cake", "Coffee" }
                )
            );
        }
    }
}
