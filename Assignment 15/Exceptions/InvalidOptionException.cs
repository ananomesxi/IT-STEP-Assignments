using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_15.Exceptions
{
    internal class InvalidOptionException : Exception
    {
        public InvalidOptionException() : base("Invalid option. Try again.")
        {
        }
    }
}
