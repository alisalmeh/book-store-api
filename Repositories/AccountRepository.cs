using System.Threading.Tasks;
using AliBookStoreApi.Data;
using AliBookStoreApi.Interfaces;
using AliBookStoreApi.Models;
using Microsoft.AspNetCore.Identity;

namespace AliBookStoreApi.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(RegisterDto registerDto)
        {
            var user = new ApplicationUser()
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            return await _userManager.CreateAsync(user, registerDto.Password);
        }
    }
}