
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

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Commands.UpdateProgramingLanguageTechnology
{
    public class UpdateProgramingLanguageTechnologyCommand :IRequest<UpdatedProgramingLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgramingLanguageId { get; set; }

        public class UpdateProgramingLanguageTechnologyCommandHandler : IRequestHandler<UpdateProgramingLanguageTechnologyCommand, UpdatedProgramingLanguageTechnologyDto>
        {
            IMapper _mapper;
            IProgramingLanguageTechnologyRepository _technologyRepository;

            public UpdateProgramingLanguageTechnologyCommandHandler(IMapper mapper, IProgramingLanguageTechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<UpdatedProgramingLanguageTechnologyDto> Handle(UpdateProgramingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguageTechnology technology=  _mapper.Map<ProgramingLanguageTechnology>(request);
                ProgramingLanguageTechnology updatedTechnology= await _technologyRepository.UpdateAsync(technology);
                UpdatedProgramingLanguageTechnologyDto mappedUpdatedTechnology= _mapper.Map<UpdatedProgramingLanguageTechnologyDto>(updatedTechnology);
                return mappedUpdatedTechnology;
            }
        }
    }
}
