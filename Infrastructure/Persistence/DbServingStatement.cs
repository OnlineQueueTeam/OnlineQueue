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
    public class DbServingStatement : IServingStatementRepository
    {
        private readonly string? conString = GetConnection.Connection();
        public async Task<bool> InsertAsync(ServingStatement obj)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                int res = await connection.ExecuteAsync("insert into serving(patient_id, physician_id,served_time) values (@PatientId,@PhysicianId,@ServedTime)", obj);
                return res > 0;

            }
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                int rowsDeleted = await connection.ExecuteAsync("delete from serving where id=@Id", new { Id = id });
                return rowsDeleted > 0;

            }
        }

        public async Task<List<ServingStatement>> GetAllAsync()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                var list = (await connection.QueryAsync<ServingStatement>("select id Id, patient_id PatientId, phisician_id PhisicianId, served_time ServedTime from serving")).ToList();

                return list;
            }
        }

        public async Task<ServingStatement> GetByIdAsync(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                var result = await connection.QueryFirstAsync<ServingStatement>("select id Id, patient_id PatientId, phisician_id PhisicianId, served_time ServedTime from serving where id=@Id", new { Id = id });
                return result;
            }
        }

        public async Task<bool> UpdateAsync(ServingStatement entity)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                int res = await connection.ExecuteAsync("update serving set patient_id=@PatientId,phisician_id=@PhisicianId where id=@Id", entity);

                return res > 0;
            }
        }
    }
}
