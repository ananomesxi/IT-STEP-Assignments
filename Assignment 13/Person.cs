using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_13
{
    internal abstract class Person
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new NullOrWhiteSpaceException();
                }
                _firstName = value;
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new NullOrWhiteSpaceException();
                }
                _lastName = value;
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
                if (value <= 16)
                {
                    throw new InvalidAgeException();
                }
                _age = value;
            }
        }
    }
}
