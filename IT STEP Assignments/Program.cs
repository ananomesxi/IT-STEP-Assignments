using System.Runtime.ExceptionServices;
using System.Text;
namespace IT_STEP
{
    internal class program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;  // კონსოლში ქართული ტექსტი არ გამოჰქონდა


            // დავალება 1:

            Console.WriteLine("შეიყვანეთ სასისტემო მონაცემი: ");
            int intAge = int.Parse(Console.ReadLine());

            if (intAge >= 18)
            {
                Console.WriteLine("გილოცავ! ხმის მიცემის უფლება გაქვთ.");
            }

            else
            {
                Console.WriteLine("სამწუხაროდ ხმის მიცემის უფლება ჯერ არ გაქვთ.");
            }



            // დავალება 2:

            /*
            Console.WriteLine("შეიყვანეთ პირველი რიცხვი: ");
            int FirstNum = int.Parse(Console.ReadLine());

            Console.WriteLine("შეიყვანეთ მე-2 რიცხვი: ");
            int SecondNum = int.Parse(Console.ReadLine());

            Console.WriteLine("შეიყვანეთ მე-3 რიცხვი: ");
            int ThirdNum = int.Parse(Console.ReadLine());

            if (FirstNum > SecondNum && FirstNum > ThirdNum)
            {
                Console.WriteLine("პირველი რიცხვი მაქსიმალურია წარმოდგენილ რიცხვებს შორის.");
            }
            else if (SecondNum > FirstNum && SecondNum > ThirdNum) 
            {
                Console.WriteLine("მე-2 რიცხვი მაქსიმალურია წარმოდგენილ რიცხვებს შორის.");
            }
            else
            {
                Console.WriteLine("მე-3 რიცხვი მაქსიმალურია წარმოდგენილ რიცხვებს შორის.");
            }
            */



            // დავალება 3:

            /*
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            if (num1 > num2)
            {
                Console.WriteLine(num1);
            }
            else if (num2 > num1)
            {
                Console.WriteLine(num2);
            }
            else
            {
                Console.WriteLine(3*num1);
            }
            */
        }
    }
}
