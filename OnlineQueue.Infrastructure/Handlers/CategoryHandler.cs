
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQueue.Infrastructure.Handlers
{
    public class CategoryHandler
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryHandler(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
    }
}
    