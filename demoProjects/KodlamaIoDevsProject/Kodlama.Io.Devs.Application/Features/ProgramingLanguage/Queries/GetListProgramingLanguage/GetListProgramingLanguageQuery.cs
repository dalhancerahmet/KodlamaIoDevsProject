using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
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
    public class GetListProgramingLanguageQuery : IRequest<ProgramingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgramingLanguageQueryHandle : IRequestHandler<GetListProgramingLanguageQuery, ProgramingLanguageListModel>
        {
            private IProgramingLanguageRepository _programingLanguageRepository;
            private IMapper _mapper;

            public GetListProgramingLanguageQueryHandle(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgramingLanguageListModel> Handle(GetListProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
               IPaginate<ProgramingLanguage> programingLanguages=await _programingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size:request.PageRequest.PageSize);
                ProgramingLanguageListModel mappedProgramingLanguage=_mapper.Map<ProgramingLanguageListModel>(programingLanguages);
                return mappedProgramingLanguage;

            }
        }
    }
}
