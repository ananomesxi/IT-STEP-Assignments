using Assignment_15.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_15.Services
{
    internal class StudentsServices
    {
        public static void ShowMenu()
        {
            Console.WriteLine("1. Add a new student.");
            Console.WriteLine("2. Find a student.");
            Console.WriteLine("3. Change points.");
            Console.WriteLine("4. Show all students.");
            Console.WriteLine("5. Exit program.");
        }

        public static void AddNewStudent(List<string> nameList, Dictionary<string, int> pointsDict)
        {
            Console.Write("Enter a name: ");
            string userInputName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(userInputName))
            {
                throw new NullOrWhiteSpaceException();
            }

            if (pointsDict.ContainsKey(userInputName))
            {
                throw new ContainsNameException();
            }

            nameList.Add(userInputName);
            Console.Write("Enter points: ");

            bool isValidPoints = int.TryParse(Console.ReadLine(), out int userInputPoints);
            if (!isValidPoints)
            {
                throw new FormatException();
            }
            if (userInputPoints < 0 || userInputPoints > 100)
            {
                throw new InvalidPointsException();
            }
            pointsDict[userInputName] = userInputPoints;
        }

        public static void FindStudent(Dictionary<string, int> pointsDict)
        {
            Console.Write("Enter a name: ");
            string userInputName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(userInputName))
            {
                throw new NullOrWhiteSpaceException();
            }
            if (!pointsDict.ContainsKey(userInputName))
            {
                throw new NotContainsNameException();
            }

            Console.WriteLine($"{userInputName}'s points: {pointsDict[userInputName]}");
        }

        public static void ChangePoints(Dictionary<string, int> pointsDict)
        {
            Console.Write("Enter a name: ");
            string userInputName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(userInputName))
            {
                throw new NullOrWhiteSpaceException();
            }
            if (!pointsDict.ContainsKey(userInputName))
            {
                throw new NotContainsNameException();
            }

            Console.Write("Enter new points: ");
            bool isValidPoints = int.TryParse(Console.ReadLine(), out int userInputPoints);
            if (!isValidPoints)
            {
                throw new FormatException();
            }
            if (userInputPoints < 0 || userInputPoints > 100)
            {
                throw new InvalidPointsException();
            }
            pointsDict[userInputName] = userInputPoints;
        }

        public static void ShowAllStudents(List<string> nameList, Dictionary<string, int> pointsDict)
        {
            foreach (string name in nameList)
            {
                Console.WriteLine($"Name: {name}, Points: {pointsDict[name]}.");
            }
        }
    }
}
