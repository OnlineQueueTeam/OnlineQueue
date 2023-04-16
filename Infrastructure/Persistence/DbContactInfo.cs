using Application.Repository.Interfaces;
using Dapper;
using Domain.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DbContactInfo : IRepository<ContactInfo>
    {
        public async Task<bool> InsertAsync(ContactInfo entity)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "INSERT INTO contact_info (hospital_id,address,location,phone_number,social_media) VALUES (@Id,@Address,@Location,@Phone,@Social)";
            int rowsAffected = await connection.ExecuteAsync(query, new { Id = entity.Hospital.Id, Address = entity.Address, Location = entity.Location, Phone = entity.PhoneNumber, Social = entity.SocialMedia });
            return rowsAffected > 0;
        }
        public async Task InsertRangeAsync(List<ContactInfo> entities)
        {
            foreach (ContactInfo info in entities)
            {
                await InsertAsync(info);
            }
        }
        public async  Task<bool> DeleteByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "delete from contact_info where contact_info_id=@Id";
            int rowseffected = await connection.ExecuteAsync(query, new { Id = id });
            return rowseffected > 0;
        }

        public async Task<List<ContactInfo>> GetAllAsync()
        {
            List<ContactInfo> list = new List<ContactInfo>();
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select *  from contact_info";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandText = query;
            cmd.Connection = connection;

            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ContactInfo()
                {
                    Id = reader.GetInt32(0),
                    Hospital = await new DbHospital().GetByIdAsync(reader.GetInt32(1)),
                    Address=reader.GetString(2),
                    Location= reader.GetString(3),
                    PhoneNumber=reader.GetString(4),
                    SocialMedia=reader.GetString(5)

                });
            }

            return list;
        }

        public async Task<ContactInfo> GetByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select *  from contact_info where contact_info=@Id";
            return await connection.QueryFirstOrDefaultAsync<ContactInfo>(query, new { Id = id });
        }

       

        public async Task<bool> UpdateAsync(ContactInfo entity)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "update contact_info set hospital_id = @hospitalId, address = @address, location=@location, phone_number=@phone,social_media=@social    from contact_info where contact_info=@Id";
            int res = await connection.ExecuteAsync(query, new { hospitalId = entity.Hospital.Id, address = entity.Address, location = entity.Location, phone=entity.PhoneNumber,social=entity.SocialMedia, Id=entity.Id });

            if (res > 0) return true;
            return false;
        }

    }
}
