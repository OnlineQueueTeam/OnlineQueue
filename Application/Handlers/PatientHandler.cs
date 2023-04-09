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
    public class PatientHandler : IPatientHandler
    {
        private readonly IPatientRepository _categoryRepository;
        public PatientHandler(IPatientRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public async Task<bool> DeletePatientByIdAsync(int id)
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

        public async Task<List<Patient>> GetAllPatientsAsync()
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

        public async Task<Patient> GetByIdPatientAsync(int id)
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

        public async Task<bool> InsertPatientAsync(Patient patient)
        {
            try
            {
                return await _categoryRepository.InsertAsync(patient);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdatePatientAsync(Patient patient)
        {
            try
            {
                return await _categoryRepository.UpdateAsync(patient);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
