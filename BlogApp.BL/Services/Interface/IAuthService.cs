using BlogApp.BL.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interface
{
    public interface IAuthService
    {
        Task<int> Send(string email);
        Task RegisterAsync(CreateUserDto dto);
        Task<string> LoginAsync(LoginDto dto);
        Task<bool> VerifyEmailAsync(string email,int code);
    }
}
