using Core.Persistence.Repositories;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using Kodlama.Io.Devs.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Persistance.Repositories
{
    public class ProgramingLanguageTechnologyRepository : EfRepositoryBase<ProgramingLanguageTechnology, BaseDbContext>, IProgramingLanguageTechnologyRepository
    {
        public ProgramingLanguageTechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
