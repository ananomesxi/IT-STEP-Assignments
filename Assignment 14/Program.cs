using Assignment_14.Exceptions;
using Assignment_14.Services;

namespace Assignment_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> nameList = new List<string>();
                Dictionary<string, int> pointsDict = new Dictionary<string, int>();

                while (true)
                {
                    {
                        StudentsServices.ShowMenu();
                    }

                    string userChoice = Console.ReadLine();

                    switch (userChoice)
                    {
                        case "1":
                            {
                                StudentsServices.AddNewStudent(nameList, pointsDict);
                                break;
                            }
                        case "2":
                            {
                                StudentsServices.FindStudent(pointsDict);
                                break;
                            }
                        case "3":
                            {
                                StudentsServices.ChangePoints(pointsDict);
                                break;
                            }
                        case "4":
                            {
                                StudentsServices.ShowAllStudents(nameList, pointsDict);
                                break;
                            }
                        case "5":
                            {
                                return;
                            }
                        default:
                            {
                                throw new InvalidOptionException();
                                break;
                            }
                    }
                }
            }
            catch (InvalidOptionException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ContainsNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotContainsNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullOrWhiteSpaceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidPointsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
    }
}
