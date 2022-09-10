using AutoMapper;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Commands.DeleteProgramingLanguageTechnology
{
    public class DeleteProgramingLanguageTechnologyCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
