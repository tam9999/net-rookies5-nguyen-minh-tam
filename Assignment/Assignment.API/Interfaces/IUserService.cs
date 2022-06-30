using Assignment.API.Requests;
using Assignment.API.Responses;
using Assignment.Domain.Entities;

namespace Assignment.API.Interfaces
{
    public interface IUserService
    {
        Task<TokenResponse> LoginAsync(LoginRequest loginRequest);
        Task<SignupResponse> SignupAsync(SignupRequest signupRequest);
        Task<LogoutResponse> LogoutAsync(int userId);
        Task UpdateUser(User user);
    }
}
