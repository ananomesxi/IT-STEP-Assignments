using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using UniversityDomain.Models;

namespace UniversityDomain.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();

        Student GetById(int id);

        bool Add(Student student);

        bool DeleteStudent(int studentId);
        bool ChangeGPA(int studentId, decimal newGpa);

    }
}
