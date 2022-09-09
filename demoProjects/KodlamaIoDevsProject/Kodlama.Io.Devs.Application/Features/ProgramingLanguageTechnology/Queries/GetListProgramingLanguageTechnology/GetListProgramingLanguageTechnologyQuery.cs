using AutoMapper;
using Core.Application.Requests;
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

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Queries.GetListProgramingLanguageTechnology
{
    public class GetListProgramingLanguageTechnologyQuery : IRequest<ProgramingLanguageTechnologyListModel>
    {
       public PageRequest PageRequest { get; set; }

        public class GetListProgramingLanguageTechnologyQueryHandler : IRequestHandler<GetListProgramingLanguageTechnologyQuery, ProgramingLanguageTechnologyListModel>
        {
            IProgramingLanguageTechnologyRepository _languageTechnologyRepository;
            IMapper _mapper;

            public GetListProgramingLanguageTechnologyQueryHandler(IProgramingLanguageTechnologyRepository languageTechnology, IMapper mapper)
            {
                _languageTechnologyRepository = languageTechnology;
                _mapper = mapper;
            }

            public async Task<ProgramingLanguageTechnologyListModel> Handle(GetListProgramingLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                //include ile ilgili sınıf içerisinde farklı bir sınıf prop olarak eklenmiş ise
                //yani ilişkisel tablo varsa, var olan ilişkili tabloyu belirtmek için kullanıyoruz.
                //böylelikle iligli sınıftaki id değil de id'ye karşılık gelen name alanı gelecektir.
                IPaginate<ProgramingLanguageTechnology> technologies= await _languageTechnologyRepository.GetListAsync(
                    include: m => m.Include(t => t.ProgramingLanguage),
                    index: request.PageRequest.Page,
                    size:request.PageRequest.PageSize
                    );

                ProgramingLanguageTechnologyListModel mappedTechnologies= _mapper.Map<ProgramingLanguageTechnologyListModel>(technologies);
                return mappedTechnologies;
            }
        }
    }
}
