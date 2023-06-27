using MediatR;
using Ordering.Application.Common.Interfaces;

namespace Ordering.Application.Commands.Users.Update
{
    public class UpdateUserRolesCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public IList<string> Roles { get; set; }
    }


    public class UpdateUserRolesCommandHandler : IRequestHandler<UpdateUserRolesCommand, int>
    {
        private readonly IIdentityService _identityService;

        public UpdateUserRolesCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<int> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.UpdateUserRolesAsync(request.UserName, request.Roles);
            return result ? 1 : 0;
        }
    }
}
