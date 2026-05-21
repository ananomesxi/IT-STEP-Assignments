namespace Assignment_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region დავალება 1

            int[] arr1 = [1, 2, 3];
            int[] arr2 = [4, 5, 6];

            int[] arrResult = new int[arr1.Length + arr2.Length];
            for (int i=0; i<arr1.Length; i++)
            {
                arrResult[i] = arr1[i];
            }
            for (int i=0; i<arr2.Length; i++)
            {
                arrResult[i + arr1.Length] = arr2[i];
            }

            foreach (int i in arrResult)
            {
                Console.Write(i + " ");
            }

            #endregion

            #region დავალება 2

            byte[] arr = [1, 2, 3, 7, 10, 15];

            Console.Write("Enter target sum: ");

            bool isValid = byte.TryParse(Console.ReadLine(), out byte targetSum);
            
            
            if (isValid)
            {
                Console.WriteLine("Result: ");
                bool noResult = true;
                
                for (int i=0; i<arr.Length; i++)
                {
                    for (int j=0; j<arr.Length; j++)
                    {
                        if (arr[i] + arr[j] == targetSum)
                        {
                            Console.WriteLine($"[{arr[i]}, {arr[j]}]");
                            noResult = false;
                        }
                    }
                }
                if (noResult)
                {
                    Console.WriteLine("There are no such pairs!");
                }
            }
            else
            {
                Console.WriteLine("Try again.");
            }

            #endregion

        }
    }
}
