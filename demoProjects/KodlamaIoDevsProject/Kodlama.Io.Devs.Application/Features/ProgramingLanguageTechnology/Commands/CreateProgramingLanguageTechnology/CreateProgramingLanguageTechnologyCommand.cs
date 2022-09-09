using AutoMapper;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Commands.CreateProgramingLanguageTechnology
{
    public class CreateProgramingLanguageTechnologyCommand : IRequest<CreatedProgramingLanguageTechnologyDto>
    {
        public int ProgramingLanguageId { get; set; }
        public string Name { get; set; }

        public class CreateProgramingLanguageTechnologyCommandHandler : IRequestHandler<CreateProgramingLanguageTechnologyCommand, CreatedProgramingLanguageTechnologyDto>
        {
            IProgramingLanguageTechnologyRepository _technologyRepository;
            IMapper _mapper;

            public CreateProgramingLanguageTechnologyCommandHandler(IProgramingLanguageTechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<CreatedProgramingLanguageTechnologyDto> Handle(CreateProgramingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguageTechnology mappedTechnology = _mapper.Map<ProgramingLanguageTechnology>(request);
                ProgramingLanguageTechnology createdTechnology= await _technologyRepository.AddAsync(mappedTechnology);
                CreatedProgramingLanguageTechnologyDto mappedCreatedTechnology= _mapper.Map<CreatedProgramingLanguageTechnologyDto>(createdTechnology);
                return mappedCreatedTechnology;
            }
        }
    }
}
