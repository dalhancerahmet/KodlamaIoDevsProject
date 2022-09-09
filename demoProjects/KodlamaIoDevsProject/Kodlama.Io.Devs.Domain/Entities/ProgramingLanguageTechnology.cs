using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Domain.Entities
{
    public class ProgramingLanguageTechnology : Entity
    {
        public int ProgramingLanguageId { get; set; }
        public string Name { get; set; }
        public virtual ProgramingLanguage? ProgramingLanguage { get; set; }

        public ProgramingLanguageTechnology()
        {

        }
        public ProgramingLanguageTechnology(int id, int programingLanguageId, string name ) : this()
        {
            Id = id;
            Name = name;
            ProgramingLanguageId = programingLanguageId;
        }
    }
}
