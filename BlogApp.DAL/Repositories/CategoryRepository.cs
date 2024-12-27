using BlogApp.Core.Entities.Common;
using BlogApp.Core.Repositories;
using BlogApp.Core.Repostories;
using BlogApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositeries
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepostory
    {
        public CategoryRepository(BlogAppDbContext _context) : base(_context)
        {
        }

    }
}
