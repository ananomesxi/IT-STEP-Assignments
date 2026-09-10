using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UniversityDomain.Interfaces;
using UniversityDomain.Models;

namespace UniversityInfrastructure.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly string _connectionString;
        public InstructorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Instructor> GetAllInstructors()
        {
            List<Instructor> instructors = new List<Instructor>();
            string query = "SELECT * FROM Instructors";
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                instructors.Add(MapInstructor(reader));
            }
            return instructors;
        }

        public Instructor GetById(int id)
        {
            string query = "SELECT * FROM Instructors where InstructorId = @Id";
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return MapInstructor(reader);
            }
            return null;
        }

        public bool AddInstructor(Instructor instructor)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("dbo.SP_InsertIntoInstructors", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@firstName", instructor.FirstName);
            command.Parameters.AddWithValue("@lastName", instructor.LastName);
            command.Parameters.AddWithValue("@email", instructor.Email);

            connection.Open();
            return command.ExecuteNonQuery() > 0;

        }

        public bool DeleteInstructor(int instructorId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("dbo.SP_DeleteInstructor", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", instructorId);
            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public bool ChangeEmail(int instructorId, string newEmail)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("dbo.SP_ChangeEmail", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", instructorId);
            command.Parameters.AddWithValue("@newEmail", newEmail);
            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        private Instructor MapInstructor(SqlDataReader reader)
        {
            return new Instructor()
            {
                InstructorId = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Email = reader.GetString(3)
            };
        }


    }
}
