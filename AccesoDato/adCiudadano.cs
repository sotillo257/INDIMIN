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
        public async Task<List<Ciudadano>> ObtenerTodos()
        {
            try
            {
                List<Ciudadano> ciudadanos = null;
                using (var _Conexion = new Conexion())
                {
                    ciudadanos = await _Conexion.Ciudadano.ToListAsync();
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
                using (var _Conexion = new Conexion())
                {
                    ciudadanos = await _Conexion.Ciudadano.Where(x => x.Id == pId).FirstOrDefaultAsync();
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
                using (var _Conexion = new Conexion())
                {
                    await _Conexion.Ciudadano.AddAsync(pCiudadano);
                    _Conexion.SaveChanges();
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
                using (var _Conexion = new Conexion())
                {
                    await _Conexion.Ciudadano.Update(pCiudadano).ReloadAsync();
                    _Conexion.SaveChanges();
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
                using (var _Conexion = new Conexion())
                {
                  await  _Conexion.Ciudadano.Remove(pCiudadano).ReloadAsync();
                    object p =  _Conexion.SaveChanges();
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
