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
    public class DbServing : IRepository<Serving>
    {
      
        public async Task AddAsync(Serving obj)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbContext.conString))
            {
                connection.Open();

                int res = await connection.ExecuteAsync("insert into serving(patient_id, physician_id,served_time) values (@PatientId,@PhysicianId,@ServedTime)", obj);


            }
        }

        public async Task AddRangeAsync(List<Serving> obj)
        {
            foreach (Serving serving in obj)
            {
                await AddAsync(serving);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbContext.conString))
            {
                connection.Open();

                int rowsDeleted = await connection.ExecuteAsync("delete from serving where id=@Id", new { Id = id });

            }
        }

        public async Task<IEnumerable<Serving>> GetAllAsync()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbContext.conString))
            {
                connection.Open();

                var list = await connection.QueryAsync<Serving>("select id Id, patient_id PatientId, phisician_id PhisicianId, served_time ServedTime from serving");

                return list;
            }
        }

        public async Task<Serving> GetByIdAsync(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbContext.conString))
            {
                connection.Open();

                var result = await connection.QueryFirstAsync<Serving>("select id Id, patient_id PatientId, phisician_id PhisicianId, served_time ServedTime from serving where id=@Id", new { Id = id });
                return result;
            }
        }

        public async Task<bool> UpdateAsync(Serving entity)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbContext.conString))
            {
                connection.Open();

                int res = await connection.ExecuteAsync("update serving set patient_id=@PatientId,phisician_id=@PhisicianId where id=@Id", entity);

                return res > 0;
            }
        }
    }
}
