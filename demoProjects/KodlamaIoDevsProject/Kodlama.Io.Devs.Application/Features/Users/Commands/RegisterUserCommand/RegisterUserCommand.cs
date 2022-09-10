using AutoMapper;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Kodlama.Io.Devs.Application.Features.Users.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.Users.Commands.RegisterUserCommand
{
    public class RegisterUserCommand : IRequest<UserResponseDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserResponseDto>
        {
            IUserRepository _userRepository;
            IMapper _mapper;

            public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<UserResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash,passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                User mappedUser= _mapper.Map<User>(request);
                mappedUser.PasswordHash=passwordHash;
                mappedUser.PasswordSalt=passwordSalt;
                mappedUser.Status = true;
                mappedUser.AuthenticatorType=AuthenticatorType.Email;

                User createdUser= await _userRepository.AddAsync(mappedUser);
                UserResponseDto mappedCreatedUser= _mapper.Map<UserResponseDto>(createdUser);
                return mappedCreatedUser;
            }
        }
    }
}
