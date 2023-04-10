using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.Interface
{
    public interface IServingStatementHandler
    {
        public Task<List<ServingStatement>> GetAllServingStatementAsync();
        public Task<ServingStatement> GetByIdServingStatementAsync(int id);
        public Task<bool> UpdateServingStatementAsync(ServingStatement servingStatement);
        public Task<bool> DeleteServingStatementByIdAsync(int id);
        public Task<bool> InsertServingStatementAsync(ServingStatement servingStatement);
    }
}
