using Assignment.API.Requests;
using Assignment.API.Responses;
using Assignment.SharedViewModels.Auth;
using Refit;

namespace Assignment.CustomerSite.Services
{
    public interface IUser
    {
        [Post("/api/Users/signup")]
        Task<SignupResponse> SignupAsync(SignupRequest request);
        [Post("/api/Users/login")]
        Task<TokenResponse> LoginAsync(LoginRequest request);
        [Post("/api/Users/logout")]
        Task<LogoutResponse> LogoutAsync(int userId);
    }
}
