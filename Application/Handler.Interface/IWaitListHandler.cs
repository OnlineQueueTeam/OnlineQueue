using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.Interface
{
    public interface IWaitListHandler
    {
        public Task<List<WaitList>> GetAllWaitListsAsync();
        public Task<WaitList> GetByIdWaitListAsync(int id);
        public Task<bool> UpdateWaitListAsync(WaitList waitList);
        public Task<bool> DeleteWaitListByIdAsync(int id);
        public Task<bool> InsertWaitListAsync(WaitList waitList);
    }
}

