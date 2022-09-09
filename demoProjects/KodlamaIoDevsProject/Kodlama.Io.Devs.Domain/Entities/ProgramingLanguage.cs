using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Domain.Entities
{
    public class ProgramingLanguage : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<ProgramingLanguageTechnology> ProgramingLanguageTechnologies { get; set; }

        public ProgramingLanguage()
        {

        }

        public ProgramingLanguage(string name, ICollection<ProgramingLanguageTechnology> programingLanguageTechnologies)
        {
            Name = name;
            ProgramingLanguageTechnologies = programingLanguageTechnologies;
        }
    }
}
