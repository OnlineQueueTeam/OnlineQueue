using Application.Repository.Interfaces;
using Dapper;
using Domain.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DbHospital : IHospitalRepository
    {

        public async Task<bool> AddAsync(Hospital obj)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "INSERT INTO hospital (name,address) VALUES (@Name,@Address)";
           int rowsAffected= await connection.ExecuteAsync(query, obj);
            return rowsAffected > 0;
        }

        public async Task AddRangeAsync(List<Hospital> obj)
        {
            foreach (Hospital item in obj)
            {
              await  AddAsync(item);
            }
        }

        public async Task<bool> DeleteAsync(int id) 
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "delete from hospital where hospital_id=@Id";
            int a=await connection.ExecuteAsync(query, new { Id=id});
            return a > 0;
        }

        public async Task<IEnumerable<Hospital>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select hospital_id as Id, name as Name, address as Address  from hospital";
            return  await connection.QueryAsync<Hospital>(query);
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
