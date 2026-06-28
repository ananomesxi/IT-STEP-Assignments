using Assignment_16.Exceptions;
using Assignment_16.Helpers;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace Assignment_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> list = [1, 34, 23, 2832, 32, 345, -23, -353, 65, 234, 653, -1, -943, 2356, 43, 3, 235];

                // Where
                var num = Algorithms.Where<int>(list, x => x > 0);
                Console.Write("Elements that are greater than 0: ");
                foreach (int x in num)
                {
                    Console.Write($"{x} ");
                }
                Console.WriteLine();

                // OrderBy
                List<int> sorted = Algorithms.OrderBy<int>(list);
                Console.Write("Sorted list: ");
                foreach (int x in sorted)
                {
                    Console.Write($"{x} ");
                }
                Console.WriteLine();

                // First
                Console.WriteLine("First element: " + Algorithms.First(list));

                // FirstOrDefault
                Console.WriteLine("First element or default: " + Algorithms.FirstOrDefault(list));

                // Single
                Console.WriteLine("Single element greater than 20: " + Algorithms.Single(list, x => x > 20));

                // SingleOrDefault
                Console.WriteLine("Single element greater than 20 or default: " + Algorithms.SingleOrDefault(list, x => x > 20));

                // Any
                if (Algorithms.Any(list, x => x > 0))
                {
                    Console.WriteLine($"Element that is greater than 0 exists.");
                }
                else
                {
                    Console.WriteLine($"Element that is greater than 0 Does not exist.");
                }

                // All
                if (Algorithms.All(list, x => x > 0))
                {
                    Console.WriteLine("All elements are positive.");
                }
                else
                {
                    Console.WriteLine("Not all elements are positive");
                }

                // Count
                Console.WriteLine($"There are {Algorithms.Count(list, x => x > 50)} elements that are greater than 50.");

                // Distinct
                List<int> distincts = Algorithms.Distinct(list);
                Console.Write("Distinct elements: ");
                foreach (int x in distincts)
                {
                    Console.Write($"{x} ");
                }
                Console.WriteLine();
            }
            catch (ElementDoesntExist ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
