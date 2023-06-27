using MediatR;
using Ordering.Application.Common.Interfaces;
using Ordering.Application.DTOs;

namespace Ordering.Application.Queries.Users
{
    public class GetAllUsersDetailsQuery : IRequest<List<UserDetailsResponseDTO>>
    {

    }


    public class GetAllUsersDetailsQueryHandler : IRequestHandler<GetAllUsersDetailsQuery, List<UserDetailsResponseDTO>>
    {
        private readonly IIdentityService _identityService;

        public GetAllUsersDetailsQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<List<UserDetailsResponseDTO>> Handle(GetAllUsersDetailsQuery request, CancellationToken cancellationToken)
        {
            var users = await _identityService.GetAllUsersDetailsAsync();
            var allUserDetails = users.Select(u => new UserDetailsResponseDTO
            {
                Id = u.id,
                Email= u.email,
                UserName = u.userName,
                Roles = u.roles
            }).ToList();

            return allUserDetails;
        }
    }
}
