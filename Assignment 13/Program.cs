using System.Transactions;

namespace Assignment_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // try - catch რამდენად სწორად მაქვს არ ვიცი და რომ ნახოთ :"> 

            Student[] students = new Student[0]; // ეს თრაის გარეთ დავწერე, რადგან პირველი თრაის მერე აღარ აღიქვამდა პროგრამა რატომღაც
            
            try { // პირველი თრაი (სიის შედგენისას)

            string path = @"../../../data.txt";
            using StreamReader reader = new StreamReader(path);
            
            int index = 0;
            while (!reader.EndOfStream)
            {
                Array.Resize(ref students, students.Length + 1);
                string line = reader.ReadLine();
                string[] data = line.Split(',');

                bool isValidData2 = int.TryParse(data[2], out int data2);
                bool isValidData5 = double.TryParse(data[5], out double data5);
                bool isValidData6 = Enum.TryParse(data[6], out Faculty data6);

                if (!isValidData2 || !isValidData5 || !isValidData6)
                {
                    throw new FormatException();
                }
                students[index] = new Student(data[0], data[1], data2, data[3], data[4], data5, data6);

                ++index;
            }
            }
             catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
             catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }


            byte UserChoice = 0;
            while (UserChoice != 10) // აქ 2 ვარიანტი დავამატე (ბონუსში რაც ეწერა, პრინტი და ორი სტუდენტის შედარება) და ამიტომაა 10 ვარიანტი.
                {
                    try // მეორე თრაი (თვითონ პროგრამის მუშაობისას)
                    {
                        StudentMethods.LoadMenu();
                        if (!byte.TryParse(Console.ReadLine(), out UserChoice))
                        {
                            throw new InvalidChoice();
                        }

                        switch (UserChoice)
                        {
                            case 1:
                                {
                                    foreach (Student student in students)
                                    {
                                        student.DisplayInfo();
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    // თავიდან სორტით ვაკეთებდი:
                                    // Array.Sort(students);
                                    // Console.WriteLine($"The best student is: {students[students.Length - 1]} (GPA - {students[students.Length - 1].GPA}");
                                    //მაგრამ რადგან პირობა სხვანაირად გვთხოვს ოპერატორების გადატვირთვას გამოვიყენებ:

                                    int bestStudent = 0;
                                    for (int i = 1; i < students.Length; i++)
                                    {
                                        if (students[i] >= students[bestStudent]) bestStudent = i;
                                    }
                                    Console.WriteLine($"Best student is: {students[bestStudent].FirstName} {students[bestStudent].LastName}.");
                                    break;
                                }
                            case 3:
                                {
                                    double sum = 0;
                                    foreach (Student student in students)
                                    {
                                        sum += student;
                                    }
                                    double averageGPA = sum / students.Length;
                                    Console.WriteLine($"Average GPA is {averageGPA}");
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("Enter a last name: ");
                                    string userInputLastName = Console.ReadLine().Trim().ToLower(); // სუფთა სტრინგის მისაღებად

                                    Console.WriteLine("Student(s) with this last name:");
                                    bool found = false;
                                    foreach (Student student in students)
                                    {
                                        if (userInputLastName.Equals(student.LastName.ToLower())) // ფროფერთიც ლოვერქეის ასოებში გადავიყვანე
                                        {
                                            student.DisplayInfo();
                                            found = true;
                                        }
                                    }
                                    if (!found)
                                    {
                                        Console.WriteLine("None found.");
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    Array.Sort(students); // კლებადობით არ დავალაგე, უბრალოდ for-ში უკუღმა ჩამოვუვლი
                                    for (int i = students.Length - 1; i > 0; i--)
                                    {
                                        Console.WriteLine($"{i - 1}. {students[i].FirstName}, GPA: {students[i].GPA}");
                                    }
                                    break;
                                }
                            case 6:
                                {
                                    StudentMethods.AddStudent(ref students); break;
                                }
                            case 7:
                                {
                                    Console.WriteLine($"Enter email to erase a student.");
                                    StudentMethods.Erase(ref students);
                                    break;
                                }
                            case 8:
                                {
                                    Console.WriteLine($"Select a student to print information (1-{students.Length}).");
                                    bool isValidChoice = int.TryParse(Console.ReadLine(), out int choice);
                                    if (!isValidChoice || choice > students.Length || choice <= 0)
                                    {
                                        throw new InvalidChoice();
                                    }
                                    students[choice - 1].Print();
                                    break;
                                }
                            case 9:
                                {
                                    Console.WriteLine($"Select the first student: (1-{students.Length}).");
                                    bool isValidChoice1 = int.TryParse(Console.ReadLine(), out int choice1);
                                    if (!isValidChoice1 || choice1 > students.Length || choice1 <= 0)
                                    {
                                        throw new InvalidChoice();
                                    }
                                    Console.WriteLine($"Select the second student: (1-{students.Length}).");
                                    bool isValidChoice2 = int.TryParse(Console.ReadLine(), out int choice2);
                                    if (!isValidChoice2 || choice2 > students.Length || choice2 <= 0)
                                    {
                                        throw new InvalidChoice();
                                    }
                                    if (students[choice1 - 1].CompareTo(students[choice2 - 1]) == 0)
                                    {
                                        Console.WriteLine("These students are equal.");
                                    }
                                    if (students[choice1 - 1].CompareTo(students[choice2 - 1]) > 0)
                                    {
                                        Console.WriteLine("First student is better.");
                                    }
                                    if (students[choice1 - 1].CompareTo(students[choice2 - 1]) < 0)
                                    {
                                        Console.WriteLine("Second student is better.");
                                    }
                                    break;
                                }
                        case 10:
                            {
                                break;
                            }
                        default:
                                {
                                    throw new InvalidChoice();
                                }

                        }
                    }

                    catch (NullOrWhiteSpaceException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (InvalidAgeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (InvalidEmailException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (InvalidGPAException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (InvalidChoice ex)
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
}
