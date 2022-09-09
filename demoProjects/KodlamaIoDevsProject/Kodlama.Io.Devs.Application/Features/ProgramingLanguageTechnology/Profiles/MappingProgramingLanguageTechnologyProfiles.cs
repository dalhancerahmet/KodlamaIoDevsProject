using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Commands.CreateProgramingLanguageTechnology;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Models;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .ForMember(t => t.ProgramingLanguageTechnologyName, opt => opt.MapFrom(x => x.ProgramingLanguage.Name))
                .ReverseMap();
            CreateMap<IPaginate<ProgramingLanguageTechnology>, ProgramingLanguageTechnologyListModel>()
                .ReverseMap();

            CreateMap<ProgramingLanguageTechnology,CreateProgramingLanguageTechnologyCommand>()
                .ReverseMap();
            CreateMap<ProgramingLanguageTechnology, CreatedProgramingLanguageTechnologyDto>()
                //eklerken dönüş değerlerindeki teknoloji adını getirmemektedir. Bu konuya bakılacak
                .ForMember(t=>t.TechnologyName,opt=>opt.MapFrom(x=>x.ProgramingLanguage.Name))
                .ReverseMap();
        }
    }
}
