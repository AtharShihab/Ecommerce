﻿using MediatR;
using Ordering.Application.Common.Interfaces;

namespace Ordering.Application.Commands.Users.Update
{
    public class EditUserProfileCommand : IRequest<int>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }


    public class EditUserProfileCommandHandler : IRequestHandler<EditUserProfileCommand, int>
    {
        private readonly IIdentityService _identityService;

        public EditUserProfileCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<int> Handle(EditUserProfileCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.UpdateUserProfileAsync(request.Id, request.FullName, request.Email, request.Roles);
            return result ? 1 : 0;
        }
    }
}