using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_11
{
    internal class Array : IOutput2, ICalc2
    {
		private int[] _numbers;

        public Array(int[] numbers)
        {
            Numbers = numbers;
        }

        public int[] Numbers
        {
            get
            {
                return _numbers;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Something went wrong.");
                }
                else
                {
                    _numbers = value;
                }
            }
        }



        public int CountDistinct()
        {
            int count = 0;
            // ყველა რიცხვისთვის (თუ ამ რიცხვამდე არ გვხვდება მისი ტოლი რიცხვი) count-ს ვზრდით 1-ით
            for (int i = 0; i < Numbers.Length; i++)  
            {
                if (!Detected(i)) count++; 
            }
            return count; 
        }

        // ცალკე მეთოდი რომელიც ნახულობს მანამდე შეგვხვდა თუ არა ეს რიცხვი
        public bool Detected(int i)
        {
            for (int j = 0; j < i; j++)
            {
                if (Numbers[i] == Numbers[j]) { return true; }
            }
            return false;
        }

        public int EqualToValue(int valueToCompare)
        {
            int count = 0;
            foreach (int num in Numbers)
            {
                if (num == valueToCompare) count++;
            }
            return count;
        }

        public void ShowEven()
        {
            foreach (int num in Numbers)
			{
				if (num%2==0)
				{
                    Console.Write(num + " ");
				}
			}
            Console.WriteLine();
        }

        public void ShowOdd()
        {
            foreach (int num in Numbers)
            {
                if (num % 2 != 0)
                {
                    Console.Write(num + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
