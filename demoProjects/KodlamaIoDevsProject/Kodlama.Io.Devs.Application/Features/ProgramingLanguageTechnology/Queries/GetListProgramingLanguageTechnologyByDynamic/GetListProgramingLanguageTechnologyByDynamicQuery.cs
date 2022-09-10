using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Models;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Queries.GetListProgramingLanguageTechnologyByDynamic
{
    public class GetListProgramingLanguageTechnologyByDynamicQuery :IRequest<ProgramingLanguageTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }

        public class GetListProgramingLanguageTechnologyByDynamicQueryHandler : IRequestHandler<GetListProgramingLanguageTechnologyByDynamicQuery, ProgramingLanguageTechnologyListModel>
        {
            IProgramingLanguageTechnologyRepository _technologyRepository;
            IMapper _mapper;

            public GetListProgramingLanguageTechnologyByDynamicQueryHandler(IProgramingLanguageTechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgramingLanguageTechnologyListModel> Handle(GetListProgramingLanguageTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
               IPaginate<ProgramingLanguageTechnology> technology= await _technologyRepository.GetListByDynamicAsync(
                    dynamic: request.Dynamic,
                    include: m => m.Include(c => c.ProgramingLanguage),
                    size: request.PageRequest.PageSize,
                    index: request.PageRequest.Page);

                ProgramingLanguageTechnologyListModel mappedTechnology= _mapper.Map<ProgramingLanguageTechnologyListModel>(technology);
                return mappedTechnology;
            }
        }
    }
}
