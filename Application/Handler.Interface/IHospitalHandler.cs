using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.Interface
{
    public interface IHospitalHandler
    {
        public Task<List<Hospital>> GetAllHospitalsAsync();
        public Task<Hospital> GetByIdHospitalAsync(int id);
        public Task<bool> UpdateHospitalAsync(Hospital hospital);
        public Task<bool> DeleteHospitalByIdAsync(int id);
        public Task<bool> InsertHospitalAsync(Hospital hospital);
    
    }
}
