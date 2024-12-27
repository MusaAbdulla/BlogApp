using BlogApp.BL.Dtos.CategoryDto;
using BlogApp.BL.Services.Interface;
using BlogApp.Core.Entities.Common;
using BlogApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implements
{
    public class CategoryServices(ICategoryRepostory _repo) : ICategoryService
    {
        public async Task<int> CreateAsync(CategoryCreateDTo dto)
        {
            Category cat = dto;
            await _repo.AddAsync(cat);
            await _repo.SaveAsync();
            return cat.Id;
        }

        public async Task Delete(int id)
        {
           await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryListItem>> GetAllAsync()
        {
          return await  _repo.GetAll().Select(x=> new CategoryListItem
           {
               Id= x.Id,
               Name= x.Name,
               Icon= x.Icon,
           }).ToListAsync();
        }
    }
}
