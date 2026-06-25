using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_14.Exceptions
{
    internal class InvalidPointsException : Exception
    {
        public InvalidPointsException() : base("Points should be between 0-100.")
        {
        }
    }
}
