using AutoMapper;
using Core.Persistence.Paging;
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

            CreateMap<ProgramingLanguage, DeleteProgramingLanguageCommand>().ReverseMap();
            CreateMap<ProgramingLanguage, DeletedProgramingLanguageDto>().ReverseMap();

            CreateMap<ProgramingLanguage, UpdatedProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, UpdateProgramingLanguageCommand>().ReverseMap();

            CreateMap<IPaginate<ProgramingLanguage>, ProgramingLanguageListModel>().ReverseMap();
            CreateMap<ProgramingLanguage, ProgramingLanguageListDto>().ReverseMap();

        }
    }
}
