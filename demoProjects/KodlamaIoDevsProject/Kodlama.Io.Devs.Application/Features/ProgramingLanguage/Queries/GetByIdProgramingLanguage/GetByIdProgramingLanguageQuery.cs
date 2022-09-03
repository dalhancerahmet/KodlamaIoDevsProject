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
    public class GetByIdProgramingLanguageQuery : IRequest<ProgramingLanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdProgramingLanguageQueryHandler : IRequestHandler<GetByIdProgramingLanguageQuery, ProgramingLanguageGetByIdDto>
        {
            private IProgramingLanguageRepository _programingLanguageRepository;
            private IMapper _mapper;

            public GetByIdProgramingLanguageQueryHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgramingLanguageGetByIdDto> Handle(GetByIdProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
               ProgramingLanguage programingLanguage=await _programingLanguageRepository.GetAsync(p => p.Id == request.Id);
                ProgramingLanguageGetByIdDto result = _mapper.Map<ProgramingLanguageGetByIdDto>(programingLanguage);
                return result;
            }
        }
    }
}
