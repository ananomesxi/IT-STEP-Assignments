using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Assignment_10
{
    public enum Colors
    {
        Black,
        Brown,
        White,
        Gray,
        Golden,
        Silver
    }

    public enum Conditions 
    {
        New,
        Used,
        Refurbished
    }


    internal abstract class MusicalInstrument
    {
        private string _name;
        private double _weight;
        private int _yearOfManifacture;
        private string _sound;
        private string _history;

        protected MusicalInstrument(string name, double weight, int yearOfManifacture, string sound, Colors color, Conditions condition)
        {
            Name = name;
            Weight = weight;
            YearOfManifacture = yearOfManifacture;
            Sound = sound;
            Color = color;
            Condition = condition;
        }

        public string Name 
        { 
            get
            {
                return _name;
            }
            
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Something went wrong. Try again."); return;
                }
                else
                {
                    _name = value;
                }
            } 
        }

        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (!double.TryParse(value.ToString(), out _weight))
                {
                    Console.WriteLine("Something went wrong. Try again."); return;
                }
                else if (value <= 0)
                {
                    Console.WriteLine("Weight must be greater than 0."); return;
                }
                else
                {
                    _weight = value;
                }
            }
        }

        public int YearOfManifacture
        {
            get 
            { 
                return _yearOfManifacture; 
            }
            set 
            { 
                if (!int.TryParse(value.ToString(), out value))
                {
                    Console.WriteLine("Something went wrong. Try again."); return;
                }
                else if (value > DateTime.Now.Year)
                {
                    Console.WriteLine("The instrument couldn't have been manifactured in the future. Enter the real date.");
                }
                else
                {
                    _yearOfManifacture = value;
                }
            }
        }

        public string Sound
        {
            get
            {
                return _sound;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Something went wrong. Try again."); return;
                }
                else
                {
                    _sound = value;
                }
            }
        }

        public string History
        {
            get
            {
                return _history;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Something went wrong. Try again."); return;
                }
                else
                {
                    _history = value;
                }
            }
        }

        public Colors Color { get; set; }

        public Conditions Condition { get; set; }


        // ყველგან ერთნაირ მეთოდებს ვიყენებ, ამიტომ აბსტრაქტული არ გავხადე
        public virtual void DisplaySound()
        {
            Console.Write($"{Name} sounds like this: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{Sound} ");
            }
            Console.WriteLine();
        }

        public virtual void DisplayName()
        {
            Console.WriteLine($"The name of this instrument is {Name}\n");
        }
        public virtual void DisplayDesc()
        {
            Console.WriteLine($"Name: {Name}\nWeight {Weight}kg\nYear of mainfacture: {YearOfManifacture}\nColor: {Color}\nCondition: {Condition}\n");
        }
        public virtual void DisplayHistory ()
        {
            Console.WriteLine(History);
        }

        public void DoMethods ()
        {
            DisplayName();
            DisplaySound();
            DisplayDesc();
            DisplayHistory();
            Console.WriteLine();
        }

    }
}
