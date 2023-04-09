using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQueue.Infrastructure.Handler.Interfaces
{
    public interface IPhysicianHandler
    {
        public Task<List<Physician>> GetAllPhysiciansAsync();
        public Task<Category> GetByIdPhysicianAsync(int id);
        public Task<bool> UpdatePhyssicianAsync(Category category);
        public Task<bool> DeletePhysicianByIdAsync(int id);
        public Task<bool> InsertPhysicianAsync(Category category);
    }
}
