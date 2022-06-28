using Assignment.API.Interfaces;
using Assignment.API.Requests;
using Assignment.API.Responses;
using Assignment.Domain.Data;
using Assignment.Domain.Entities;
using Assignment.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Assignment.API.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext onlineshopDbContext;
        private readonly ITokenService tokenService;

        public UserService(ApplicationDbContext onlineshopDbContext, ITokenService tokenService)
        {
            this.onlineshopDbContext = onlineshopDbContext;
            this.tokenService = tokenService;
        }

        public async Task<TokenResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = onlineshopDbContext.Users.SingleOrDefault(user => user.Active && user.Email == loginRequest.Email);

            if (user == null)
            {
                return new TokenResponse
                {
                    Success = false,
                    Error = "Email not found"
                };
            }
            var passwordHash = PasswordHelper.HashUsingPbkdf2(loginRequest.Password, Convert.FromBase64String(user.PasswordSalt));

            if (user.Password != passwordHash)
            {
                return new TokenResponse
                {
                    Success = false,
                    Error = "Invalid Password"
                };
            }

            var token = await System.Threading.Tasks.Task.Run(() => tokenService.GenerateTokensAsync(user.Id));

            return new TokenResponse
            {
                Success = true,
                AccessToken = token.Item1,
                RefreshToken = token.Item2
            };
        }

        public async Task<LogoutResponse> LogoutAsync(int userId)
        {
            var refreshToken = await onlineshopDbContext.RefreshTokens.FirstOrDefaultAsync(o => o.UserId == userId);

            if (refreshToken == null)
            {
                return new LogoutResponse { Success = true };
            }

            onlineshopDbContext.RefreshTokens.Remove(refreshToken);

            var saveResponse = await onlineshopDbContext.SaveChangesAsync();

            if (saveResponse >= 0)
            {
                return new LogoutResponse { Success = true };
            }

            return new LogoutResponse { Success = false, Error = "Unable to logout user"};

        }

        public async Task<SignupResponse> SignupAsync(SignupRequest signupRequest)
        {
            var existingUser = await onlineshopDbContext.Users.SingleOrDefaultAsync(user => user.Email == signupRequest.Email);

            if (existingUser != null)
            {
                return new SignupResponse
                {
                    Success = false,
                    Error = "User already exists with the same email"
                };
            }

            if (signupRequest.Password != signupRequest.ConfirmPassword)
            {
                return new SignupResponse
                {
                    Success = false,
                    Error = "Password and confirm password do not match"
                };
            }

            if (signupRequest.Password.Length <= 7) 
            {
                return new SignupResponse
                {
                    Success = false,
                    Error = "Password is weak"
                };
            }

            var salt = PasswordHelper.GetSecureSalt();
            var passwordHash = PasswordHelper.HashUsingPbkdf2(signupRequest.Password, salt);

            var user = new User
            {
                Email = signupRequest.Email,
                Password = passwordHash,
                PasswordSalt = Convert.ToBase64String(salt),
                FirstName = signupRequest.FirstName,
                LastName = signupRequest.LastName,
                Phone = signupRequest.Phone,
                Address = signupRequest.Address,
                CreatedDate = signupRequest.CreatedDate,
                Active = true
            };

            await onlineshopDbContext.Users.AddAsync(user);

            var saveResponse = await onlineshopDbContext.SaveChangesAsync();

            if (saveResponse >= 0)
            {
                return new SignupResponse { Success = true, Email = user.Email };
            }

            return new SignupResponse
            {
                Success = false,
                Error = "Unable to save the user"
            };

        }
    }
}
