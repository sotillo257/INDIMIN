using System;
using System.Collections.Generic;
using System.Text;
using Modelo;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDato
{
    public class adCiudadano
    {
        private string _Conexion;
        public adCiudadano(string Conexion)
        {
            _Conexion = Conexion;
        }

        public async Task<List<Ciudadano>> ObtenerTodos()
        {
            try
            {
                List<Ciudadano> ciudadanos = null;
                using (var conexion = new Conexion(_Conexion))
                {
                    ciudadanos = await conexion.Ciudadano.ToListAsync();
                }
                return ciudadanos;
            }
            catch (Exception ex)
            {
                throw; 
            }
            
        }

        public async Task<Ciudadano> Obtener(int pId)
        {
            try
            {
                Ciudadano ciudadanos = null;
                using (var conexion = new Conexion(_Conexion))
                {
                    ciudadanos = await conexion.Ciudadano.Where(x => x.Id == pId).FirstOrDefaultAsync();
                }
                return ciudadanos;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<Ciudadano> Insertar(Ciudadano pCiudadano) {
            try
            {
                using (var conexion = new Conexion(_Conexion))
                {
                    await conexion.Ciudadano.AddAsync(pCiudadano);
                    conexion.SaveChanges();
                }

                return pCiudadano;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<Ciudadano> Modificar(Ciudadano pCiudadano)
        {
            try
            {
                using (var conexion = new Conexion(_Conexion))
                {
                    await conexion.Ciudadano.Update(pCiudadano).ReloadAsync();
                    conexion.SaveChanges();
                }

                return pCiudadano;
            }
            catch (Exception)
            {

                throw;
            }           
        }

        public async Task<bool> Eliminar(Ciudadano pCiudadano)
        {
            try
            {                 
                using (var conexion = new Conexion(_Conexion))
                {
                  await conexion.Ciudadano.Remove(pCiudadano).ReloadAsync();
                    object p = conexion.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }




    }
}
