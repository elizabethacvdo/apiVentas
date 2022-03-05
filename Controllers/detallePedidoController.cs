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
    public class detallePedidoController : ControllerBase
    {

        private readonly ventasContext contexto;
        public detallePedidoController(ventasContext mi)
        {
            contexto = mi;
        }


        [HttpGet]
        [Route("api/detallepedidos")]
        public IActionResult Get()
        {
            var lista = (from m in contexto.detallePedidos join p in contexto.Pedidos on m.idPedido equals p.id
                         join pr in contexto.Productos on m.idProducto equals pr.id
                         
                         select new { m.id,p.FechaPedido,pr.Producto,pr.precio,m.cantidad });
            if (lista.Count() > 0)
            {
                return Ok(lista);

            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/detallepedidos/{id}")]
        public IActionResult Get(int id)
        {
            var ma = (from m in contexto.detallePedidos
                     join p in contexto.Pedidos on m.idPedido equals p.id
                     join pr in contexto.Productos on m.idProducto equals pr.id
                     where m.id == id
                     select new
                     { m.id, p.FechaPedido, pr.Producto, pr.precio, m.cantidad }).FirstOrDefault();

            if (ma != null)
            {
                return Ok(ma);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("api/detallepedidos")]
        public IActionResult guardar([FromBody] DetallePedidos nuevo)
        {

            try
            {
                contexto.detallePedidos.Add(nuevo);
                contexto.SaveChanges();
                return Ok(nuevo);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/detallepedidos")]
        public IActionResult actualizar([FromBody] DetallePedidos nuevo)
        {
            DetallePedidos existe = (from e in contexto.detallePedidos where e.id == nuevo.id select e).FirstOrDefault();
            if (existe is null)
            {
                return NotFound();

            }

            existe.idPedido = nuevo.idPedido;
            existe.idProducto= nuevo.idProducto;
            existe.cantidad = nuevo.cantidad;
            contexto.Entry(existe).State = EntityState.Modified;
            contexto.SaveChanges();
            return Ok(existe);
        }
    }
}