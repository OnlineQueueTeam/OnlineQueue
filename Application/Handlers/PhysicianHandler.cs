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
    public class PhysicianHandler : IPhysicianHandler
    {
        private readonly IPhysicianHandler _categoryRepository;
        public PhysicianHandler(IPhysicianHandler categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public async Task<bool> DeletePhysicianByIdAsync(int id)
        {
            try
            {
                return await _categoryRepository.DeletePhysicianByIdAsync(id);
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Physician>> GetAllPhysiciansAsync()
        {
            try
            {
                return await _categoryRepository.GetAllPhysiciansAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Physician> GetByIdPhysicianAsync(int id)
        {
            try
            {
                return await _categoryRepository.GetByIdPhysicianAsync(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> InsertPhysicianAsync(Physician physician)
        {
            try
            {
                return await _categoryRepository.InsertPhysicianAsync(physician);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> UpdatePhysicianAsync(Physician physician)
        {
            try
            {
                return await _categoryRepository.UpdatePhysicianAsync(physician);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
