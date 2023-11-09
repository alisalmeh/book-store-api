using System.Threading.Tasks;
using AliBookStoreApi.Models;
using Microsoft.AspNetCore.Identity;

namespace AliBookStoreApi.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> Register(RegisterDto registerDto);
    }
}