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
    public partial class CreateProgramingLanguageCommand : IRequest<CreatedProgramingLanguageDto>
    {
        public string Name { get; set; }
        public class CreateProgramingLanguageCommandHandler : IRequestHandler<CreateProgramingLanguageCommand, CreatedProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;

            public CreateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<CreatedProgramingLanguageDto> Handle(CreateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguage mappedProgramingLanguage= _mapper.Map<ProgramingLanguage>(request);
                ProgramingLanguage createdProgramingLanguage=await _programingLanguageRepository.AddAsync(mappedProgramingLanguage);
                CreatedProgramingLanguageDto mappedCreatedProgramingLanguage =_mapper.Map<CreatedProgramingLanguageDto>(createdProgramingLanguage);
                return mappedCreatedProgramingLanguage;
            }
        }
    }
}
