using Application.Handler.Interface;
using Application.Repository.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class WaitListHandler : IWaitListHandler
    {
        private readonly IWaitListRepository _categoryRepository;
        public WaitListHandler(IWaitListRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public async Task<bool> DeleteWaitListByIdAsync(int id)
        {
            try
            {
                return await _categoryRepository.DeleteByIdAsync(id);
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<WaitList>> GetAllWaitListsAsync()
        {
            try
            {
                return await _categoryRepository.GetAllAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<WaitList> GetByIdWaitListAsync(int id)
        {
            try
            {
                return await _categoryRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> InsertWaitListAsync(WaitList WaitList)
        {
            try
            {
                return await _categoryRepository.InsertAsync(WaitList);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> UpdateWaitListAsync(WaitList WaitList)
        {
            try
            {
                return await _categoryRepository.UpdateAsync(WaitList);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
