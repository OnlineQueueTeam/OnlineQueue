using Application.Handler.Interface;
using Application.Repository.Interfaces;
using Domain.Models;

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
            if (await _categoryRepository.InsertAsync(patient))
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

        public async Task<bool> UpdatePatientAsync(Patient patient)
        {

            if (await _categoryRepository.UpdateAsync(patient))
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
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

    }
}

