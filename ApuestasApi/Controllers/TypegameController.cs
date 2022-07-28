using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApuestasApi.Models;
using ApuestasApi.Models.OtherModels;
using ApuestasApi.Repositories.IRepositories;
using ApuestasApi.Repositories;

namespace ApuestasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypegameController : ControllerBase
    {
        private readonly ITypeGameRepository _repository;

        public TypegameController(ITypeGameRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Estatus
        [HttpGet]
        public IActionResult GetTypegames()
        {
            try
            {
                var data = _repository.GetTypegames();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error" });
            }
        }

        // GET: api/Estatus/5
        [HttpGet("{id}")]
        public IActionResult GetTypegameById(int id)
        {
            try
            {
                var data = _repository.GetTypegameById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditTypegame(int id, [FromBody] EditTypeGame editTypegame)
        {
            try
            {
                int result = _repository.EditTypegame(id, editTypegame);
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
        public IActionResult DeleteTypegame(int id)
        {
            try
            {
                int result = _repository.DeleteTypegame(id);
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
        public IActionResult PostTypegame([FromBody] EditTypeGame editTypegame)
        {
            try
            {
                int result = _repository.PostTypegame(editTypegame);
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