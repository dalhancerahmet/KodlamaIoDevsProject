using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features
{
    public class ProgramingLanguageBusinessRules
    {
        IProgramingLanguageRepository _ProgramingLanguageRepository;

        public ProgramingLanguageBusinessRules(IProgramingLanguageRepository programingLanguageRepository)
        {
            _ProgramingLanguageRepository = programingLanguageRepository;
        }

        public async Task ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
           var result=await _ProgramingLanguageRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any())
                throw new BusinessException("Programlama dili zaten var.");
        }
    }
}
