using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2019AM606.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2019AM606.Controllers
{
  //  [Route("api/[controller]")]
    [ApiController]
    public class productosController : ControllerBase
    {


        private readonly ventasContext contexto;
        public productosController(ventasContext mi)
        {
            contexto = mi;
        }


        [HttpGet]
        [Route("api/productos")]
        public IActionResult Get()
        {
            IEnumerable<models.Productos> l = (from m in contexto.Productos select m);
            if (l.Count() > 0)
            {
                return Ok(l);

            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/productos/{id}")]
        public IActionResult Get(int id)
        {
            Productos m = (from e in contexto.Productos where e.id == id select e).FirstOrDefault();

            if (m != null)
            {
                return Ok(m);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("api/productos")]
        public IActionResult guardar([FromBody] Productos nuevo)
        {

            try
            {
                contexto.Productos.Add(nuevo);
                contexto.SaveChanges();
                return Ok(nuevo);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/productos")]
        public IActionResult actualizar([FromBody] Productos nuevo)
        {
            Productos existe = (from e in contexto.Productos where e.id == nuevo.id select e).FirstOrDefault();
            if (existe is null)
            {
                return NotFound();

            }

            existe.Producto = nuevo.Producto;
            existe.precio = nuevo.precio;
            contexto.Entry(existe).State = EntityState.Modified;
            contexto.SaveChanges();
            return Ok(existe);
        }
    }
}