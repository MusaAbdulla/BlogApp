using BlogApp.Core.Entities.Common;
using BlogApp.Core.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Repositories
{
    public interface ICategoryRepostory:IGenericRepository<Category>
    {
    }
}
