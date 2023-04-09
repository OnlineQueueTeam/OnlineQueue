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
    public class DbHospitalPhysician : IRepository<DbHospitalPhysician>
    {
        public async Task AddAsync(DbHospitalPhysician obj)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "INSERT INTO hospital_physician (hospital_id,physician_id) VALUES (@HospitalId,@PhysicianId)";
            await connection.ExecuteAsync(query, obj);
        }

        public async Task AddRangeAsync(List<DbHospitalPhysician> obj)
        {
            foreach (DbHospitalPhysician item in obj)
            {
                await AddAsync(item);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "delete from hospital_physician where id=@Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<IEnumerable<DbHospitalPhysician>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select id as Id, hospital_id as HospitalId, physician_id as PhysicianId from hospital";
            return await connection.QueryAsync<DbHospitalPhysician>(query);
        }

        public async Task<DbHospitalPhysician> GetByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select id as Id, hospital_id as HospitalId, physician_id as PhysicianId from hospital where id=@Id";
            return await connection.QueryFirstOrDefault(query, new {Id=id});
        }

        public async Task<bool> UpdateAsync(DbHospitalPhysician entity)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "update hospital_physician set hospital_id = @HospitalId, phsician_id = @PhyscianId where id = @Id ";
            int res =  await connection.ExecuteAsync(query, entity);
            if(res > 0) return true;
            else return false;
        }
    }
}
