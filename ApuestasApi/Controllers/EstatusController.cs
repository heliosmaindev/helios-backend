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
    public class EstatusController : ControllerBase
    {
        private readonly IEstatusRepository _repository;

        public EstatusController(IEstatusRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Estatus
        [HttpGet]
        public IActionResult GetEstatuses()
        {
            try
            {
                var data = _repository.GetEstatus();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error" });
            }

        }

        // GET: api/Estatus/5
        [HttpGet("{id}")]
        public IActionResult GetEstatusById(int id)
        {
            try
            {
                var data = _repository.GetEstatusById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditStatus(int id, [FromBody] EditEstatus editEstatus) 
        {
            try 
            {
                int result = _repository.EditEstatus(id, editEstatus);
                if (result == 1) 
                {
                    return Ok(new { message = "Editado con Exito" });
                } else 
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
        public IActionResult DeleteStatus(int id) 
        {
            try 
            {
                int result = _repository.DeleteStatus(id);
                if (result == 1) 
                {
                    return Ok(new { message = "Borrado con Exito" });
                } else 
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
        public IActionResult PostStatus([FromBody] EditEstatus estatus)
        {
            try
            {
                int result = _repository.PostStatus(estatus);
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
