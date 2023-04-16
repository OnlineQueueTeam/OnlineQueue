using Application.Repository.Interfaces;
using Dapper;
using Domain.Models;
using Domain.States;
using Npgsql;
using Npgsql.Internal.TypeHandling;
using System.Diagnostics;
using System.Xml.Linq;

namespace Infrastructure.Persistence
{
    public class DbHospital : IHospitalRepository
    {

        public async Task<bool> InsertAsync(Hospital obj)
        {
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = new NpgsqlConnection(DbContext.conString);
                cmd.Connection.Open();
                cmd.CommandText = "INSERT INTO hospital (name, rating) VALUES (@Name, @HospitalRating)";

                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@HospitalRating", obj.HospitalRating.ToString());

                return await cmd.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task InsertRangeAsync(List<Hospital> obj)
        {
            foreach (Hospital item in obj)
            {
              await  InsertAsync(item);
            }
        }

        public async Task<bool> DeleteByIdAsync(int id) 
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "delete from hospital where hospital_id=@Id";
            int rowseffected =await connection.ExecuteAsync(query, new { Id=id});
            return rowseffected > 0;
        }

        public async Task<List<Hospital>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select hospital_id as Id, name as Name, rating as HospitalRating  from hospital";
            return  (await connection.QueryAsync<Hospital>(query)).ToList();
        }

        public async Task<Hospital> GetByIdAsync(int id)
        {
            using NpgsqlConnection connection = new(DbContext.conString);
            await connection.OpenAsync();
            string cmdText = @"select * from hospital where hospital_id=@id";
            using NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                Hospital hospital = new()
                {
                    Id = (int)reader["hospital_id"],
                    Name = reader["name"]?.ToString(),
                    HospitalRating = Enum.Parse<HospitalRating>(reader["rating"]?.ToString()),
                };
                return hospital;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Hospital entity)
        {
            using NpgsqlConnection connection = new(DbContext.conString);
            connection.Open();
            string cmdText = @"update hospital set name = @Name, rating = @HospitalRating  from hospital where hospital_id = @Id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@HospitalRating", entity.HospitalRating.ToString());
            return await cmd.ExecuteNonQueryAsync() > 0;
        }
       



    }
}
