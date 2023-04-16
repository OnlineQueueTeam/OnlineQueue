using Application.Repository.Interfaces;
using Dapper;
using Domain.Models;
using Npgsql;

namespace Infrastructure.Persistence
{
    public class DbHospitalPhysician : IHospitalPhysicianRepository
    {
        public async Task<bool> InsertAsync(HospitalPhysician obj)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            
            string query = "INSERT INTO hospital_physician (hospital_id,physician_id) VALUES (@HospitalId,@PhysicianId)";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@HospitalId", obj.Hospital.Id);
            command.Parameters.AddWithValue("@PhysicianId", obj.Physician.Id);
            return await command.ExecuteNonQueryAsync() > 0;
        }

       

        public async Task InsertRangeAsync(List<HospitalPhysician> obj)
        {
            foreach (HospitalPhysician item in obj)
            {
                await InsertAsync(item);
            }
        }                                                                                    

      

        public async Task<bool> DeleteByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "delete from hospital_physician where id=@Id";
           int res= await connection.ExecuteAsync(query, new { Id = id });
            return res > 0;
        }

        public async Task<List<HospitalPhysician>> GetAllAsync()
        {
            List<HospitalPhysician> list = new();
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            
            string query = "select * from hospital";
            NpgsqlCommand cmd = new(query, connection);
            NpgsqlDataReader reader=cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new HospitalPhysician() {
                    Id = reader.GetInt32(0),
                    Hospital=await new DbHospital().GetByIdAsync(reader.GetInt32(1)),
                    Physician=await new DbPhysician().GetByIdAsync(reader.GetInt32(2))
                });
            }

            return list;
        }

        public async Task<HospitalPhysician> GetByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(DbContext.conString);
            await connection.OpenAsync();
            string query = "select id as Id, hospital_id as HospitalId, physician_id as PhysicianId from hospital where id=@Id";
            return await connection.QueryFirstOrDefault(query, new {Id=id});
        }

        public async Task<bool> UpdateAsync(HospitalPhysician entity)
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
