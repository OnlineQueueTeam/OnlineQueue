using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.Interface
{
    public interface IPhysicianHandler
    {
        public Task<List<Physician>> GetAllPhysiciansAsync();
        public Task<Physician> GetByIdPhysicianAsync(int id);
        public Task<bool> UpdatePhysicianAsync(Physician physician);
        public Task<bool> DeletePhysicianByIdAsync(int id);
        public Task<bool> InsertPhysicianAsync(Physician physician);
    }
}
