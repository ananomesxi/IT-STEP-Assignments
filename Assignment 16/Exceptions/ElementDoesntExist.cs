using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_16.Exceptions
{
    internal class ElementDoesntExist : Exception
    {
        public ElementDoesntExist() : base("Such Element doesn't exist")
        {

        }
        
    }
}
