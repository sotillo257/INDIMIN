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
        Conexion _Conexion;
        public adCiudadano(Conexion conexion)
        {
            _Conexion = conexion;
        }

        public async Task<List<Ciudadano>> ObtenerTodos()
        {
            try
            {
                List<Ciudadano> ciudadanos = null;
               
                    ciudadanos = await _Conexion.Ciudadano.ToListAsync();
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
                
                    ciudadanos = await _Conexion.Ciudadano.Where(x => x.Id == pId).FirstOrDefaultAsync();
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
                
                    await _Conexion.Ciudadano.AddAsync(pCiudadano);
                    await _Conexion.SaveChangesAsync();
                

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

                _Conexion.Ciudadano.Update(pCiudadano);
                    await _Conexion.SaveChangesAsync();

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
                _Conexion.Ciudadano.Remove(pCiudadano);
                    await _Conexion.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }




    }
}
