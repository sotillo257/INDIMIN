using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccesoDato;
using Modelo;

namespace LogicaNegocio
{
    public class lnUsuarios
    {

        adUsuario adUsuarios;
        public lnUsuarios(AccesoDato.Conexion conexion)
        {
            adUsuarios = new adUsuario(conexion);
        }


        public async Task<ICollection<Usuarios>> ObtenerTodos()
        {           
            return await adUsuarios.ObtenerTodos(); ;
        }

        public async Task<Usuarios> Obtener(int pId)
        {
            return await adUsuarios.Obtener(pId); ;
        }
        public async Task<Usuarios> Login(string Correo, string Clave)
        {
            return await adUsuarios.Login(Correo, Clave); ;
        }

        public async Task<Usuarios> Insertar(Usuarios pUsuarios)
        {
            return await adUsuarios.Insertar(pUsuarios); ;
        }

        public async Task<Usuarios> Modificar(Usuarios pUsuarios)
        {
            return await adUsuarios.Modificar(pUsuarios); ;
        }

        public async Task<bool> Eliminar(Usuarios pUsuarios)
        {
            return await adUsuarios.Eliminar(pUsuarios); ;
        }
    }
}
