using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features
{
    public class ProgramingLanguageListModel : BasePageableModel
    {
        public IList<ProgramingLanguageListDto> Items { get; set; }
    }
}
