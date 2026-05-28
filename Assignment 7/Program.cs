namespace Assignment_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product phone = new Product();

            //კონსტრუქტორით არ ჩავწერე და ჩამონათვალში დავწერე,
            //რადგან ბევრი ინფოა და დამაბნეველი იყო უსახელოდ ჩაწერა ყველაფრის

            phone.Id = 1015;
            phone.Name = "Iphone 15";
            phone.Description = "Black, 6.1-inch, 128GB";
            phone.Price = 1000;
            phone.Quantity = 10;
            phone.Brand = "Apple";
            phone.Category = "Smartphones";
            phone.Rating = 4.7;
            phone.IsAvailable = true;
            phone.DiscountPercent = 25;
            phone.NumberOfRatings = 15;


            #region method 1

            Console.WriteLine($"Original price is {phone.Price}. The discounted price is {phone.DiscountedPrice()}");

            #endregion


            #region method 2

            Console.WriteLine($"Quantity is {phone.Quantity}. How many would you like to add?");
            bool isValidAdded = int.TryParse(Console.ReadLine(), out int added);

            if (isValidAdded)
            {
                Console.WriteLine($"The total number after adding is {phone.AddProducts(added)}.");
            }

            #endregion


            #region method 3

            Console.WriteLine("Would you like to print phone information?\nEnter Yes or No");
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes")
            {
                phone.PrintInfo();
            }
            else if (answer == "no")
            {
                Console.WriteLine("Have a nice day!");
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }

            #endregion


            #region method 4

            Console.WriteLine("Would you like to add a new rating?\nEnter Yes or No");
            answer = Console.ReadLine().ToLower();
            if (answer == "yes")
            {
                bool isValidRating = double.TryParse(Console.ReadLine(), out double userRating);

                if (isValidRating)
                {
                    Console.WriteLine($"The new rating is: {phone.NewRating(userRating)}");
                }
            }
            else if (answer == "no")
            {
                Console.WriteLine("Have a nice day!");
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }

            #endregion
        }
    }
}
