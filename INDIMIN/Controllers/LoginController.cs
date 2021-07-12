using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelo;

namespace INDIMIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private lnUsuarios _lnUsuario;

        // TRAEMOS EL OBJETO DE CONFIGURACIÓN (appsettings.json)
        // MEDIANTE INYECCIÓN DE DEPENDENCIAS.
        public LoginController(IConfiguration configuration, AccesoDato.Conexion conexion)
        {
            this.configuration = configuration;
            _lnUsuario = new lnUsuarios(conexion);
        }


        // POST: api/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuarios usuarioLogin)
        {
            var _userInfo = await AutenticarUsuarioAsync(usuarioLogin.Correo, usuarioLogin.Clave);

            if (_userInfo != null)
            {
                var token = GenerarTokenJWT(_userInfo);
                return Ok(new { token = token, Usuario = _userInfo });
            }
            else
            {
                return Ok(new { result = false });
            }
        }

        // COMPROBAMOS SI EL USUARIO EXISTE EN LA BASE DE DATOS 
        private async Task<Usuarios> AutenticarUsuarioAsync(string usuario, string password)
        {
            // AQUÍ LA LÓGICA DE AUTENTICACIÓN //
           var user = await _lnUsuario.Login(usuario, password);
            if (user is null)
            {
                return null;
            }
            else
            {
                return user;
            }
            // Supondremos que el Usuario NO existe en la Base de Datos.
            // Retornamos NULL.
            //return null;
        }

        // GENERAMOS EL TOKEN CON LA INFORMACIÓN DEL USUARIO
        private string GenerarTokenJWT(Usuarios usuarioInfo)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.Id.ToString()),
                new Claim("nombre", "Jesus"),
                new Claim("apellidos", "Sotillo"),
                new Claim("IDUsuario",  usuarioInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Correo),
                new Claim(ClaimTypes.Role, "Admin")
            };
       

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
