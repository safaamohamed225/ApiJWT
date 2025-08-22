using ApiJWT.Models;

namespace ApiJWT.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
    }
}
