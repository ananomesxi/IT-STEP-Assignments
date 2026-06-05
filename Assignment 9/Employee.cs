using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_9
{
    public enum Countries { 
        Georgia,
        Greece,
        Italy,
        Germany
    }

    public enum Genders
    {
        Male,
        Female,
        Unknown

    }

    public enum Contacts
    {
        Email,
        Phone,
        Fax
    }

    internal class Employee
    {
        private string _name;
        private string _surname;
        private DateTime _dateOfBirth;

        public Employee(string name, string surname, DateTime dateOfBirth, Countries country, Genders gender, Contacts contact, string contactValue)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Country = country;
            Gender = gender;
            Contact = contact;
            ContactValue = contactValue;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) // ნალი და ცარიელი სტრინგი არ გვაწყობს
                {
                    _name = value;
                }
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) // ნალი და ცარიელი სტრინგი არ გვაწყობს
                {
                    _surname = value;
                }
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value <= DateTime.Now.AddYears(-16))  // ლეგალურად მუშაობის ასაკს ამოწმებს
                {
                    _dateOfBirth = value;
                }
            }
        }

        public Countries Country { get; set; }

        public Genders Gender { get; set; }

        public Contacts Contact { get; set; }

        public string ContactValue { get; set; }


        public int EmployeeAge ()
        {
            int age =  DateTime.Now.Year - DateOfBirth.Year;

            // თუ წელს დაბადების დღე არ ჰქონია, მაშინ 1 წელი გამოაკლოს
            if (DateTime.Now.Month<DateOfBirth.Month || (DateTime.Now.Month==DateOfBirth.Month && DateTime.Now.Day<DateOfBirth.Day))
            {
                age--;
            }
            return age;
        }


        // ცალკე მეთოდი, რომელიც დაბეჭდავს ინფორმაციას. გამოვიყენებ საერთო ქვეყნების ძიების მეთოდში
        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Name: {Name}, Sunrame: {Surname}, Date of birth: {DateOfBirth}, Country: {Country}, Gender: {Gender}, Contact Info: {Contact}.");
        }
        

        public static void CommonCountry(Employee[] employees, Countries targetCountry)
        {
            foreach (Employee employee in employees)
            {
                if (employee.Country==targetCountry)
                {
                    employee.DisplayEmployeeInfo(); 
                }
            }
        }

        
        


    }
}
