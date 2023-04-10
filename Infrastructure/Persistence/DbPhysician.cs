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
        public async Task<bool> AddAsync(Physician obj)
        {
            using NpgsqlConnection connection = new(conString);
            connection.Open();
            string cmdText = @$"insert into physician(category_id,hospital_id,first_name, last_name,phone_number,experience_year,rating) 
                    values (@CategoryId , @HospitalId,@FirstName, @LastName,@PhoneNumber,@ExperienceYear,@Rating)";
           
            int rowsAffected=await connection.ExecuteAsync(cmdText, new {CategoryId=obj.Category.CategoryId,
                                                         HospitalId=obj.Hospital.Id,
                                                         FirstName=obj.FirstName,
                                                         LastName=obj.LastName,
                                                         PhoneNumber=obj.PhoneNumber,
                                                         ExperienceYear=obj.ExperienceYear,
                                                         Rating=obj.Rating
             });

            return rowsAffected > 0;
        }



        public async Task AddRangeAsync(List<Physician> obj)
        {
            foreach (Physician Physician in obj)
            {
                await AddAsync(Physician);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using NpgsqlConnection connection = new(conString);
            connection.Open();
            string cmdText = @"delete from physician where physician_id=@Id";
            int rowsAffected = await connection.ExecuteAsync(cmdText, new { Id = id });
            return rowsAffected > 0;
        }

        public async Task<IEnumerable<Physician>> GetAllAsync()
        {
            List<Physician> result = new();
            using NpgsqlConnection connection = new NpgsqlConnection(conString);
            string cmdText = "SELECT * FROM physician";
            NpgsqlCommand cmd=new NpgsqlCommand(cmdText, connection);
            NpgsqlDataReader reader= cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add( new Physician()
                {
                    Id = reader.GetInt32(0),
                    Category=await new DbCategory().GetByIdAsync((int)reader["category_id"]),
                    Hospital=await new DbHospital().GetByIdAsync((int)reader["hospital_id"]),
                    FirstName = reader["first_name"].ToString()?? "Undefined",
                    LastName = reader["last_name"].ToString(),
                    PhoneNumber = reader["phone_number"].ToString() ?? "Undefined",
                    ExperienceYear = (int)reader["experience_year"],
                    Rating = (Rating)Enum.Parse(typeof(Rating), reader["rating"].ToString())


                }

                    );
            }

            return result;
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
            string cmdText = @"update physician set  category_id = @CategoryId,hospital_id=@HospitalId,first_name = @FirstName, last_name = @LastName,phone_number = @PhoneNumber,experience_year=@ExperienceYear,rating=@Rating where physician_id=@Id
                   ";

            using NpgsqlConnection connection = new NpgsqlConnection(conString);
            connection.Open();
            int rowsAffected = await connection.ExecuteAsync(cmdText, new {
                                                                           Id = entity.Id,
                                                                           CategoryId=entity.Category.CategoryId,
                                                                           HospitalId=entity.Hospital.Id,
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
