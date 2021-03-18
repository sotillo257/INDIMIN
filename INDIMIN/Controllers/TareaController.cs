using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using LogicaNegocio;

namespace INDIMIN.Controllers
{
    [Route("api/Tarea")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        
        [HttpGet]
        [Route("api/Tarea/ObtenerTodos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            lnCiudadano _lnCiudadano = new lnCiudadano();
            var ciudadanos = await _lnCiudadano.ObtenerTodos();

            if (ciudadanos != null)
            {
                return Ok(new { Result = true, Ciudadanos = ciudadanos });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al obtener los ciudadanos" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insertar(Ciudadano Ciudadano)
        {
            lnCiudadano _lnCiudadano = new lnCiudadano();
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
    }
}
