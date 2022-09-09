using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Models
{
    public class ProgramingLanguageTechnologyListModel
    {
        public IList<ProgramingLanguageTechnologyListDto> Items { get; set; }
    }
}
