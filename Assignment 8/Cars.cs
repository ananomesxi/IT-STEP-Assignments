using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Assignment_8
{
    internal class Cars
    {

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != null && value != "")
                {
                    _name = value;
                }
            }
        }


        private string _model;
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (value != null && value != "")
                {
                    _model = value;
                }
            }
        }


        private int _year;
        public int Year 
        { 
            get
            {
                return _year;
            }
            set 
            { 
               if (value >=1884 && value <= DateTime.Now.Year+1)
                {
                    _year = value;
                }
            }
        }


        private decimal _price;
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
            }
        }


        private string _color;
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (value != null && value != "")
                {
                    _color = value;
                }
            }
        }


        public void DisplayInfo ()
        {
            Console.WriteLine($"Name: {Name}, Model: {Model}, Year: {Year}, Price: ${Price}, Color: {Color}.");
        }

        public decimal DiscountedPrice ( decimal discount)
        {
            return Price - Price * discount / 100;
        }

        public bool NewerThan (int userInputYear)
        {
            if (Year > userInputYear) return true;
            else return false;
        }

        public void ChangeColor(string newColor)
        {
            Color = newColor;
        }
        public bool MoreExpensiveThan (decimal userInputPrice)
        {
            if (userInputPrice < Price) return true;
            else return false;
        }

    }
}
