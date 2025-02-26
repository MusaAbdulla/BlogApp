﻿using AutoMapper;
using BlogApp.BL.Dtos.UserDtos;
using BlogApp.BL.Helpers;
using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>()
                .ForMember(x => x.PasswordHash, x => x.MapFrom(
                    y => HashHelper.HashPassword(y.Password)));
                
        }
    }
}
