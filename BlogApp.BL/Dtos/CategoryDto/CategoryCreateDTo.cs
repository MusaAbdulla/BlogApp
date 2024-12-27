using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Dtos.CategoryDto
{
    public class CategoryCreateDTo
    {
        public string Name  { get; set; }
        public string Icon  { get; set; }
        public static implicit operator Category(CategoryCreateDTo dto)
        {
            Category cat = new Category()
            {
                Icon = dto.Icon,
                Name = dto.Name,
            };
            return cat;
        }
    }
}
