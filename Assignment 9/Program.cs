using System.Runtime.InteropServices;

namespace Assignment_9
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // ეს ინფორმაცია ალბათ მეინში უნდა დარჩეს...?
            Employee emp1 = new Employee("Mariam", "Beruashvili", new DateTime(2000, 3, 5), Countries.Georgia,Genders.Female, Contacts.Phone, "923-238-342");
            Employee emp2 = new Employee("Giorgi", "Bagrationi", new DateTime(1997, 11, 23), Countries.Georgia, Genders.Male, Contacts.Phone, "123-228-342");
            Employee emp3 = new Employee("Dimitrios", "Makris", new DateTime(2003, 6, 2), Countries.Greece, Genders.Male, Contacts.Phone, "234-238-342");
            Employee emp4 = new Employee("Ioannis", "Vlachos", new DateTime(1992, 10, 18), Countries.Greece, Genders.Male, Contacts.Phone, "764-238-654");
            Employee emp5 = new Employee("Sofia", "Gallo", new DateTime(2001, 12, 15), Countries.Italy, Genders.Female, Contacts.Phone, "923-234-235");
            Employee emp6 = new Employee("Chiara", "Costa", new DateTime(1997, 10, 24), Countries.Italy, Genders.Female, Contacts.Phone, "645-238-342");
            Employee emp7 = new Employee("Lena", "Wagner", new DateTime(2001, 2, 10), Countries.Germany, Genders.Female, Contacts.Phone, "245-238-342");
            Employee emp8 = new Employee("Jonas", "Bauer", new DateTime(1999, 10, 12), Countries.Germany, Genders.Male, Contacts.Phone, "645-235-342");

            Employee[] employees = {emp1, emp2, emp3, emp4, emp5, emp6, emp7, emp8};

            Console.WriteLine("Which employee's age would you like to see? (Enter a number 1-8)");
            bool isValidNum = byte.TryParse(Console.ReadLine(), out byte num);

            if (isValidNum && num >=1 && num <=8)
            {
                Console.WriteLine($"Employee's age is {employees[num - 1].EmployeeAge()}");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }


            Console.WriteLine("Enter your target Country: ");

            // გადავპარსოთ შეყვანილი ქვეყანა Countries ტიპში:
            Countries targetCountry = (Countries)Enum.Parse(typeof(Countries), Console.ReadLine());

            Employee.CommonCountry(employees, targetCountry);

            

        }
    }
}
