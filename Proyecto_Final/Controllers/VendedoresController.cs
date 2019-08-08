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
    public class VendedoresController : ControllerBase
    {
        private readonly IVendedoreService _VendedoreService;

        public VendedoresController(IVendedoreService VendedoreService)
        {
            _VendedoreService = VendedoreService;
        }



        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
               _VendedoreService.GetAll()
           );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
               _VendedoreService.Get(id)
           );
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Vendedores model)
        {
            return Ok(
                _VendedoreService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Vendedores model)
        {
            return Ok(
                _VendedoreService.Add(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _VendedoreService.Delete(id)
            );
        }
    }

}
