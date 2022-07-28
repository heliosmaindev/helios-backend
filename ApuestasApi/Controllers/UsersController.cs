using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApuestasApi.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using ApuestasApi.Models;
using ApuestasApi.Models.OtherModels;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ApuestasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Estatus
        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var data = _repository.GetUsers();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error" });
            }

        }

        // GET: api/Estatus/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var data = _repository.GetUserById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error" });
            }
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult EditUser(int id, [FromBody] EditUser editUser)
        {
            try
            {
                if (editUser.RangeId == 0)
                    editUser.RangeId = 1;

                int result = _repository.EditUser(id, editUser);
                if (result == 1)
                {
                    return Ok(new { message = "Editado con Exito" });
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

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                int result = _repository.DeleteUser(id);
                if (result == 1)
                {
                    return Ok(new { message = "Borrado con Exito" });
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

        [HttpPost]
        public IActionResult PostUser([FromBody] EditUser user)
        {
            try
            {
                int result = _repository.PostUser(user);
                if (result == 1)
                {
                    return Ok(new { message = "Insertado con Exito" });
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
    }
}
