namespace Assignment_11
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Array arr = new Array([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]);

            Console.WriteLine("Do you want to show evens or odds?");
            string ans = Console.ReadLine();
            if (ans == "evens")
            {
                arr.ShowEven();
            }
            else if (ans == "odds")
            {
                arr.ShowOdd();
            }
            else
            {
                Console.WriteLine("Something went wrong. Enter 'evens' or 'odds'.");
            }



            Console.WriteLine($"The amount of unique numbers is: {arr.CountDistinct()}");

            Console.WriteLine("Enter a number to count: ");

            bool isValid = int.TryParse(Console.ReadLine(), out int num);

            if (isValid)
            {
                Console.WriteLine($"There is/are {arr.EqualToValue(num)} of such numbers.");
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
            
        }
    }
}
