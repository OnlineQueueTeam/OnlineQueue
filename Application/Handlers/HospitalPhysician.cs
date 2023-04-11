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
            if (await _categoryRepository.InsertAsync(HospitalPhysician))
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


        public async Task<bool> UpdateHospitalPhysicianAsync(HospitalPhysician HospitalPhysician)
        {
            if (await _categoryRepository.InsertAsync(HospitalPhysician))
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
