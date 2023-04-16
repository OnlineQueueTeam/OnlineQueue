using Application.Repository.Interfaces;
using Dapper;
using Domain.Models;
using Domain.States;
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
                    values (@CategoryId,@FirstName, @LastName,@PhoneNumber,@ExperienceYear,@Rating)";
           
            int rowsAffected=await connection.ExecuteAsync(cmdText, new {CategoryId=obj.Category.CategoryId,
                                                         FirstName=obj.FirstName,
                                                         LastName=obj.LastName,
                                                         PhoneNumber=obj.PhoneNumber,
                                                         ExperienceYear=obj.ExperienceYear,
                                                         Rating=obj.Rating.ToString(),
             });;

            return rowsAffected > 0;
        }



        public async Task InsertRangeAsync(List<Physician> obj)
        {
            foreach (Physician Physician in obj)
            {
                await InsertAsync(Physician);
            }
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
            List<Physician> result = new();
            using NpgsqlConnection connection = new NpgsqlConnection(conString);
            connection.Open();
            string cmdText = "SELECT * FROM physician";
            NpgsqlCommand cmd=new NpgsqlCommand(cmdText, connection);
            NpgsqlDataReader reader= cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add( new Physician()
                {
                    Id = reader.GetInt32(0),
                    Category=await new DbCategory().GetByIdAsync((int)reader["category_id"]),
                    FirstName = reader["first_name"].ToString(),
                    LastName = reader["last_name"].ToString(),
                    PhoneNumber = reader["phone_number"].ToString(),
                    ExperienceYear = (double)reader["experience_year"],
                    Rating = Enum.Parse<PhysicianRating>( reader["rating"].ToString())


                }

                    );
            }

            return result;
        }

        public async Task<Physician> GetByIdAsync(int id)
        {
            using NpgsqlConnection connection = new(conString);
            connection.Open();
            string cmdText = @"SELECT * FROM physician where physician_id = @Id";
            NpgsqlCommand command = new NpgsqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("@Id" , id);
            NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                Physician physician = new()
                {
                    Id = (int)reader["physician_id"],
                    Category = await new DbCategory().GetByIdAsync((int)reader["category_id"]),
                    ExperienceYear = (double)reader["experience_year"],
                    FirstName = reader["first_name"].ToString(),
                    LastName = reader["last_name"].ToString(),
                    PhoneNumber = reader["phone_number"].ToString(),
                    Rating = Enum.Parse<PhysicianRating>(reader["rating"].ToString()),

                };
                return physician;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Physician entity)
        {
            string cmdText = @"update physician set  category_id = @CategoryId,first_name = @FirstName, last_name = @LastName,phone_number = @PhoneNumber,experience_year=@ExperienceYear,rating=@Rating where physician_id=@Id
                   ";

            using NpgsqlConnection connection = new NpgsqlConnection(conString);
            connection.Open();
            int rowsAffected = await connection.ExecuteAsync(cmdText, new {
                                                                           Id = entity.Id,
                                                                           CategoryId=entity.Category.CategoryId,
                                                                           FirstName=entity.FirstName,
                                                                           LastName=entity.LastName,
                                                                           PhoneNumber=entity.PhoneNumber,
                                                                           ExperienceYear=entity.ExperienceYear,
                                                                           Rating=entity.Rating
            });
            if (rowsAffected > 0) return true;
            return false;
        }
    }
}
