using Dapper;
using Domain.Models;
using Infrastructure.Connection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DbCategory:IRepository<Category>
    {
        private readonly string? conString = GetConnection.Connection();
        public async Task AddAsync(Category category)
        {
            using var connection = new NpgsqlConnection(conString);
            await connection.OpenAsync();
            string query = "INSERT INTO category (category_name) VALUES (@CategoryName)";
            await connection.ExecuteAsync(query, category);
        }
        public async Task AddRangeAsync(List<Category> categories)
        {
            using var connection = new NpgsqlConnection(conString);
            await connection.OpenAsync();
            string query = "INSERT INTO category (category_name) VALUES (@CategoryName)";
            await connection.ExecuteAsync(query, categories);
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            using var connection = new NpgsqlConnection(conString);
            await connection.OpenAsync();
            string query = "SELECT category_id CategoryId, category_name CategoryName FROM category WHERE category_id = @CategoryId";
            return await connection.QueryFirstOrDefaultAsync<Category>(query, new { CategoryId = categoryId });
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(conString);
            await connection.OpenAsync();
            string query = "SELECT category_id CategoryId, category_name CategoryName FROM category";
            return await connection.QueryAsync<Category>(query);
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            using var connection = new NpgsqlConnection(conString);
            await connection.OpenAsync();
            string query = "UPDATE category SET category_name = @CategoryName WHERE category_id = @CategoryId";
            int rowsAffected = await connection.ExecuteAsync(query, category);
            return rowsAffected > 0;
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(conString);
            await connection.OpenAsync();
            string query = "DELETE FROM category WHERE category_id = @CategoryId";
             await connection.ExecuteAsync(query, new { CategoryId = id });
            
        }

        
    }
}
