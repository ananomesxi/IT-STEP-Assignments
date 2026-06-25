using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_14.Exceptions
{
    internal class InvalidOptionException : Exception
    {
        public InvalidOptionException() : base("Invalid option. Try again.")
        {
        }
    }
}
