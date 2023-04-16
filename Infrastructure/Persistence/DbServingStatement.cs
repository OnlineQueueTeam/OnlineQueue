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

                int res = await connection.ExecuteAsync("insert into serving_statement(patient_id, physician_id,end_time) values (@PatientId,@PhysicianId,@end_time)", new {PatientId=obj.Patient.PatientId,PhysicianId=obj.Physician.Id,end_time=obj.EndTime });

                return res > 0;
            }
        }

        public async Task InsertRangeAsync(List<ServingStatement> obj)
        {
            foreach (ServingStatement serving in obj)
            {
                await InsertAsync(serving);
            }
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                int rowsDeleted = await connection.ExecuteAsync("delete from serving_statement where id=@Id", new { Id = id });
                return rowsDeleted > 0;
            }
        }

        public async Task<List<ServingStatement>> GetAllAsync()
        {
            List<ServingStatement> list = new List<ServingStatement>();

            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.CommandText = "select * from serving_statement";
                cmd.Connection=connection;
                NpgsqlDataReader reader= cmd.ExecuteReader();

                while(reader.Read())
                {
                    list.Add(new ServingStatement()
                    {
                        Id=reader.GetInt32(0),
                        Patient=await new DbPatient().GetByIdAsync(reader.GetInt32(1)),
                        Physician=await new DbPhysician().GetByIdAsync(reader.GetInt32(2)),
                        StartTime=reader.GetDateTime(3),
                        EndTime=reader.GetDateTime(4)
                    });
                }
                return list;
            }
        }

        public async Task<ServingStatement> GetByIdAsync(int id)
        {
            ServingStatement servingStatement = null;
            using NpgsqlConnection connection= new NpgsqlConnection(conString);
            connection.Open();
            string cmdText = @"select * from serving_statement where id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);
            NpgsqlDataReader reader= await cmd.ExecuteReaderAsync();
            while(reader.Read())
            {
                servingStatement = new()
                {
                    Id = (int)reader["id"],
                    Patient = await new DbPatient().GetByIdAsync((int)reader["patient_id"]),
                    Physician = await new DbPhysician().GetByIdAsync((int)reader["physician_id"]),
                    StartTime = (DateTime)reader["start_time"],
                    EndTime = (DateTime)reader["end_time"]
                };
            }
            return servingStatement;
        }

        public async Task<bool> UpdateAsync(ServingStatement entity)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString))
            {
                connection.Open();

                int res = await connection.ExecuteAsync("update serving_statement set patient_id=@PatientId,physician_id=@PhysicianId, start_time=@StartTime, end_time=@EndTime where id=@Id", new
                {
                    Id=entity.Id,
                    PatientId=entity.Patient.PatientId,
                    PhysicianId=entity.Physician.Id,
                    StartTime=entity.StartTime,
                    EndTime=entity.EndTime
                });

                return res > 0;
            }
        }
    }
}
