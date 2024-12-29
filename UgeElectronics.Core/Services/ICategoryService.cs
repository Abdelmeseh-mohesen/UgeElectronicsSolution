using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Dto;
using UgeElectronics.Core.Entity;

namespace UgeElectronics.Core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> AddCategoryAsync(CategoryRequestDto category);
    }
}
