using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
        public List<CuentaAxie> CuentasAxie { get; set; }
        public int idRol { get; set; }
    }
}
