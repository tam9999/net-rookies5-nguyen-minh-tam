using Assignment.API.Interfaces;
using Assignment.API.Requests;
using Assignment.API.Responses;
using Assignment.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public UsersController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }
        
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsersAsync()
        {
            try
            {
                var product = await userService.GetUsersAsync();
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest(new TokenResponse
                {
                    Error = "Missing login details"
                });
            }

            var loginResponse = await userService.LoginAsync(loginRequest);

            if (!loginResponse.Success)
            {
                return Unauthorized(new
                {
                    loginResponse.ErrorCode,
                    loginResponse.Error
                });
            }

            return Ok(loginResponse);
        }

        [HttpPost]
        [Route("refresh_token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            if (refreshTokenRequest == null || string.IsNullOrEmpty(refreshTokenRequest.RefreshToken) || refreshTokenRequest.UserId == 0)
            {
                return BadRequest(new TokenResponse
                {
                    Error = "Missing refresh token details"
                });
            }

            var validateRefreshTokenResponse = await tokenService.ValidateRefreshTokenAsync(refreshTokenRequest);

            if (!validateRefreshTokenResponse.Success)
            {
                return UnprocessableEntity(validateRefreshTokenResponse);
            }

            var tokenResponse = await tokenService.GenerateTokensAsync(validateRefreshTokenResponse.UserId);

            return Ok(new { AccessToken = tokenResponse.Item1, Refreshtoken = tokenResponse.Item2 });
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup(SignupRequest signupRequest)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(c => c.ErrorMessage)).ToList();
                if (errors.Any())
                {
                    return BadRequest(new TokenResponse
                    {
                        Error = $"{string.Join(",", errors)}"
                    });
                }
            }

            var signupResponse = await userService.SignupAsync(signupRequest);

            if (!signupResponse.Success)
            {
                return UnprocessableEntity(signupResponse);
            }

            return Ok(signupResponse.Email);
        }

        [Authorize]
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            var logout = await userService.LogoutAsync(UserID);

            if (!logout.Success)
            {
                return UnprocessableEntity(logout);
            }

            return Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateProduct([FromBody] User model)
        {
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        await userService.UpdateUser(model);

            //        return Ok();
            //    }
            //    catch (Exception ex)
            //    {
            //        if (ex.GetType().FullName ==
            //                 "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
            //        {
            //            return NotFound();
            //        }

            //        return BadRequest();
            //    }
            //}
            //hash password assssssssssssssss

            throw new NotImplementedException();
            //return BadRequest();
        }
    }
}
