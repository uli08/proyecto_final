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
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _VentaService;

        public VentaController(IVentaService VentaService)
        {
            _VentaService = VentaService;
        }


        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
               _VentaService.GetAll()
           );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
               _VentaService.Get(id)
           );
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Ventas model)
        {
            return Ok(
                _VentaService.Add(model)
            );
        }


        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Ventas model)
        {
            return Ok(
                _VentaService.Add(model)
            );
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _VentaService.Delete(id)
            );
        }
    }
}
