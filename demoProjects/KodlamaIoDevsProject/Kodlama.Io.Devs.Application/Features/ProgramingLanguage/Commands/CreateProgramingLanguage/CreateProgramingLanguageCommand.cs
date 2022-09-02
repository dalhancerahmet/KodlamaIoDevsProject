﻿using AutoMapper;
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
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public CreateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<CreatedProgramingLanguageDto> Handle(CreateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageBusinessRules.ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgramingLanguage mappedProgramingLanguage= _mapper.Map<ProgramingLanguage>(request);
                ProgramingLanguage createdProgramingLanguage=await _programingLanguageRepository.AddAsync(mappedProgramingLanguage);
                CreatedProgramingLanguageDto mappedCreatedProgramingLanguage =_mapper.Map<CreatedProgramingLanguageDto>(createdProgramingLanguage);
                return mappedCreatedProgramingLanguage;
            }
        }
    }
}
