using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_15.Exceptions
{
    internal class NotContainsNameException : Exception
    {
        public NotContainsNameException() : base("Such student does not exists.")
        {
        }
    }
}
