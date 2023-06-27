using MediatR;
using Ordering.Application.Common.Interfaces;
using Ordering.Application.DTOs;

namespace Ordering.Application.Queries.Roles
{
    public class GetRolesQuery : IRequest<IList<RoleResponseDTO>>
    {
    }


    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, IList<RoleResponseDTO>>
    {
        private readonly IIdentityService _identityService;

        public GetRolesQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<IList<RoleResponseDTO>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _identityService.GetRolesAsync();

            return roles.Select(role => new RoleResponseDTO
            {
                Id = role.id,
                RoleName = role.roleName
            }).ToList();
        }
    }
}
