using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.Entities;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly DataContext context;
        private readonly ITokenService tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            this.tokenService = tokenService;
            this.context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponseDto>> Register(RegisterRequestDto registerRequestDto)
        {
            if (await context.Users.AnyAsync(x => x.Email == registerRequestDto.Email.ToLower())) return BadRequest("Account already available for this email");

            using var hmac = new HMACSHA512();

            var user = new User
            {
                FirstName = registerRequestDto.FirstName,
                LastName = registerRequestDto.LastName,
                Email = registerRequestDto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerRequestDto.Password)),
                PasswordSalt = hmac.Key
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return new RegisterResponseDto
            {
                id = user.Id,
                token = tokenService.CreateToken(user)
            };
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto loginRequestDto)
        {
            var user = await context.Users
                .SingleOrDefaultAsync(x => x.Email == loginRequestDto.Email);

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginRequestDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new LoginResponseDto
            {
                id = user.Id,
                token = tokenService.CreateToken(user)
            };
        }
    }
}