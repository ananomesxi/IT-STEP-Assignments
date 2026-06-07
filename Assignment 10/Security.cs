using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Assignment_10
{
    public enum Shift
    {
        Day,
        Night,
        Custom
    }
    internal class Security : Worker
    {
        public Security(string firstName, string lastName, DateTime dateOfBirth, Gender gender, decimal salary, Shift shift, bool isArmed) : base(firstName, lastName, dateOfBirth, gender, salary)
        {
            Shift = shift;
            IsArmed = isArmed;
        }

        public Shift Shift { get; set; }
        public bool IsArmed { get; set; }

        public override void Print()
        { 
            PrintCommonInfo();
            Console.WriteLine($"Shift: {Shift}\nIs armed: {IsArmed}");
        }
    }
}
