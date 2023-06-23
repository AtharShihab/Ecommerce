using Microsoft.AspNetCore.Identity;
using Ordering.Infrastructure.Identity;

namespace Ordering.Infrastructure.Services
{
    public class IdentityService /*: IIdentityService*/
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //public async Task<bool> AssignUserToRole(string userName, IList<string> roles)
        //{
        //    var user = await _userManager.FindByNameAsync(userName);
        //    if (user == null)
        //    {
        //        return false;
        //    }
        //}
    }
}
