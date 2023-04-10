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
        private readonly IPhysicianRepository _categoryRepository;
        public PhysicianHandler(IPhysicianRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public async Task<bool> DeletePhysicianByIdAsync(int id)
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
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

        public async Task<List<Physician>> GetAllPhysiciansAsync()
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

        public async Task<Physician> GetByIdPhysicianAsync(int id)
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

        public async Task<bool> InsertPhysicianAsync(Physician physician)
        {
            if (await _categoryRepository.InsertAsync(physician))
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


        public async Task<bool> UpdatePhysicianAsync(Physician physician)
        {
            if (await _categoryRepository.UpdateAsync(physician))
            {
                Console.WriteLine("Successfully Updated!");
                return true;
            }
            else
            {
                try
                {
                    Console.WriteLine("Operation failed!");
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
