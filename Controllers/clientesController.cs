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
    public class clientesController : ControllerBase
    {
        private readonly ventasContext contexto;
        public clientesController(ventasContext mi)
        {
            contexto = mi;
        }


        [HttpGet]
        [Route("api/clientes")]
        public IActionResult Get()
        {
            var lista = (from m in contexto.Departamentos join c in contexto.Clientes on m.id equals c.idDepartamento
                         select new {c.id,c.nombre,m.departamento,c.FechaNac });
            if (lista.Count() > 0)
            {
                return Ok(lista);

            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/clientes/{id}")]
        public IActionResult Get(int id)
        {
            var m = (from e in contexto.Departamentos join c in contexto.Clientes on
                           e.id equals c.idDepartamento where c.id == id select new 
                           {c.id,c.nombre,c.idDepartamento,e.departamento,c.FechaNac}).FirstOrDefault();

            if (m != null)
            {
                return Ok(m);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("api/clientes")]
        public IActionResult guardar([FromBody] Clientes nuevo)
        {

            try
            {
                contexto.Clientes.Add(nuevo);
                contexto.SaveChanges();
                return Ok(nuevo);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/clientes")]
        public IActionResult actualizar([FromBody] Clientes nuevo)
        {
            Clientes existe = (from e in contexto.Clientes where e.id == nuevo.id select e).FirstOrDefault();
            if (existe is null)
            {
                return NotFound();

            }

            existe.nombre = nuevo.nombre;
            existe.idDepartamento = nuevo.idDepartamento;
            contexto.Entry(existe).State = EntityState.Modified;
            contexto.SaveChanges();
            return Ok(existe);
        }
    }
}