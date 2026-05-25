using System.Security;

namespace Assignment_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region დავალება 1

            byte[][] students = [[5, 6], [1, 4, 8, 9], [8, 10, 10], [2, 4, 6, 7], [5, 8, 10, 10, 10]];

            for (int i = 0; i < students.Length; i++)
            {
                
                double sum = 0;
                for (int j = 0; j < students[i].Length; j++)
                {
                    sum += students[i][j];
                }
                double average = sum / students[i].Length;
                Console.WriteLine($"Student {i}: {average}");
            }

            #endregion


            #region დავალება 2

            int[] passcodes = new int[10];
            Random r = new Random();

            for (int i=0; i<10; i++)
                {
                    passcodes[i] = r.Next(1000, 9999);
                }

                Console.Write("Enter 4 digits: ");

                while (true)
                {
                bool isValid = int.TryParse(Console.ReadLine(), out int userInput);
                if (isValid && userInput>=1000 && userInput <=9999) {
                    bool guessed = false;
                    foreach (int passcode in passcodes)
                    {
                        if (passcode == userInput)
                        {
                            Console.WriteLine("Congrats! You guessed a passcode!");
                            guessed = true;
                        }
                    }
                    if (!guessed)
                    {
                        Console.WriteLine("You didn't guess! Try again!");
                    }
                    break;
                }
                Console.Write("Something went wrong! Try again: ");

            }
            

            #endregion


            #region დავალება 3

            int[] arr = new int[5];

            for (int i=0; i<5; i++)
            {
                Console.Write($"Enter number {i+1}: ");
                while (true)
                {
                    bool valid = int.TryParse(Console.ReadLine(), out arr[i]);
                    if (valid) break;
                    Console.Write("Something went wrong. Try again: ");
                }
            }

            int maxNum = arr[0];
            int minNum = arr[0];

            foreach(int num in arr)
            {
                if (num > maxNum) maxNum = num;
                else if (num < minNum) minNum = num;
            }

            Console.WriteLine($"The biggest number is: {maxNum}");
            Console.WriteLine($"The smallest number is: {minNum}");
            #endregion


            #region დავალება 4

            string[] strArr = new string[5];

            for (int i=0; i<5; i++)
            {
                Console.Write($"Enter word {i+1}: ");
                strArr[i] = Console.ReadLine();
            }

            foreach(string str in strArr)
            {
                Console.Write("Your symbols are: ");
                foreach(char c in str)
                {
                    Console.Write($"{c} ");
                }
                Console.WriteLine();
            }

            #endregion


            #region დავალება 5

            string[] emails = new string[5];

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter email {i+1}: ");
                emails[i] = Console.ReadLine();
            }

            bool allHaveAt = true;
            string noAtEmails = "";
            for (int i = 0; i < emails.Length; i++)
            {
                bool isAt = false;
                foreach (char c in emails[i])
                {
                    if (c == '@') isAt = true;
                }
                if (!isAt) 
                {
                    noAtEmails += $"{i + 1} ";
                    allHaveAt = false;
                }
            }
            if (allHaveAt)
            {
                Console.WriteLine("All of the emails have '@'.");
            }
            else
            {
                Console.WriteLine($"'@' is missing in email(s): {noAtEmails}");
            }

            #endregion
        }
    }
}
