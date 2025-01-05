using BlogApp.Core.Entities.Common;
using BlogApp.Core.Repositories;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositeries;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepositories
    {
        readonly HttpContext _http;
        readonly BlogAppDbContext _context;
        public UserRepository(BlogAppDbContext context,IHttpContextAccessor http) : base(context)
        {
            _context=context;
            _http = http.HttpContext;
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
           return await _context.Users.Where(x => x.Username == userName).FirstOrDefaultAsync();
        }

        public User GetCurrentUser()
        {
            return new();
        }


        int IUserRepositories.GetCurrentUserId()
        {
            return 0;
        }
    }
}
