using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_10
{
    public enum PoliticalParty
    {
        Democratic,
        Republican,
        Conservative,
        Liberal,
        Socialist,
        Other
    }

    internal class President : Worker
    {
        public President(string firstName, string lastName, DateTime dateOfBirth, Gender gender, decimal salary, PoliticalParty politicalParty) : base(firstName, lastName, dateOfBirth, gender, salary)
        {
            PoliticalParty = politicalParty;
        }

        public PoliticalParty PoliticalParty { get; set; }
        public override void Print ()
        {
            PrintCommonInfo();
            Console.WriteLine($"PoliticalParty party: {PoliticalParty}");
        }
    }
}
