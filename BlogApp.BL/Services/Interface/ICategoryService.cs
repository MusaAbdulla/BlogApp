using BlogApp.BL.Dtos.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListItem>> GetAllAsync();
        Task<int> CreateAsync(CategoryCreateDTo dto);
        Task Delete(int id);
    }
}
