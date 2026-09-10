using UniversityDomain.Interfaces;
using UniversityInfrastructure.Repositories;
using UniversityApplication.Services;
using System.Text;
using UniversityDomain.Models;
using Microsoft.Extensions.Configuration;

namespace UniversityPresentation
{
    internal class Program
    {
        // ეს გადავიყვანე appsettings.json ფაილში, რომ არ იყოს კოდი გამჭვირვალე:
        //private static readonly string _connectionString = "info";
        static void Main(string[] args)
        {

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            var _connectionString = configuration.GetConnectionString("DefaultConnection");

            // TEST:

            Console.OutputEncoding = Encoding.UTF8;
            IStudentRepository studentRepository = new StudentRepository(_connectionString);
            var StudentService = new StudentService(studentRepository);

            IInstructorRepository instructorRepository = new InstructorRepository(_connectionString);
            var InstructorService = new InstructorService(instructorRepository);
            /*
            Console.WriteLine("All students:");
            StudentService.GetAllStudents();

            Console.WriteLine("\nStudent N1:");
            StudentService.GetStudentById(1);

            Console.WriteLine("\nAdding a new student:");
            StudentService.AddStudent
            (
                new Student 
                {   
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Age = 20,
                    GPA = 3.5m,
                    PhoneNumber = "123-456-7890",
                    IsActive = true,
                    RegisteredAt = DateTime.Now,
                    DepartmentID = 1
                }
            );

            Console.WriteLine("\nChanging student GPA:");
            StudentService.ChangeStudentGPA(1, 3.8m);
            */

            Console.WriteLine("All instructors:");
            InstructorService.GetAllInstructors();

            Console.WriteLine("\nInstructor N1:");
            InstructorService.GetInstructorById(1);

            Console.WriteLine("\nAdding a new instructor:");
            InstructorService.AddInstructor
                (
                new Instructor
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com"
                }
                );
            Console.WriteLine("\nChanging instructor email:");
            InstructorService.ChangeInstructorEmail(1, "jane.smith1@example.com");
        }
    }
}
