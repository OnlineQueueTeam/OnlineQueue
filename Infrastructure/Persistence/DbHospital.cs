using Application.Repository.Interfaces;
using Dapper;
using Domain.Models;
using Domain.States;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DbHospital : IHospitalRepository
    {

        public async Task<bool> InsertAsync(Hospital obj)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "INSERT INTO hospital (name,contact_info_id,rating) VALUES (@Name,@Id,@Rating)";
           int rowsAffected= await connection.ExecuteAsync(query, new { Name=obj.Name,Id=obj.ContactInfo.Id,Rating=obj.Rating});
            return rowsAffected > 0;
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
            List<Hospital> list = new List<Hospital>();
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select *  from hospital";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandText = query;
            cmd.Connection=connection;

            NpgsqlDataReader reader=cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Hospital()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    ContactInfo = await new DbContactInfo().GetByIdAsync(reader.GetInt32(2)),
                    Rating = (RatingHospital)Enum.Parse(typeof(RatingHospital), reader[3].ToString())
                });
            }

            return list;


            




            return  (await connection.QueryAsync<Hospital>(query)).ToList();
        }

        public async Task<Hospital> GetByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select *  from hospital where hospital_id=@Id";
             return await connection.QueryFirstOrDefaultAsync<Hospital>(query, new {Id=id});
        }

        public async Task<bool> UpdateAsync(Hospital entity)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "update hospital set name = @Name, contact_info_id = @info_id, rating=@rating   from hospital where hospital_id=@Id";
            int res =  await connection.ExecuteAsync(query, new {Name=entity.Name, info_id=entity.ContactInfo.Id,Id=entity.Id,rating=entity.Rating});

            if(res > 0) return true;
            return false;
        }

      
    }
}
