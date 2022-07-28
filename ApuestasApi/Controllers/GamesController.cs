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
using ApuestasApi.Models;

namespace ApuestasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _repository;

        public GamesController(IGamesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Estatus
        [HttpGet]
        public IActionResult GetGames()
        {
            try
            {
                var data = _repository.GetGames();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error" });
            }

        }

        // GET: api/Estatus/5
        [HttpGet("{id}")]
        public IActionResult GetGameById(int id)
        {
            try
            {
                var data = _repository.GetGameById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditGame(int id, [FromBody] EditGame editGame)
        {
            try
            {
                int result = _repository.EditGame(id, editGame);
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
        public IActionResult DeleteGame(int id)
        {
            try
            {
                int result = _repository.DeleteGame(id);
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
        public IActionResult PostGame([FromBody] EditGame editGame)
        {
            try
            {
                int result = _repository.PostGame(editGame);
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