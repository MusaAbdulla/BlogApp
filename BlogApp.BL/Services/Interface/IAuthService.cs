﻿using BlogApp.BL.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interface
{
    public interface IAuthService
    {
        Task RegisterAsync(CreateUserDto dto);
        Task LoginAsync(LoginDto dto);
    }
}
