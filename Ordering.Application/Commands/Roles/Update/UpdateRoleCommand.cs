using MediatR;
using Ordering.Application.Common.Interfaces;

namespace Ordering.Application.Commands.Roles.Update
{
    public class UpdateRoleCommand : IRequest<int>
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }


    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, int>
    {
        private readonly IIdentityService _identityService;

        public UpdateRoleCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<int> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.UpdateRoleAsync(request.RoleId, request.RoleName);

            return result? 1 : 0;
        }
    }
}
