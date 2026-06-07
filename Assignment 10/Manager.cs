using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_10
{
    internal class Manager : Worker
    {
        private int _teamSize;

        public Manager(string firstName, string lastName, DateTime dateOfBirth, Gender gender, decimal salary, int teamSize) : base(firstName, lastName, dateOfBirth, gender, salary)
        {
            TeamSize = teamSize;
        }

        public int TeamSize
        {
            get 
            {
                return _teamSize; 
            }
            set
            {
                if (!int.TryParse(value.ToString(), out _teamSize))
                {
                    Console.WriteLine("Something went wrong. Try again.");
                }
                else if (value < 1)
                {
                    Console.WriteLine("Team size must be at least 1.");
                }
                _teamSize = value; 
            }
        }

        public override void Print()
        {
            PrintCommonInfo();
            Console.WriteLine($"Team size: {TeamSize}");
        }
    }
}
