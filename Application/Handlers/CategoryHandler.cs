using Application.Handler.Interface;
using Application.Repository.Interfaces;
using Domain.Models;

namespace Application.Handlers
{
    public class CategoryHandler : ICategoryHandler
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryHandler(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }


        public async Task<bool> DeleteCategoryByIdAsync(int id)
        {

            if (await _categoryRepository.DeleteByIdAsync(id))
            {
                Console.WriteLine("Successfully Deleted!");
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

        public async Task<List<Category>> GetAllCategoriesAsync()
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

        public async Task<Category> GetByIdCategoryAsync(int id)
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

        public async Task<bool> InsertCategoryAsync(Category category)
        {

            if (await _categoryRepository.InsertAsync(category))
            {
                Console.WriteLine("Succesfully added");
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


        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            if (await _categoryRepository.UpdateAsync(category))
            {
                Console.WriteLine("Succesfully updated!");
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
