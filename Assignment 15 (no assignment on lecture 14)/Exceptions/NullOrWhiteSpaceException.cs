using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_14.Exceptions
{
    internal class NullOrWhiteSpaceException : Exception
    {
        public NullOrWhiteSpaceException() : base("Name can't be null or white space.")
        {
        }
    }
}
