using AutoMapper;
using Core.Security.Entities;
using Kodlama.Io.Devs.Application.Features.Users.Commands.RegisterUserCommand;
using Kodlama.Io.Devs.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.Users.Profiles
{
    public class MappingUserProfiles : Profile
    {
        public MappingUserProfiles()
        {
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, UserResponseDto>().ReverseMap();
        }
    }
}
