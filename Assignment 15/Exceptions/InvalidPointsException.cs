using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_15.Exceptions
{
    internal class InvalidPointsException : Exception
    {
        public InvalidPointsException() : base("Points should be between 0-100.")
        {
        }
    }
}
