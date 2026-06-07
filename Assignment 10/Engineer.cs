using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_10
{
    public enum Specialization
    {
        Electrical,
        Computer,
        Mechanical,
        Aerospace,
        Civil
    }
    internal class Engineer : Worker
    {
        public Engineer(string firstName, string lastName, DateTime dateOfBirth, Gender gender, decimal salary, Specialization specialization) : base(firstName, lastName, dateOfBirth, gender, salary)
        {
            Specialization = specialization;
        }

        public Specialization Specialization { get; set; }

        public override void Print()
        {
            PrintCommonInfo();
            Console.WriteLine($"Specialization: {Specialization}");
        }
    }
}
