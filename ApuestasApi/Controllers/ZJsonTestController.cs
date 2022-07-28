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
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApuestasApi.Controllers
{
    [Route("test/json")]
    [ApiController]
    public class ZJsonTestController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public ZJsonTestController(IUserRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult TestJson() 
        {
            try
            {
                var data = _repository.GetUsers();
                string json = JsonSerializer.Serialize(data);
                List<User> doubleData = new List<User>();
                doubleData = JsonSerializer.Deserialize<List<User>>(json);


                string jsonString = JsonSerializer.Serialize(json);

                return Ok(new { message = json, data = doubleData } );
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
