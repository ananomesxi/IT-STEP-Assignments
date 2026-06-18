using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_13
{
    internal class StudentMethods
    {
        // ცალკე კლასი შევქმენი პროგრამისთვის საჭირო მეთოდებისთვის რომ სტუდენტ კლასი არ გადავავსო ბევრი კოდით
        public static void LoadMenu()
        {
            Console.WriteLine("Select an option: ");
            Console.WriteLine("1. Show all students");
            Console.WriteLine("2. Find the best student");
            Console.WriteLine("3. Generate average GPA");
            Console.WriteLine("4. Find a student with last name");
            Console.WriteLine("5. Sort students with GPA");
            Console.WriteLine("6. Add a new student");
            Console.WriteLine("7. Erase a student");
            Console.WriteLine("8. Print all info");
            Console.WriteLine("9. Compare two students");
            Console.WriteLine("10. Exit the program");
        }

        public static void AddStudent(ref Student[] students)
        {
            int index = students.Length;
            Array.Resize(ref students, index + 1); // ჯერ გავზარდე ერრეი, რომ შემდეგ ახალი ელემენტი ჩავამატო

            // ამის დაწერის უკეთესი გზა თუ არის არ ვიცი... ჯერ ყველა ფროფერთი შევაყვანინე და შემდეგ ჩავუწერე კონსტრუქტორში...
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Age: ");
            bool isValidAge = int.TryParse(Console.ReadLine(), out int age);
            if (!isValidAge)
            {
                throw new FormatException(); // მარტო ამ ექსეფშენს ვუკეთებ, რადგან დანარჩენი ვალიდაცია თვითონ გეტ-სეტში მიწერია 
            }

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.Write("GPA: ");
            bool isValidGPA = double.TryParse(Console.ReadLine(), out double gpa);
            if (!isValidGPA)
            {
                throw new FormatException(); // მარტო ამ ექსეფშენს ვუკეთებ, რადგან დანარჩენი ვალიდაცია თვითონ გეტ-სეტში მიწერია
            }

            Console.Write("Faculty: ");
            string faculty = Console.ReadLine();
            Faculty facultyEnum = (Faculty)Enum.Parse(typeof(Faculty), faculty);

            students[index] = new Student(firstName, lastName, age, email, phone, gpa, facultyEnum);

        }

        public static void Erase (ref Student[] students)
        {
            string userInputEmail = Console.ReadLine().Trim();

            bool foundEmail = false;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Email.Equals(userInputEmail))
                {
                    foundEmail = true;
                    students[i] = students[students.Length - 1];
                    Array.Resize(ref students, students.Length - 1); break;
                }
            }
            if (!foundEmail)
            {
                Console.WriteLine("There is no such student.");
            }
        }
    }
}
