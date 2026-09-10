using System;
using System.Collections.Generic;
using System.Text;
using UniversityDomain.Interfaces;
using UniversityDomain.Models;

namespace UniversityApplication.Services
{
    public class InstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public void GetAllInstructors() // I will change this after i add menu
        {
            IEnumerable<Instructor> instructors = _instructorRepository.GetAllInstructors();
            foreach (var instructor in instructors)
            {
                Console.WriteLine(instructor);
            }
        }

        public void GetInstructorById(int id)
        {
            Instructor instructor = _instructorRepository.GetById(id);

            if (instructor != null)
            {
                Console.WriteLine(instructor);
            }
            else
            {
                Console.WriteLine($"Instructor with ID {id} not found.");
            }
        }

        public void AddInstructor(Instructor instructor)
        {
            bool isAdded = _instructorRepository.AddInstructor(instructor);
            if (isAdded)
            {
                Console.WriteLine("Instructro added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add instructor.");
            }
        }

        public void DeleteInstructor(int instructorId)
        {
            bool isDeleted = _instructorRepository.DeleteInstructor(instructorId);
            if (isDeleted)
            {
                Console.WriteLine($"Instructor ID {instructorId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to delete Instructor ID {instructorId}.");
            }
        }
        public void ChangeInstructorEmail(int instructorId, string newEmail)
        {
            bool isChanged = _instructorRepository.ChangeEmail(instructorId, newEmail);
            if (isChanged)
            {
                Console.WriteLine($"Instructor ID {instructorId} email changed to {newEmail} successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to change email for Instructor ID {instructorId}.");
            }
        }

    }
}
