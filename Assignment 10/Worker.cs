using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_10
{

    public enum Gender
    {
        Male,
        Female,
        NotMentioned
    }
    internal abstract class Worker
    {
        private string _firstName;
        private string _lastName;
        private decimal _salary;
        private DateTime _dateOfBirth;

        protected Worker(string firstName, string lastName, DateTime dateOfBirth, Gender gender, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Salary = salary;
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Something went wrong. Try again."); return;
                }

                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Something went wrong. Try again."); return;
                }

                _lastName = value;
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
                if (value > DateTime.Now)
                {
                    Console.WriteLine("Enter a real date."); return;
                }
                _dateOfBirth = value;
            }
        }

        public Gender Gender { get; set; }

        public decimal Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (!decimal.TryParse(value.ToString(), out _salary))
                {
                    Console.WriteLine("Something went wrong. Try again."); return;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Salary must be greater than 0."); return;
                }
                _salary = value;
            }
        }

        public abstract void Print();

        public int Age ()
        {
            int age = DateTime.Now.DayOfYear - DateOfBirth.DayOfYear;
            return age;
        }

        // ცალკე მეთოდი საერთო ფროფერთების ჩამოსათვლელად.
        public void PrintCommonInfo ()
        {
            Console.WriteLine($"First name: {FirstName}\nLast name: {LastName}\nAge: {Age}\nGender: {Gender}\nSalary: ${Salary}");
        }

    }
}
