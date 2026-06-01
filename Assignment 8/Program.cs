using System.Runtime.CompilerServices;

namespace Assignment_8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = @"../../../CarsData.txt";

            MakeCarsList.LoadCarsData(path, out Cars[] car);

            Console.WriteLine("Pick a car of your interest (enter 1-5).");


            bool isValid = byte.TryParse(Console.ReadLine(), out byte userChoice);

            if (isValid && userChoice > 0 && userChoice <6)
            {
                int index = userChoice - 1;

                #region DisplayInfo

                Console.WriteLine($"Would you like to see information of car {userChoice}? enter yes or no.");

                string answer = Console.ReadLine().ToLower();

                if (answer == "yes")
                {
                    car[index].DisplayInfo();
                }
                else if (answer != "no")
                {
                    Console.WriteLine("Something went wrong!");
                }

                #endregion

                #region Discount

                Console.WriteLine("Enter discount rate: ");
                bool isValidDisc = decimal.TryParse(Console.ReadLine(), out decimal discount);

                if (isValidDisc && discount > 0 && discount < 100)
                {
                    Console.WriteLine($"Discounted price is {car[index].DiscountedPrice(discount)}");
                }
                else
                {
                    Console.WriteLine("Something went wrong!");
                }

                #endregion

                #region NewerThan

                Console.WriteLine("Enter the year: ");
                bool isValidYear = byte.TryParse(Console.ReadLine(), out byte userInputYear);
                if (isValidYear)
                {
                    if (car[index].NewerThan(userInputYear))
                    {
                        Console.WriteLine($"The car is newer than {userInputYear}!");
                    }
                    else
                    {
                        Console.WriteLine($"The car is not newer than {userInputYear}!");
                    }
                }
                else
                {
                    Console.WriteLine("Something went wrong!");
                }

                #endregion

                #region ChangeColor

                Console.WriteLine("Enter a new color for your car: ");
                car[index].ChangeColor(Console.ReadLine());

                #endregion

                #region MoreExpensiveThan

                Console.WriteLine("Enter a price: ");
                bool isValidPrice = decimal.TryParse(Console.ReadLine(),out decimal priceCompare);

                if (isValidPrice)
                {
                    if (car[index].MoreExpensiveThan(priceCompare))
                    {
                        Console.WriteLine($"The car is more expensive than {priceCompare}");
                    }
                    else
                    {
                        Console.WriteLine($"The car is not more expensive than {priceCompare}");
                    }
                }
                else
                {
                    Console.WriteLine("Something went wrong!");
                }

                #endregion
            }

        }
    }
}
