using AutoMapper;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features
{
    public class UpdateProgramingLanguageCommand : IRequest<UpdatedProgramingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgramingLanguageCommandHandle : IRequestHandler<UpdateProgramingLanguageCommand, UpdatedProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly Mapper _mapper;

            public UpdateProgramingLanguageCommandHandle(IProgramingLanguageRepository programingLanguageRepository, Mapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedProgramingLanguageDto> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguage programingLanguage=await _programingLanguageRepository.GetAsync(p => p.Id == request.Id);
                programingLanguage.Name=request.Name;
                await _programingLanguageRepository.UpdateAsync(programingLanguage);
                UpdatedProgramingLanguageDto mappedUpdatedProgramingLanguage=_mapper.Map<UpdatedProgramingLanguageDto>(programingLanguage);
                return mappedUpdatedProgramingLanguage;
            }
        }
    }
}
