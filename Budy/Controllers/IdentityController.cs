using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Budy.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Budy.Controllers
{
    // PROTPTYPE CONTROLLER!
    
    
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto userDto)
        {
            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Username = userDto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto userDto)
        {
            // Check if user exists
            var userFromDb = new User();
            
            if (userDto.Username != userFromDb.Username)
            {
                return NotFound();
            }

            if (!VerifyPasswordHash(userDto.Password, userFromDb.PasswordHash, userFromDb.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(userFromDb);
            
            return Ok("TokenData");
        }

        private string CreateToken(User user)
        {
            // Claims: are properties that are describing the user that is authenticated,
            // for instance the userId, username, email or anything we want
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            
            // Symmetric Security Key
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("my top secret key"));
            
            // Credentials
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            
            // Payload
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
            
            return string.Empty;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}