using Application.Repository.Interfaces;
using Dapper;
using Domain.Models;
using Npgsql;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace Infrastructure.Persistence
{
    public class DbHospitalPhysician : IHospitalPhysicianRepository
    {
        public async Task<bool> AddAsync(HospitalPhisician obj)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            
            string query = "INSERT INTO hospital_physician (hospital_id,physician_id) VALUES (@HospitalId,@PhysicianId)";
            int a=await connection.ExecuteAsync(query, new {HospitalId=obj.Hospital.Id, PhysicianId=obj.Physician.Id});
            return a> 0;
        }

       

        public async Task AddRangeAsync(List<HospitalPhisician> obj)
        {
            foreach (HospitalPhisician item in obj)
            {
                await AddAsync(item);
            }
        }

      

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "delete from hospital_physician where id=@Id";
           int res= await connection.ExecuteAsync(query, new { Id = id });
            return res > 0;
        }

        public async Task<IEnumerable<HospitalPhisician>> GetAllAsync()
        {
            List<HospitalPhisician> list = new();
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            
            string query = "select * from hospital";
            NpgsqlCommand cmd = new(query, connection);
            NpgsqlDataReader reader=cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new HospitalPhisician() {
                    Id = reader.GetInt32(0),
                    Hospital=await new DbHospital().GetByIdAsync(reader.GetInt32(1)),
                    Physician=await new DbPhysician().GetByIdAsync(reader.GetInt32(2))
                });
            }

            return list;
        }

        public async Task<HospitalPhisician> GetByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select id as Id, hospital_id as HospitalId, physician_id as PhysicianId from hospital where id=@Id";
            return await connection.QueryFirstOrDefault(query, new {Id=id});
        }

        public async Task<bool> UpdateAsync(HospitalPhisician entity)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "update hospital_physician set hospital_id = @HospitalId, phsician_id = @PhyscianId where id = @Id ";
            int res =  await connection.ExecuteAsync(query, new {Id=entity.Id,HospitalId=entity.Hospital.Id, PhysicianId=entity.Physician.Id });
            if(res > 0) return true;
            else return false;
        }

        
    }
}
