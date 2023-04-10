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
            if (await _categoryRepository.DeleteByIdAsync(id))
            {
                Console.WriteLine("Successfully deleted!");
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
                    Console.WriteLine("Error: " + ex.Message);
                }
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
            if (await _categoryRepository.InsertAsync(hospital))
            {
                Console.WriteLine("Successfully added");
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
                    Console.WriteLine("Error: " + ex.Message);
                }
                return false;
            }
        }

        public async Task<bool> UpdateHospitalAsync(Hospital hospital)
        {
            if (await _categoryRepository.UpdateAsync(hospital))
            {
                Console.WriteLine("Successfully updated");
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
                    Console.WriteLine("Error: " + ex.Message);
                }
                return false;
            }
        }
    }
}
