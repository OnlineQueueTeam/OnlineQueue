using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.Interface
{
    public interface IHospitalPhysicianHandler
    {
        public Task<List<HospitalPhysician>> GetAllHospitalPhysicianAsync();
        public Task<HospitalPhysician> GetByIdHospitalPhysicianAsync(int id);
        public Task<bool> UpdateHospitalPhysicianAsync(HospitalPhysician hospitalPhysician);
        public Task<bool> DeleteHospitalPhysicianByIdAsync(int id);
        public Task<bool> InsertHospitalPhysicianAsync(HospitalPhysician hospitalPhysician);
    }
}
