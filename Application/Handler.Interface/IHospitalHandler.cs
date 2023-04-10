using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.Interface
{
    public interface IHospitalHandler
    {
        public Task<List<Hospital>> GetAllCategoriesAsync();
        public Task<Category> GetByIdCategoryAsync(int id);
        public Task<bool> UpdateCategoryAsync(Category category);
        public Task<bool> DeleteCategoryByIdAsync(int id);
        public Task<bool> InsertCategoryAsync(Category category);
    }
}
