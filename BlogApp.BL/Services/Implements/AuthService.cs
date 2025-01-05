using AutoMapper;
using BlogApp.BL.Dtos.UserDtos;
using BlogApp.BL.Exceptions.Common;
using BlogApp.BL.Services.Interface;
using BlogApp.Core.Entities.Common;
using BlogApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;


namespace BlogApp.BL.Services.Implements
{
    public class AuthService(IUserRepositories _repo,IMapper _mapper) : IAuthService
    {
        public Task LoginAsync(LoginDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(CreateUserDto dto)
        {
            var user =await _repo.GetAll().Where(x=> x.Username == dto.UserName ||
            x.Email==dto.Email).FirstOrDefaultAsync();
            if (user != null)
            {
                if (user.Email == dto.Email)
                    throw new ExistException<User>("Email already using");
                else if(user.Username == dto.UserName)
                    throw new ExistException<User>("UserName already using");

            }
           user= _mapper.Map<User>(dto);
            await _repo.AddAsync(user);
            await _repo.SaveAsync();
        }
    }
}
