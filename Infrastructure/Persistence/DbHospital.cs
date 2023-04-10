using Application.Repository.Interfaces;
using Dapper;
using Domain.Models;
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
            string query = "INSERT INTO hospital (name,address) VALUES (@Name,@Address)";
           int rowsAffected= await connection.ExecuteAsync(query, obj);
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
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select hospital_id as Id, name as Name, address as Address  from hospital";
            return  (await connection.QueryAsync<Hospital>(query)).ToList();
        }

        public async Task<Hospital> GetByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select hospital_id as Id, name as Name, address as Address  from hospital where hospital_id=@Id";
             return await connection.QueryFirstOrDefaultAsync<Hospital>(query);
        }

        public async Task<bool> UpdateAsync(Hospital entity)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "update hospital set name = @Name, address = @Address  from hospital where hospital_id=@Id";
            int res =  await connection.ExecuteAsync(query,entity);
            if(res > 0) return true;
            return false;
        }

      
    }
}
