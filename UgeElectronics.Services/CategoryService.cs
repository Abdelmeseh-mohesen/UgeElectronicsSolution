using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UgeElectronics.Core.Dto;
using UgeElectronics.Core.Entity;
using UgeElectronics.Core.Repository;
using UgeElectronics.Core.Services;
using UgeElectronics.Core.SpecificationHandler;

namespace UgeElectronics.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> categoryRepository , IMapper mapper) { 
        
            this.categoryRepository=categoryRepository;
            _mapper=mapper;
        }

        public async Task<Category> AddCategoryAsync(CategoryRequestDto category)
        {
            var categoryMapper = _mapper.Map<Category>(category);
            await categoryRepository.AddAsync(categoryMapper);
            return categoryMapper; 
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var spec= new CategorySpecification();
            var categories= await categoryRepository.GetAllWithSpecAsync(spec);
            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await categoryRepository.GetByIdAsync(id); // تأكد من أن لديك هذه الطريقة في واجهة `IGenericRepository`
        }
    }
}
