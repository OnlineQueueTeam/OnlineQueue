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
    public class HospitalPhysicianHandler : IHospitalPhysicianHandler
    {
        private readonly IHospitalPhysicianRepository _categoryRepository;
        public HospitalPhysicianHandler(IHospitalPhysicianRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public async Task<bool> DeleteHospitalPhysicianByIdAsync(int id)
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

        public async Task<List<HospitalPhysician>> GetAllHospitalPhysicianAsync()
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

        public async Task<HospitalPhysician> GetByIdHospitalPhysicianAsync(int id)
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

        public async Task<bool> InsertHospitalPhysicianAsync(HospitalPhysician HospitalPhysician)
        {
            try
            {
                return await _categoryRepository.InsertAsync(HospitalPhysician);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> UpdateHospitalPhysicianAsync(HospitalPhysician HospitalPhysician)
        {
            try
            {
                return await _categoryRepository.UpdateAsync(HospitalPhysician);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
