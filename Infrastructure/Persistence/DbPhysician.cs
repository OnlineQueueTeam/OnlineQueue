using Application.Repository.Interfaces;
using Dapper;
using Domain.Models;
using Infrastructure.Connection;
using Npgsql;

namespace Infrastructure.Persistence
{
    public class DbPhysician : IPhysicianRepository
    {
        private readonly string? conString = GetConnection.Connection();
        public async Task<bool> InsertAsync(Physician obj)
        {
            using NpgsqlConnection connection = new(conString);
            connection.Open();
            string cmdText = @$"insert into physician(category_id,first_name, last_name,phone_number,experience_year,rating) 
                    values (@CategoryId ,@FirstName, @LastName,@PhoneNumber,@ExperienceYear,@Rating)";
            return await connection.ExecuteAsync(cmdText, obj) > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            using NpgsqlConnection connection = new(conString);
            connection.Open();
            string cmdText = @"delete from physician where physician_id=@Id";
            int rowsAffected = await connection.ExecuteAsync(cmdText, new { Id = id });
            return rowsAffected > 0;
        }

        public async Task<List<Physician>> GetAllAsync()
        {
            using NpgsqlConnection connection = new NpgsqlConnection(conString);
            string cmdText = "SELECT physician_id PhysicianId, category_id CategoryId, first_name FirstName, last_name LastName, phone_number PhoneNumber, experience_year ExperienceYear, rating Rating FROM physician";
            List<Physician> myTableData = (List<Physician>)await connection.QueryAsync<Physician>(cmdText);

            return myTableData;
        }

        public async Task<Physician> GetByIdAsync(int id)
        {
            using NpgsqlConnection connection = new(conString);
            connection.Open();
            string cmdText = @"SELECT physician_id PhysicianId, category_id CategoryId, first_name FirstName, last_name LastName, phone_number PhoneNumber, experience_year ExperienceYear, rating Rating FROM physician where physician_id = @Id";
            return await connection.QueryFirstAsync<Physician>(cmdText, new {Id = id});
        }

        public async Task<bool> UpdateAsync(Physician entity)
        {
            string cmdText = @"update physician set  category_id = @CategoryId,first_name = @FirstName, last_name = @LastName,phone_number = @PhoneNumber,experience_year=@ExperienceYear,rating=@Rating where physician_id=@Id
                   ";

            using NpgsqlConnection connection = new NpgsqlConnection(conString);
            connection.Open();
            int rowsAffected = await connection.ExecuteAsync(cmdText, entity);
            if (rowsAffected > 0) return true;
            return false;
        }
    }
}
