using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Assignment_13
{
    public enum Faculty
    {
        IT,
        Business,
        Design,
        Medicine
    }
    internal class Student : Person, IComparable, IPrintable
    {
		
        private string _email;
        private string _phone;
        private double _gpa;

        public Student(string firstName, string lastName, int age, string email, string phone, double gPA, Faculty faculty)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            Phone = phone;
            GPA = gPA;
            Faculty = faculty;
        }

        
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new NullOrWhiteSpaceException();
                }
                if (!value.Contains("@"))
                {
                    throw new InvalidEmailException();
                }
                _email = value;
            }
        }
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new NullOrWhiteSpaceException();
                }
                _phone = value;
            }
        }
        public double GPA
        {
            get
            {
                return _gpa;
            }
            set
            {
                if (value>100 || value <0)
                {
                    throw new InvalidGPAException();
                }
                
                _gpa = value;
            }
        }
        public Faculty Faculty { get; set; }

        
        

        public int CompareTo(object? other)
        {
            return this.GPA.CompareTo((other as Student).GPA); // სორტისთვის გამოვიყენებ
        }

        public void DisplayInfo()
        {
                Console.WriteLine($"First name: {FirstName} | Last Name: {LastName} | Faculty: {Faculty} | GPA: {GPA}");
        }

        public void Print()
        {
            Console.WriteLine($"First Name: {FirstName}, Last Name: {LastName}, Age: {Age}, Email: {Email}, Phone: {Phone}, GPA: {GPA}, Faculty: {Faculty}.");
        }

        public static implicit operator double(Student s1) => s1.GPA; // დაბლი და სტუდენტის ტიპის ელემენტები რომ დავაჯამო
        

        // აქედან ყველა ბოლოს აღარ გამოვიყენე მაგრამ იყოს მაინც რაში გვიშლის:
        public static double operator +(Student s1, Student s2) => s1.GPA + s2.GPA;
        public static bool operator >(Student s1, Student s2) => s1.GPA > s2.GPA;
        public static bool operator <(Student s1, Student s2) => s1.GPA < s2.GPA;
        public static bool operator >=(Student s1, Student s2) => s1.GPA >= s2.GPA;
        public static bool operator <=(Student s1, Student s2) => s1.GPA <= s2.GPA;
        public static bool operator ==(Student s1, Student s2) => s1.GPA == s2.GPA;
        public static bool operator !=(Student s1, Student s2) => s1.GPA != s2.GPA;


    }
}
