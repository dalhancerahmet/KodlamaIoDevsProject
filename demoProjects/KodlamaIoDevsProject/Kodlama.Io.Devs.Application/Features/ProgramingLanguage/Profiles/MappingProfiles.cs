﻿using AutoMapper;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgramingLanguage, CreatedProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage,CreateProgramingLanguageCommand>().ReverseMap();
            

        }
    }
}