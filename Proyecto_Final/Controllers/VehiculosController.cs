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
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoService _VehiculoService;

        public VehiculosController(IVehiculoService VehiculoService)
        {
            _VehiculoService = VehiculoService;
        }



        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
               _VehiculoService.GetAll()
           );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
               _VehiculoService.Get(id)
           );
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Vehiculos model)
        {
            return Ok(
                _VehiculoService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Vehiculos model)
        {
            return Ok(
                _VehiculoService.Add(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _VehiculoService.Delete(id)
            );
        }
    }
}
