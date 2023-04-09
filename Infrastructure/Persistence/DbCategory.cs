using Application.Repository.Interfaces;
using Dapper;
using Domain.Models;
using Npgsql;

namespace Infrastructure.Persistence
{
    public class DbCategory : ICategoryRepository
    {
        public async Task<bool> InsertAsync(Category category)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "INSERT INTO category (category_name) VALUES (@CategoryName)";
            int rowsAffected = await connection.ExecuteAsync(query, category);
            return rowsAffected > 0;
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "SELECT category_id CategoryId, category_name CategoryName FROM category WHERE category_id = @CategoryId";
            return await connection.QueryFirstOrDefaultAsync<Category>(query, new { CategoryId = categoryId });
        }

        public async Task<List<Category>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "SELECT category_id CategoryId, category_name CategoryName FROM category";
            List<Category> list = (await connection.QueryAsync<Category>(query)).ToList();
            return list;
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "UPDATE category SET category_name = @CategoryName WHERE category_id = @CategoryId";
            int rowsAffected = await connection.ExecuteAsync(query, category);
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "DELETE FROM category WHERE category_id = @CategoryId";
            int rowsAffected = await connection.ExecuteAsync(query, new { CategoryId = id });
            return rowsAffected > 0;

        }
    }
}
