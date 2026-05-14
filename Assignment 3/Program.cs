using System.Text;

namespace Assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region დავალება 1
            string strUser = "admin";
            string strPass = "1234";

            Console.WriteLine("Enter Username: ");
            string strUserInput = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            string strPassInput = Console.ReadLine();

            if (strUser == strUserInput && strPass == strPassInput)
            {
                Console.WriteLine("Welcome!");
            }
            else
            {
                Console.WriteLine("Access Denied");
            }
            #endregion

            #region დავალება 2

            Console.Write("Enter the first number: ");
            int firstNum;
            bool validFirst = int.TryParse(Console.ReadLine(), out firstNum);

            Console.Write("Enter the operator: ");
            char operators;
            bool validOp = char.TryParse(Console.ReadLine(), out operators);

            Console.Write("Enter the second number: ");
            int secondNum;
            bool validSecond = int.TryParse(Console.ReadLine(), out secondNum);

            if (validFirst && validSecond && validOp)
            {
                switch (operators)
                {
                    case '+':
                        Console.WriteLine(firstNum + secondNum); break;
                    case '-':
                        Console.WriteLine(firstNum - secondNum); break;
                    case '*':
                        Console.WriteLine(firstNum * secondNum); break;
                    case '/':
                        Console.WriteLine(firstNum / secondNum); break;
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
            #endregion

            #region დავალება 3
            Console.Write("Enter your age: ");
            byte age;
            bool validNum = byte.TryParse(Console.ReadLine(), out age);
            if (validNum)
            {
                if (age>=0 && age<=12)
                {
                    Console.WriteLine("You're a child!");
                }
                if (age >= 13 && age <= 19)
                {
                    Console.WriteLine("You're a teenager!");
                }
                if (age >= 20 && age <= 64)
                {
                    Console.WriteLine("You're an adult!");
                }
                if (age >= 65)
                {
                    Console.WriteLine("You're an elder!");
                }
            }
            #endregion

        }
    }
}
