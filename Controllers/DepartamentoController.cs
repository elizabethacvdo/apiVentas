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
    public class DepartamentoController : ControllerBase
    {
        private readonly ventasContext contexto;
        public DepartamentoController(ventasContext mi)
        {
            contexto = mi;
        }


        [HttpGet]
        [Route("api/departamentos")]
        public IActionResult Get()
        {
            IEnumerable<models.Departamentos> departamentoslista = (from m in contexto.Departamentos select m);
            if (departamentoslista.Count() > 0)
            {
                return Ok(departamentoslista);

            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/departamentos/{id}")]
        public IActionResult Get(int id)
        {
            Departamentos m = (from e in contexto.Departamentos where e.id == id select e).FirstOrDefault();

            if (m != null)
            {
                return Ok(m);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("api/departamentos")]
        public IActionResult guardar([FromBody] Departamentos nuevo)
        {

            try
            {
                contexto.Departamentos.Add(nuevo);
                contexto.SaveChanges();
                return Ok(nuevo);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/departamentos")]
        public IActionResult actualizar([FromBody] Departamentos nuevo)
        {
            Departamentos existe = (from e in contexto.Departamentos where e.id == nuevo.id select e).FirstOrDefault();
            if (existe is null)
            {
                return NotFound();

            }

            existe.departamento = nuevo.departamento;
            contexto.Entry(existe).State = EntityState.Modified;
            contexto.SaveChanges();
            return Ok(existe);
        }


       
    }
}