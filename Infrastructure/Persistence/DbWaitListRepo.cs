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
    public class DbWaitListRepo : IRepository<WaitList>
    {

        private readonly string? conString = GetConnection.Connection();
        public async Task AddAsync(WaitList obj)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                int res = await connection.ExecuteAsync("insert into wait_list(patient_id, physician_id) values (@PatientId,@PhysicianId)", obj);


            }
        }

        public async Task AddRangeAsync(List<WaitList> obj)
        {
            foreach (WaitList waitlist in obj)
            {
                await AddAsync(waitlist);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                await connection.ExecuteAsync("delete from wait_list where id=@Id", new { Id = id });

            }
        }

        public async Task<bool> UpdateAsync(WaitList entity)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                int res = await connection.ExecuteAsync("update wait_list set patient_id=@PatientId,physician_id=@PhisicianId where id=@Id", entity);
                if (res > 0)
                    return true;
                return false;
            }
        }
        public async Task<IEnumerable<WaitList>> GetAllAsync()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                var list = await connection.QueryAsync<WaitList>("select id Id, patient_id PatientId, physician_id PhysicianId, joined_time JoinedTime from wait_list");

                return list;
            }
        }

        public async Task<WaitList> GetByIdAsync(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                var result = await connection.QueryFirstAsync<WaitList>("select id Id, patient_id PatientId, physician_id PhysicianId, joined_time JoinedTime from wait_list where id=@Id", new { Id = id });
                return result;
            }
        }

    }
}
