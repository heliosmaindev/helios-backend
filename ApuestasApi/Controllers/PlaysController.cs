using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApuestasApi.Models;
using ApuestasApi.Repositories.IRepositories;
using ApuestasApi.Repositories;
using ApuestasApi.Models.OtherModels;

namespace ApuestasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaysController : ControllerBase
    {
        private readonly IPlaysRepository _repository;

        public PlaysController(IPlaysRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Estatus
        [HttpGet]
        public IActionResult GetPlays()
        {
            try
            {
                var data = _repository.GetPlays();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error" });
            }

        }

        // GET: api/Estatus/5
        [HttpGet("{id}")]
        public IActionResult GetPlayById(int id)
        {
            try
            {
                var data = _repository.GetPlayById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditUser(int id, [FromBody] EditPlay editPlay)
        {
            try
            {
                int result = _repository.EditPlay(id, editPlay);
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
        public IActionResult DeletePlay(int id)
        {
            try
            {
                int result = _repository.DeletePlay(id);
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
        public IActionResult PostPlay([FromBody] EditPlay play)
        {
            try
            {
                int result = _repository.PostPlay(play);
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
