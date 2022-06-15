using CommonLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class CategoryService
    {
        private readonly ProductDbContext _dbContext;

        public CategoryService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            return _dbContext.Categories.Select(CategoryDto.CategoryFunc);
        }

        public IEnumerable<CategoryDto> GetProductCategories()
        {
            return _dbContext.Categories.Include(category => category.Products).Select(CategoryDto.CategoryFunc);
        }
    }
}
