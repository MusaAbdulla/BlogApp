using BlogApp.BL.Dtos.UserDtos;
using BlogApp.Core.Entities.Common;
using BlogApp.Core.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Validators.UserValidator
{
    public class CreateUserValidator:AbstractValidator<CreateUserDto>
    {
        readonly IUserRepositories _repo;
        public CreateUserValidator(IUserRepositories repo)
        {
            _repo = repo;
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("You are not insert correct Email");
            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                .Must(x =>
                {
                    return _repo.GetByUserNameAsync(x).Result==null;
                })
                .WithMessage("Username Exist");
                
        }
    }
}
