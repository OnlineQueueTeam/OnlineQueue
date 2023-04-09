using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.Interface
{
    public interface IPatientHandler
    {
        public Task<List<Patient>> GetAllPatientsAsync();
        public Task<Patient> GetByIdPatientAsync(int id);
        public Task<bool> UpdatePatientAsync(Category category);
        public Task<bool> DeletePatientByIdAsync(int id);
        public Task<bool> InsertPatientAsync(Category category);
    }
}
