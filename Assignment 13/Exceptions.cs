using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_13
{
    internal class NullOrWhiteSpaceException : Exception
    {
        public NullOrWhiteSpaceException() : base("Data can not be null or white space. Try again.")
        {
        }
    }

    internal class InvalidAgeException : Exception
    {
        public InvalidAgeException() : base("Age should be greater than 16.")
        {
        }
    }
    internal class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base("Email is invalid. It should contain '@' symbol.")
        {
        }
    }
    internal class InvalidGPAException : Exception
    {
        public InvalidGPAException() : base("GPA should be between 0-100.")
        {
        }
    }
    internal class InvalidChoice : Exception
    {
        public InvalidChoice() : base("Enter a valid number.")
        {
        }
    }




}
