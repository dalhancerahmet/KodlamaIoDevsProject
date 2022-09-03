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
    public class DeleteProgramingLanguageCommand : IRequest<DeletedProgramingLanguageDto>
    {
        public int Id { get; set; }
        public class DeleteProgramingLanguageCommandHandler : IRequestHandler<DeleteProgramingLanguageCommand, DeletedProgramingLanguageDto>
        {
            IProgramingLanguageRepository _programingLanguageRepository;
            IMapper _mapper;

            public DeleteProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DeletedProgramingLanguageDto> Handle(DeleteProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguage  result= await _programingLanguageRepository.GetAsync(p=>p.Id==request.Id);
                ProgramingLanguage deletedProgramingLanguage=await _programingLanguageRepository.DeleteAsync(result);
                DeletedProgramingLanguageDto mappedDeletedProgramingLanguage=_mapper.Map<DeletedProgramingLanguageDto>(deletedProgramingLanguage);
                return mappedDeletedProgramingLanguage;
                
            }
        }
    }
}
