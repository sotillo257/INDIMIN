using System;
using System.Collections.Generic;
using System.Text;
using Modelo;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDato
{
    public class adCuentaAxie
    {
        Conexion _Conexion;
        public adCuentaAxie(Conexion conexion)
        {
            _Conexion = conexion;
        }

        public async Task<List<CuentaAxie>> ObtenerTodos()
        {
            try
            {
                List<CuentaAxie> CuentaAxies = null;

                CuentaAxies = await _Conexion.CuentaAxie.ToListAsync();
                return CuentaAxies;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<List<CuentaAxie>> ObtenerTodos(int UsuarioID)
        {
            try
            {
                List<CuentaAxie> CuentaAxies = null;

                CuentaAxies = await _Conexion.CuentaAxie.Where(x => x.UsuariosId == UsuarioID).ToListAsync();
                return CuentaAxies;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<CuentaAxie> Obtener(int pId)
        {
            try
            {
                CuentaAxie CuentaAxies = null;

                CuentaAxies = await _Conexion.CuentaAxie.Where(x => x.Id == pId).FirstOrDefaultAsync();
                return CuentaAxies;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<CuentaAxie> Insertar(CuentaAxie pCuentaAxie)
        {
            try
            {

                await _Conexion.CuentaAxie.AddAsync(pCuentaAxie);
                await _Conexion.SaveChangesAsync();


                return pCuentaAxie;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<CuentaAxie> Modificar(CuentaAxie pCuentaAxie)
        {
            try
            {

                _Conexion.CuentaAxie.Update(pCuentaAxie);
                await _Conexion.SaveChangesAsync();

                return pCuentaAxie;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Eliminar(CuentaAxie pCuentaAxie)
        {
            try
            {
                _Conexion.CuentaAxie.Remove(pCuentaAxie);
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
