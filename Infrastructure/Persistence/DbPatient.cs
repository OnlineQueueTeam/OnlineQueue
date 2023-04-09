using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using System.Runtime.CompilerServices;
using Infrastructure.Connection;
using Application.Repository.Interfaces;

namespace Infrastructure.Persistence
{
    public class DbPatient : IPatientRepository
    {
        private readonly string? conString = GetConnection.Connection();
        public async Task<bool> InsertAsync(Patient obj)
        {
            
            NpgsqlConnection connection = new NpgsqlConnection(conString);
            connection.Open();
          
            string query = "Insert into patient(first_name, last_name, phone_number) values(@FirstName, @LastName, @PhoneNumber)";
           return await connection.ExecuteAsync(query, obj) > 0;
            
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(conString))
            {
                return await connection.ExecuteAsync("DELETE FROM patient WHERE patient_id = @PatientId", new { PatientId = id }) > 0;
                    
            }
        }

        public async Task<List<Patient>> GetAllAsync()
        {

            using (var connection = new NpgsqlConnection(conString))
            {
                await connection.OpenAsync();
                var list =  (await connection.QueryAsync<Patient>("SELECT patient_id as PatientId, first_name as FirstName, last_name as LastName, phone_number as PhoneNumber from patient")).ToList();
                return list;
            }
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(conString);
            await connection.OpenAsync();
            string query = "SELECT patient_id as PatientId, first_name as FirstName, last_name as LastName, phone_number as PhoneNumber from patient WHERE patient_id = @PatientId";
            return await connection.QueryFirstOrDefaultAsync<Patient>(query, new { PatientId = id });
        }

        public async Task<bool> UpdateAsync(Patient entity)
        {
            using (var connection = new NpgsqlConnection(conString))
            {
                var rowsAffected = await connection.ExecuteAsync(
                    "UPDATE patient SET first_name = @FirstName, last_name = @LastName, phone_number = @PhoneNumber WHERE patient_id = @PatientId",
                    entity
                );

                return rowsAffected > 0;
            }
        }
    }
}
