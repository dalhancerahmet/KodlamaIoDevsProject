using AutoMapper;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Commands.DeleteProgramingLanguageTechnology;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnoloies.Commands.DeleteProgramingLanguageTechnology
{
    public class DeleteProgramingLanguageTechnologyCommandHandler : IRequestHandler<DeleteProgramingLanguageTechnologyCommand, bool>
    {
        IProgramingLanguageTechnologyRepository _technologyRepository;

        public DeleteProgramingLanguageTechnologyCommandHandler(IProgramingLanguageTechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task<bool> Handle(DeleteProgramingLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
           ProgramingLanguageTechnology technology=await _technologyRepository.GetAsync(t => t.Id == request.Id);
           ProgramingLanguageTechnology deletedTechnology= await _technologyRepository.DeleteAsync(technology);
           return true;
        }
    }
}
