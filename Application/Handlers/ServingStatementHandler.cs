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
            if (await _categoryRepository.DeleteByIdAsync(id))
            {
                Console.WriteLine("Successfully deleted");
                return true;
            }
            else
            {
                try
                {

                    Console.WriteLine("Operation failed");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
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
            if (await _categoryRepository.InsertAsync(ServingStatement))
            {
                Console.WriteLine("Successfully Inserted");
                return true;
            }
            else
            {
                try
                {

                    Console.WriteLine("Operation failed");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }   

        public async Task<bool> UpdateServingStatementAsync(ServingStatement ServingStatement)
        {
            if (await _categoryRepository.UpdateAsync(ServingStatement))
            {
                Console.WriteLine("Successfully Updated");
                return true;
            }
            else
            {
                try
                {

                    Console.WriteLine("Operation failed");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

        
    }
}
