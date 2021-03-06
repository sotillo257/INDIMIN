using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogicaNegocio;
using Modelo;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace INDIMIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadanoController : ControllerBase
    {
        private readonly IConfiguration configuration;
        lnCiudadano _lnCiudadano;
        AccesoDato.Conexion _Conexion;
        public CiudadanoController(IConfiguration configuration, AccesoDato.Conexion conexion)
        {
            this.configuration = configuration;
            _lnCiudadano = new lnCiudadano(conexion);
            _Conexion = conexion;
        }

       
        // GET: api/<CiudadanoController>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var ciudadanos = await _lnCiudadano.ObtenerTodos();

            if (ciudadanos != null)
            {
                return Ok(new { Result = true,  Ciudadanos = ciudadanos });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al obtener los ciudadanos" });
            }
        }

        // GET api/<CiudadanoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var ciudadano = await _lnCiudadano.Obtener(id);

            if (ciudadano != null)
            {
                return Ok(new { Result = true, Ciudadanos = ciudadano });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al obtener el ciudadano" });
            }
        }

        // POST api/<CiudadanoController>
        [HttpPost("insert")]
        [AllowAnonymous]
        public async Task<IActionResult> Insertar(Ciudadano Ciudadano)
        {
            var ciudadano = await _lnCiudadano.Insertar(Ciudadano);

            if (ciudadano != null)
            {
                return Ok(new { Result = true, Ciudadano = ciudadano });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al insertar el ciudadano" });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Insert(Ciudadano Ciudadano)
        {
            var ciudadano = await _lnCiudadano.Insertar(Ciudadano);

            if (ciudadano != null)
            {
                return Ok(new { Result = true, Ciudadano = ciudadano });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al insertar el ciudadano" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Modificar([FromBody] Ciudadano Ciudadano)
        {
            var ciudadano = await _lnCiudadano.Modificar(Ciudadano);

            if (ciudadano != null)
            {
                return Ok(new { Result = true, Ciudadano = ciudadano });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al modificar el ciudadano" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var EstaEliminado = await _lnCiudadano.Eliminar(new Ciudadano() { Id = id });

                return Ok(new { Result = EstaEliminado });
           
        }
    }
}
