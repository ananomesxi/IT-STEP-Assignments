using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7
{
    public class Product
    {

        #region properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public double Rating { get; set; }
        public bool IsAvailable { get; set; }
        public double DiscountPercent { get; set; }
        public int NumberOfRatings { get; set; } 

        #endregion


        #region methods

        public double DiscountedPrice ()
        {
            return Price * (100 - DiscountPercent) / 100;
        }

        public int AddProducts (int added)
        {
            return Quantity + added;
        }

        public void PrintInfo ()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Rating: {Rating}");
            Console.WriteLine($"IsAvailable: {IsAvailable}");
            Console.WriteLine($"DiscountPercent: {DiscountPercent}");
        }

        public double NewRating (double newRating)
        {
            return (newRating + NumberOfRatings * Rating) / (NumberOfRatings + 1);
        }

        #endregion

    }
}
