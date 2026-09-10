using System;
using System.Collections.Generic;
using System.Text;
using UniversityDomain.Models;

namespace UniversityDomain.Interfaces
{
    public interface IInstructorRepository
    {
        IEnumerable<Instructor> GetAllInstructors();
        Instructor GetById(int id);
        bool AddInstructor(Instructor instructor);
        bool DeleteInstructor(int instructorId);
        bool ChangeEmail(int instructorId, string newEmail);
    }
}
