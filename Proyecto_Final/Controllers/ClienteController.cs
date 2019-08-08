using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace Proyecto_Final.Controllers
{

    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _ClienteService;

        public ClienteController(IClienteService ClienteService)
        {
            _ClienteService = ClienteService;
        }



        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
               _ClienteService.GetAll()
           );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
               _ClienteService.Get(id)
           );
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Clientes model)
        {
            return Ok(
                _ClienteService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Clientes model)
        {
            return Ok(
                _ClienteService.Add(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _ClienteService.Delete(id)
            );
        }
    }
}
