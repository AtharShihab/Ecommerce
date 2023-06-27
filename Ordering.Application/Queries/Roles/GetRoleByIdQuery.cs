using MediatR;
using Ordering.Application.Common.Interfaces;
using Ordering.Application.DTOs;

namespace Ordering.Application.Queries.Roles
{
    public class GetRoleByIdQuery : IRequest<RoleResponseDTO>
    {
        public string RoleId { get; set; }
    }


    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleResponseDTO>
    {
        private readonly IIdentityService _identityService;

        public GetRoleByIdQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<RoleResponseDTO> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _identityService.GetRoleByIdAsync(request.RoleId);
            return new RoleResponseDTO() { Id = role.id, RoleName = role.roleName };
        }
    }
}
