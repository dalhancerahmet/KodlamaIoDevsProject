using FluentValidation;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features
{
    public class CreateProgramingLanguageCommandValidator :AbstractValidator<ProgramingLanguage>
    {
        public CreateProgramingLanguageCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Program dili boş geçilemez.")
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("Program dili 1 ile 15 karekter arasında olmalıdır.");
        }
    }
}
