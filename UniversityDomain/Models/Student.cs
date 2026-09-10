using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDomain.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public decimal? GPA { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public int? DepartmentID { get; set; }

        public override string ToString()
        {
            return $"Student ID: {Id}, Name: {FirstName} {LastName}, Email: {Email}, Age: {Age}, GPA: {GPA}, Phone: {PhoneNumber}, Active: {IsActive}, Registered At: {RegisteredAt}, Department ID: {DepartmentID}";
        }
    }
}
