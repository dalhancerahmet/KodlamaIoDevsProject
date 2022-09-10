using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.Users.Commands.LoginUserCommand
{
    public class LoginUserCommand : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AccessToken>
        {
            IUserRepository _userRepository;
            IMapper _mapper;
            ITokenHelper _tokenHelper;

            public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
            }

            public async Task<AccessToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                User? user =await _userRepository.GetAsync(u => u.Email == request.Email);
                bool isConfirmed= HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);
                if (!isConfirmed)
                    throw new BusinessException("Cannot password Verify");

                IList<OperationClaim> operationClaims=  _userRepository.GetClaims(user);
                AccessToken accessToken= _tokenHelper.CreateToken(user, operationClaims);
                return accessToken;

            }
        }
    }
}
