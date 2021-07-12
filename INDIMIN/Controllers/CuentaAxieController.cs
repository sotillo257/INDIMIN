using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogicaNegocio;
using Modelo;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace INDIMIN.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaAxieController : ControllerBase
    {
        private readonly IConfiguration configuration;
        lnCuentaAxie _lnCuentaAxie;
        AccesoDato.Conexion _Conexion;
        public CuentaAxieController(IConfiguration configuration, AccesoDato.Conexion conexion)
        {
            this.configuration = configuration;
            _lnCuentaAxie = new lnCuentaAxie(conexion);
            _Conexion = conexion;
        }

       
        // GET: api/<CuentaAxieController>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var aux = User.Claims.SingleOrDefault(x => x.Type == "IDUsuario");
            var CuentaAxies = await _lnCuentaAxie.ObtenerTodos(aux.Value);

            if (CuentaAxies != null)
            {
                return Ok(new { Result = true,  CuentaAxies = CuentaAxies });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al obtener los CuentaAxies" });
            }
        }

        // GET api/<CuentaAxieController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var CuentaAxie = await _lnCuentaAxie.Obtener(id);

            if (CuentaAxie != null)
            {
                return Ok(new { Result = true, CuentaAxies = CuentaAxie });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al obtener el CuentaAxie" });
            }
        }

        // POST api/<CuentaAxieController>
        [HttpPost("insert")]
        [AllowAnonymous]
        public async Task<IActionResult> Insertar(CuentaAxie CuentaAxie)
        {
            var aux = User.Claims.SingleOrDefault(x => x.Type == "IDUsuario");
            CuentaAxie.UsuariosId = int.Parse(aux.Value);
            var CuentaAxies = await _lnCuentaAxie.Insertar(CuentaAxie);

            if (CuentaAxies != null)
            {
                return Ok(new { Result = true, CuentaAxie = CuentaAxies });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al insertar el CuentaAxie" });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Insert(CuentaAxie CuentaAxie)
        {
            CuentaAxie.UsuariosId = int.Parse(User.Identity.Name);
            var CuentaAxies = await _lnCuentaAxie.Insertar(CuentaAxie);

            if (CuentaAxies != null)
            {
                return Ok(new { Result = true, CuentaAxie = CuentaAxies });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al insertar el CuentaAxie" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Modificar([FromBody] CuentaAxie CuentaAxie)
        {
            var aux = User.Claims.SingleOrDefault(x => x.Type == "IDUsuario");
            CuentaAxie.UsuariosId = int.Parse(aux.Value);
            var CuentaAxies = await _lnCuentaAxie.Modificar(CuentaAxie);

            if (CuentaAxies != null)
            {
                return Ok(new { Result = true, CuentaAxie = CuentaAxies });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al modificar el CuentaAxie" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var EstaEliminado = await _lnCuentaAxie.Eliminar(new CuentaAxie() { Id = id });

                return Ok(new { Result = EstaEliminado });
           
        }
    }
}
