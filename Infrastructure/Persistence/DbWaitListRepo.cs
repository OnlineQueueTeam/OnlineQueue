using Application.Repository.Interfaces;
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
    public class DbWaitListRepo : IWaitListRepository
    {

        private readonly string? conString = GetConnection.Connection();
        public async Task<bool> InsertAsync(WaitList obj)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                int rowsAffected = await connection.ExecuteAsync("insert into wait_list(patient_id, physician_id) values (@PatientId,@PhysicianId)", new {PatientId=obj.Patient.PatientId,PhysicianId=obj.Physician.Id});

                return rowsAffected > 0;
            }
        }

        public async Task InsertRangeAsync(List<WaitList> obj)
        {
            foreach (WaitList waitlist in obj)
            {
                await InsertAsync(waitlist);
            }
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            int rowsAffected = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                 rowsAffected=await connection.ExecuteAsync("delete from wait_list where id=@Id", new { Id = id });

            }
            return rowsAffected > 0;
        }

        public async Task<bool> UpdateAsync(WaitList entity)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                int res = await connection.ExecuteAsync("update wait_list set patient_id=@PatientId,physician_id=@PhysicianId where id=@Id", new
                {
                    Id=entity.Id,
                    PatientId=entity.Patient.PatientId,
                    PhysicianId=entity.Physician.Id

                });
                if (res > 0)
                    return true;
                return false;
            }
        }
        public async Task<List<WaitList>> GetAllAsync()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                List<WaitList> list = new List<WaitList>();
                connection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.CommandText = "select * from wait_list";
                cmd.Connection=connection;

                NpgsqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    list.Add(new WaitList()
                    {
                        Id = (int)reader["id"],
                        Physician=await new DbPhysician().GetByIdAsync((int)reader["physician_id"]),
                        Patient=await new DbPatient().GetByIdAsync((int)reader["patient_id"]),
                        JoinedTime=reader.GetDateTime(3)
                    }) ;
                }

                return list;
            }
        }

        public async Task<WaitList> GetByIdAsync(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                var result = await connection.QueryFirstAsync<WaitList>("select * from wait_list where id=@Id", new { Id = id });
                return result;
            }
        }

    }
}
