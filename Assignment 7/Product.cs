using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7
{
    public class Product
    {

        #region fields

        public int Id;
        public string Name;
        public string Description;
        public double Price;
        public int Quantity;
        public string Brand;
        public string Category;
        public double Rating;
        public bool IsAvailable;
        public double DiscountPercent;
        public int NumberOfRatings;

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
