using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccesoDato;
using Modelo;

namespace LogicaNegocio
{
    public class lnCiudadano
    {

        adCiudadano adCiudadano;
        public lnCiudadano(AccesoDato.Conexion conexion)
        {
            adCiudadano = new adCiudadano(conexion);
        }

       
        public async Task<ICollection<Ciudadano>> ObtenerTodos()
        {           
            return await adCiudadano.ObtenerTodos(); ;
        }

        public async Task<Ciudadano> Obtener(int pId)
        {
            return await adCiudadano.Obtener(pId); ;
        }

        public async Task<Ciudadano> Insertar(Ciudadano pCiudadano)
        {
            return await adCiudadano.Insertar(pCiudadano); ;
        }

        public async Task<Ciudadano> Modificar(Ciudadano pCiudadano)
        {
            return await adCiudadano.Modificar(pCiudadano); ;
        }

        public async Task<bool> Eliminar(Ciudadano pCiudadano)
        {
            return await adCiudadano.Eliminar(pCiudadano); ;
        }
    }
}
