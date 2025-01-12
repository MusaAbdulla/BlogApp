using AutoMapper;
using BlogApp.BL.Dtos.UserDtos;
using BlogApp.BL.Exceptions.Common;
using BlogApp.BL.ExternalServices.Interfaces;
using BlogApp.BL.Helpers;
using BlogApp.BL.Services.Interface;
using BlogApp.Core.Entities.Common;
using BlogApp.Core.Enums;
using BlogApp.Core.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;


namespace BlogApp.BL.Services.Implements
{
    public class AuthService(IUserRepositories _repo,IMapper _mapper,IJwtTokenHandler _handler,IMemoryCache _cache) : IAuthService
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
            await Send(user.Email);
        }

        public async Task<int> Send(string email)
        {
            if (_cache.TryGetValue(email, out var a))
                throw new Exception("Email already sent");
            if (!await _repo.IsExistAsync(x => x.Email == email))
            {
                throw new NotFoundException<User>("Email Notfound");
            }
            else {
                Random r = new Random();
                int code =r.Next(100000,999999);
                using SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("musaa-ab108@code.edu.az", "pkjs cnaz vhfx jhyj");
                MailAddress from = new MailAddress("musaa-ab108@code.edu.az", "BlogApp");
                MailAddress to = new MailAddress(email);
                MailMessage message = new MailMessage(from, to);
                message.Body = code.ToString();
                message.IsBodyHtml = true;
                smtp.Send(message);
                _cache.Set(email, code, TimeSpan.FromMinutes(5));
            } 
           
            return 0;
        }

        public async Task<bool> VerifyEmailAsync(string email, int code)
        {
          if(!_cache.TryGetValue(email,out int data))
           throw new NotFoundException<User>("We didnt send email");
          if(code == data)
            {
               var user= await _repo.GetWhere(x=> x.Email == email).FirstOrDefaultAsync();
                user!.IsVerified = true;
                user.Role=user.Role | (int)Roles.Publisher;
                
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
