using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UniversityDomain.Interfaces;
using UniversityDomain.Models;

namespace UniversityInfrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;
        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            var query = "SELECT * FROM Students";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    students.Add(MapStudent(reader));
                }
            }
            return students;
        }
        public Student GetById(int id)
        {
            var query = "SELECT * FROM Students where Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return MapStudent(reader);
            }
            return null;
        }

        public bool Add(Student student)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("dbo.SP_InsertIntoStudents", connection); // changed text version to procedure version 
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@FirstName", student.FirstName);
            command.Parameters.AddWithValue("@LastName", student.LastName);
            command.Parameters.AddWithValue("@Email", student.Email);
            command.Parameters.AddWithValue("@Age", student.Age);
            command.Parameters.AddWithValue("@GPA", student.GPA);
            command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
            command.Parameters.AddWithValue("@DepartmentID", student.DepartmentID);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }
        public bool ChangeGPA(int studentId, decimal newGpa)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("dbo.SP_ChangeGPA", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", studentId);
            command.Parameters.AddWithValue("@newGPA", newGpa);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }
        public bool DeleteStudent(int studentId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("dbo.SP_DeleteStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", studentId);
            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }
        private Student MapStudent(SqlDataReader reader)
        {
            return new Student()
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Email = reader.GetString(3),
                Age = reader.GetInt32(4),
                GPA = reader.IsDBNull(5) ? null : reader.GetDecimal(5),
                PhoneNumber = reader.IsDBNull(6) ? null : reader.GetString(6),
                IsActive = reader.IsDBNull(7) ? null : reader.GetBoolean(7),
                RegisteredAt = reader.IsDBNull(8) ? null : reader.GetDateTime(8),
                DepartmentID = reader.IsDBNull(9) ? null : reader.GetInt32(9)
            };
        }


    }
}
