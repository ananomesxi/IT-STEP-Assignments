using System.ComponentModel.Design;

namespace Assignment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region დავალება 1

            Console.Write("Enter your number: ");
            bool validNum = int.TryParse(Console.ReadLine(), out int num);
            if (validNum)
            {
                for (int i = 1; i <=10; i++)
                {
                    Console.WriteLine ($"{num} * {i} = {num*i}");
                }
            }
            else
            {
                Console.WriteLine("Try again");
            }

            #endregion

            #region დავალება 2

            // აქ პირობა ოდნავ შევცვალე და მარტო კენტი რიცხვის შეყვანაზე ვამუშავებ, თორემ მგონი ლუწებზე არ გამოდის პირამიდა :")
            // და row-ების რაოდენობაც ამიტომ გავანახევრე
            
            Console.Write("Enter your number: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int num1);

            if (isValid && num1%2==1)
            {
                for (int i = 1; i <=num1/2+1; i++)
                {
                    for (int j=0; j<num1/2-i+1; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int j=1; j<=2*i-1; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Try again");
            }

            #endregion

            #region დავალება 3

            Console.Write("Enter your number: ");
            bool validNums = int.TryParse(Console.ReadLine(), out int nums);

            if (validNums)
            {
                int sum = 0;

                for (int i = 0; i <= nums; i = i + 2)
                {
                    sum += i;
                }

                Console.WriteLine($"The sum is: {sum}");
            }
            else
            {
                Console.WriteLine("Try again");
            }
            #endregion

            #region დავალება 4

            Random randomNum = new Random();
            int random = randomNum.Next(1, 100);
            int numInput;
            while (true)
            {
                Console.Write("Enter your number (1-99): ");
                bool numValid = int.TryParse(Console.ReadLine(), out numInput);

                if (numValid)
                {
                    if (numInput == random)
                    {
                        Console.WriteLine("Correct!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong, Try again");
                    }
                }
                else
                {
                    Console.WriteLine("Try again");
                }

            }


            #endregion
        }
    }
}
