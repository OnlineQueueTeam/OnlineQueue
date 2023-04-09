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
    public class CategoryHandler : ICategoryHandler
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryHandler(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }


        public async Task<bool> DeleteCategoryByIdAsync(int id)
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
            try
            {
                return await _categoryRepository.InsertAsync(category);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            try
            {
                return await _categoryRepository.UpdateAsync(category);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
