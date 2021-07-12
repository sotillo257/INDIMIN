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
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration configuration;
        lnUsuarios _lnUsuario;
        AccesoDato.Conexion _Conexion;
        public UsuarioController(IConfiguration configuration, AccesoDato.Conexion conexion)
        {
            this.configuration = configuration;
            _lnUsuario = new lnUsuarios(conexion);
            _Conexion = conexion;
        }

       
        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var Usuarios = await _lnUsuario.ObtenerTodos();

            if (Usuarios != null)
            {
                return Ok(new { Result = true,  Usuarios = Usuarios });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al obtener los Usuarios" });
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var Usuario = await _lnUsuario.Obtener(id);

            if (Usuario != null)
            {
                return Ok(new { Result = true, Usuarios = Usuario });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al obtener el Usuario" });
            }
        }

        // POST api/<UsuarioController>
        [HttpPost("insert")]
        [AllowAnonymous]
        public async Task<IActionResult> Insertar(Usuarios Usuario)
        {
            Usuario.idRol = 2;
            var Usuarios = await _lnUsuario.Insertar(Usuario);

            if (Usuarios != null)
            {
                return Ok(new { Result = true, Usuario = Usuarios });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al insertar el Usuario" });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Insert(Usuarios Usuario)
        {
            var Usuarios = await _lnUsuario.Insertar(Usuario);

            if (Usuarios != null)
            {
                return Ok(new { Result = true, Usuario = Usuarios });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al insertar el Usuario" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Modificar([FromBody] Usuarios Usuario)
        {
            var Usuarios = await _lnUsuario.Modificar(Usuario);

            if (Usuario != null)
            {
                return Ok(new { Result = true, Usuario = Usuarios });
            }
            else
            {
                return Ok(new { Result = false, Mensaje = "Error al modificar el Usuario" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var EstaEliminado = await _lnUsuario.Eliminar(new Usuarios() { Id = id });

                return Ok(new { Result = EstaEliminado });
           
        }
    }
}
