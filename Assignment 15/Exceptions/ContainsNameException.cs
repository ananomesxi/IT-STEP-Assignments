using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_15.Exceptions
{
    internal class ContainsNameException : Exception
    {
        public ContainsNameException() : base("Such student already exists.")
        {
        }
    }
}
