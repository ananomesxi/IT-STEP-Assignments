using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_14.Exceptions
{
    internal class ContainsNameException : Exception
    {
        public ContainsNameException() : base("Such student already exists.")
        {
        }
    }
}
