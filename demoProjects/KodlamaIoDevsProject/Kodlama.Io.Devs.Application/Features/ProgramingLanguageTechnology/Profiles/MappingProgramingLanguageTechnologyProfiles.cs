using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Commands.CreateProgramingLanguageTechnology;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Commands.DeleteProgramingLanguageTechnology;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Commands.UpdateProgramingLanguageTechnology;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Models;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Profiles
{
    public class MappingProgramingLanguageTechnologyProfiles : Profile
    {
        public MappingProgramingLanguageTechnologyProfiles()
        {
            //formember ile ProgramingLanguageTechnology içerisindeki "Name" ile Dto'sunun içerisindeki ProgramingLanguageName'i mapledik.
            //sebebi ise ilişkisel tablolar olduğundan dolayı ayrıyetten mapleme gereği duyuyoruz
            CreateMap<ProgramingLanguageTechnology, ProgramingLanguageTechnologyListDto>()
                .ForMember(t => t.ProgramingLanguageName, opt => opt.MapFrom(x => x.ProgramingLanguage.Name))
                .ReverseMap();
            CreateMap<IPaginate<ProgramingLanguageTechnology>, ProgramingLanguageTechnologyListModel>().ReverseMap();

            CreateMap<ProgramingLanguageTechnology,CreateProgramingLanguageTechnologyCommand>().ReverseMap();
            CreateMap<ProgramingLanguageTechnology, CreatedProgramingLanguageTechnologyDto>().ReverseMap();

            CreateMap<ProgramingLanguageTechnology, DeleteProgramingLanguageTechnologyCommand>().ReverseMap();

            CreateMap<ProgramingLanguageTechnology, UpdateProgramingLanguageTechnologyCommand>().ReverseMap();
            CreateMap<ProgramingLanguageTechnology, UpdatedProgramingLanguageTechnologyDto>().ReverseMap();

        }
    }
}
