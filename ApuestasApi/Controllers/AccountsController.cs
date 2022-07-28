using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApuestasApi.Models.OtherModels;
using ApuestasApi.Models;
using ApuestasApi.Repositories;
using ApuestasApi.Repositories.IRepositories;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace ApuestasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AccountsController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        /*[HttpGet("RegisteredRefreshTokens")]
        public IActionResult GetRegisteredRefreshTokens() 
        {
            var data = _userRepository.GetTokens();
            return Ok(data);
        }*/

        [HttpPost("Register")]
        public IActionResult CreateUser([FromBody] EditUser user) 
        {
            try
            {
                int result = _userRepository.PostUser(user);
                if (result == 1)
                {
                    User proxyUser = new User();
                    proxyUser.Document = user.Document;
                    string token = BuildToken(proxyUser);
                    string refreshToken = BuildRefreshToken();
                    RefreshToken refreshTokenDto = new RefreshToken
                    {
                        userId = user.Document,
                        token = refreshToken
                    };
                    //RegisterRefreshToken(refreshTokenDto);
                    return Ok(new { token = token, refreshToken = refreshToken });
                }
                else
                {
                    return BadRequest(new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginInfo loginInfo) 
        {
            try 
            {
                User user = _userRepository.FindLogin(loginInfo);
                if (user != null) 
                {
                    string token = BuildToken(user);
                    string refreshToken = BuildRefreshToken();
                    RefreshToken refreshTokenDto = new RefreshToken
                    {
                        userId = user.Email,
                        token = refreshToken
                    };
                    //RegisterRefreshToken(refreshTokenDto);
                    return Ok(new { message = "Bienvenido " + user.FirstName + " " + user.LastName, token = token, refreshToken = refreshToken });
                } else 
                {
                    return BadRequest(new { message = "Usuario No Encontrado" });
                }
            } catch(Exception ex) 
            {
                return BadRequest(new { message = "Error al Tratar de Ingresar" });
            }
        }

        /*[HttpPost("Refresh")]
        public IActionResult Refresh([FromBody] RefreshRequest refreshRequest) 
        {
            try 
            {
                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration.GetSection("Authentication").GetSection("Issuer").Value,
                    ValidAudience = _configuration.GetSection("Authentication").GetSection("Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret_Key"])),
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KSAJDFLKSDAJNVKJASNAWPWORQIRPOWEQ")),
                    ClockSkew = TimeSpan.Zero
                };
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                try 
                {
                    handler.ValidateToken(refreshRequest.refreshToken, validationParameters, out SecurityToken validateToken);
                    RefreshToken refreshToken = _userRepository.GetTokens().Where(x => x.token == refreshRequest.refreshToken).FirstOrDefault();
                    if (refreshToken == null) 
                    {
                        return BadRequest(new { message = "Refresh Token no encontrado" });
                    }
                    User user = _userRepository.GetUserByDocument(refreshToken.userId);
                    if (user == null)
                    {
                        return BadRequest(new { message = "Usuario no encontrado" });
                    }
                    string newToken = BuildToken(user);
                    return Ok(new { message = "Token validado con exito", token = newToken });
                }
                catch (Exception ex) 
                {
                    return BadRequest(new { message = "Refresh Token invalido" });
                }
            }
            catch(Exception ex) 
            {
                return null;
            }
        }*/

        private string BuildRefreshToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret_Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration.GetSection("Authentication").GetSection("RefreshTokenExpirationHours").Value));
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Authentication").GetSection("Issuer").Value,
                audience: _configuration.GetSection("Authentication").GetSection("Audience").Value,
                signingCredentials: creds,
                expires: expiration);
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }


        private string BuildToken(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.Document));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret_Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration.GetSection("Authentication").GetSection("TokenExpirationHours").Value));
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Authentication").GetSection("Issuer").Value,
                audience: _configuration.GetSection("Authentication").GetSection("Audience").Value,
                claims: claims,
                signingCredentials: creds,
                expires: expiration);
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        /*private void RegisterRefreshToken(RefreshToken refresh) 
        {
            refresh.id = Guid.NewGuid();
            _userRepository.RegisterToken(refresh);
            return;
        }*/
    }
}
