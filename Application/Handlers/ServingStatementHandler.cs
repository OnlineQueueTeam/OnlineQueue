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
    public class ServingStatementHandler : IServingStatementHandler
    {
        private readonly IServingStatementRepository _categoryRepository;
        public ServingStatementHandler(IServingStatementRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public async Task<bool> DeleteServingStatementByIdAsync(int id)
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

        public async Task<List<ServingStatement>> GetAllServingStatementAsync()
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

        
        public async Task<ServingStatement> GetByIdServingStatementAsync(int id)
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

        public async Task<bool> InsertServingStatementAsync(ServingStatement ServingStatement)
        {
            try
            {
                return await _categoryRepository.InsertAsync(ServingStatement);
            }
            catch (Exception)
            {
                return false;
            }
        }   

        public async Task<bool> UpdateServingStatementAsync(ServingStatement ServingStatement)
        {
            try
            {
                return await _categoryRepository.UpdateAsync(ServingStatement);
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}
