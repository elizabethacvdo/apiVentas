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
   // [Route("api/[controller]")]
    [ApiController]
    public class pedidosController : ControllerBase
    {

        private readonly ventasContext contexto;
        public pedidosController(ventasContext mi)
        {
            contexto = mi;
        }


        [HttpGet]
        [Route("api/pedidos")]
        public IActionResult Get()
        {
            var lista = (from m in contexto.Pedidos 
                         join c in contexto.Clientes on m.idCliente equals c.id
                         select new { m.id,m.FechaPedido,c.nombre });
            if (lista.Count() > 0)
            {
                return Ok(lista);

            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/pedidos/{id}")]
        public IActionResult Get(int id)
        {
            var m = (from e in contexto.Pedidos
                     join c in contexto.Clientes on
e.idCliente equals c.id
                     where e.id == id
                     select new
                     {e.id,e.FechaPedido,c.nombre}).FirstOrDefault();

            if (m != null)
            {
                return Ok(m);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("api/pedidos")]
        public IActionResult guardar([FromBody] Pedidos nuevo)
        {

            try
            {
                contexto.Pedidos.Add(nuevo);
                contexto.SaveChanges();
                return Ok(nuevo);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/pedidos")]
        public IActionResult actualizar([FromBody] Pedidos nuevo)
        {
            Pedidos existe = (from e in contexto.Pedidos where e.id == nuevo.id select e).FirstOrDefault();
            if (existe is null)
            {
                return NotFound();

            }

            existe.FechaPedido = nuevo.FechaPedido;
            existe.idCliente = nuevo.idCliente;
            contexto.Entry(existe).State = EntityState.Modified;
            contexto.SaveChanges();
            return Ok(existe);
        }
    }
}