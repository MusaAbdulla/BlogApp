using AutoMapper;
using BlogApp.BL.Dtos.UserDtos;
using BlogApp.BL.Exceptions.Common;
using BlogApp.BL.ExternalServices.Interfaces;
using BlogApp.BL.Helpers;
using BlogApp.BL.Services.Interface;
using BlogApp.Core.Entities.Common;
using BlogApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;


namespace BlogApp.BL.Services.Implements
{
    public class AuthService(IUserRepositories _repo,IMapper _mapper,IJwtTokenHandler _handler) : IAuthService
    {
        public async Task<string> LoginAsync(LoginDto dto)
        {
           User? user=null;
            if(dto.UsernameOrEmail.Contains('@'))
            {
                user = await _repo.GetAll().Where(x =>
            x.Email == dto.UsernameOrEmail).FirstOrDefaultAsync();
            }
            else
            {
                user = await _repo.GetAll().Where(x =>
           x.Username == dto.UsernameOrEmail).FirstOrDefaultAsync();
            }
            if (user == null)
                throw new NotFoundException<User>();
            if (!HashHelper.VerifyHashedPassword(user.PasswordHash, dto.Password))
                throw new NotFoundException<User>();


            return _handler.CreatToken(user, 36);
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
