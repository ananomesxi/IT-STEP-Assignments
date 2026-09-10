using System;
using System.Collections.Generic;
using System.Text;
using UniversityDomain.Interfaces;
using UniversityDomain.Models;

namespace UniversityApplication.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void GetAllStudents() // I will change this after i add menu
        {
            IEnumerable<Student> students = _studentRepository.GetAll();

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        public void GetStudentById(int id)
        {
            Student student = _studentRepository.GetById(id);
            if (student != null)
            {
                Console.WriteLine(student);
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }

        public void AddStudent(Student student)
        {
            bool isAdded = _studentRepository.Add(student);
            if (isAdded)
            {
                Console.WriteLine("Student added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add student.");
            }
        }

        public void DeleteStudent(int studentId)
        {
            bool isDeleted = _studentRepository.DeleteStudent(studentId);
            if (isDeleted)
            {
                Console.WriteLine($"Student ID {studentId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to delete Student ID {studentId}.");
            }
        }
        public void ChangeStudentGPA(int studentId, decimal newGpa)
        {
            bool isChanged = _studentRepository.ChangeGPA(studentId, newGpa);
            if (isChanged)
            {
                Console.WriteLine($"Student ID {studentId} GPA changed to {newGpa} successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to change GPA for Student ID {studentId}.");
            }
        }


    }
}
