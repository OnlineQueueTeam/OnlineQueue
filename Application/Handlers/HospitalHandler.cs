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
    public class HospitalHandler : IHospitalHandler
    {
        private readonly IHospitalRepository _categoryRepository;
        public HospitalHandler(IHospitalRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public async Task<bool> DeleteHospitalByIdAsync(int id)
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

        public async Task<List<Hospital>> GetAllHospitalsAsync()
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

        public async Task<Hospital> GetByIdHospitalAsync(int id)
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

        public async Task<bool> InsertHospitalAsync(Hospital hospital)
        {
            try
            {
                return await _categoryRepository.InsertAsync(hospital);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateHospitalAsync(Hospital hospital)
        {
            try
            {
                return await _categoryRepository.UpdateAsync(hospital);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
