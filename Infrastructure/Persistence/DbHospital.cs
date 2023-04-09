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
        public async Task<bool> InsertAsync(Hospital obj)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "INSERT INTO hospital (name,address,rating) VALUES (@HospitalName,@Address,@Rating)";
           return await connection.ExecuteAsync(query, obj) > 0;
        }


        public async Task<bool> DeleteByIdAsync(int Id)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "delete from hospital where id=@HospitalId";
            return await connection.ExecuteAsync(query, new { HospitalId=Id})>0;
        }

        public async Task<List<Hospital>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select id as HospitalId, name as HospitalName, address as Address, rating as Rating  from hospital";
            return  (await connection.QueryAsync<Hospital>(query)).ToList();
        }

        public async Task<Hospital> GetByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select id as HospitalId, name as HospitalName, address as Address, rating as Rating  from hospital where id=@HospitalId";
             return await connection.QueryFirstOrDefaultAsync<Hospital>(query);
        }

        public async Task<bool> UpdateAsync(Hospital entity)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "update hospital set name = @HospitalName, address = @Address, rating = @Rating  from hospital where id=@HospitalId";
            int res =  await connection.ExecuteAsync(query,entity);
            if(res > 0) return true;
            return false;
        }
    }
}
