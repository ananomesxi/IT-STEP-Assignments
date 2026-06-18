using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace _Optional__Assignment_12
{
    internal class Student : IComparable
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private string _email;
        private string _phone;
        private int _point;

        public string FirstName 
        { 
            get
            {
                return _firstName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Something went wrong. Try entering the first name again."); return;
                }
                else
                {
                    _firstName = value;
                }
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
                if (String.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Something went wrong. Try entering the last name again."); return;
                }
                else
                {
                    _lastName = value;
                }
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Age should be greater than 0."); return;
                }
                else
                {
                    _age = value;
                }
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$"))
                {
                    Console.WriteLine("Something went wrong. Try entering the Email again."); return;
                }
                else
                {
                    _email = value;
                }
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
                    Console.WriteLine("Something went wrong."); return;
                }
                else
                {
                    _phone = value;
                }
            } 
        }
        public int Point
        {
            get
            {
                return _point;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Points should be greater than 0."); return;
                }
                else
                {
                    _point = value;
                }
            }
        }

        public int CompareTo(object? other)
        {
            return this.Point.CompareTo((other as Student).Point);
        }

        public static bool operator <(Student s1, Student s2)
        {
            return s1.Age < s2.Age;
        }
        public static bool operator >(Student s1, Student s2)
        {
            return s1.Age > s2.Age;
        }
        public static int operator + (int n, Student s1)
        {
            return n + s1.Point;
        }


        //ვიპოვოთ ისეთი სტუდენტი რომელსაც აქვს ყველაზე დაბალი ქულა
        //ვიპოვოთ ისეთი სტუდენტი რომელიც ყველაზე დიდია ასაკით
        //ვიპოვოთ ყველა სტუდენტის საშუალო ქულა
        // დაასორტირეთ სტუდენტების მასივი


    }
}
