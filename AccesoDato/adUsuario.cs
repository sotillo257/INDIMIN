using System;
using System.Collections.Generic;
using System.Text;
using Modelo;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDato
{
    public class adUsuario
    {
        Conexion _Conexion;
        public adUsuario(Conexion conexion)
        {
            _Conexion = conexion;
        }

        public async Task<List<Usuarios>> ObtenerTodos()
        {
            try
            {
                List<Usuarios> Usuarioss = null;

                Usuarioss = await _Conexion.Usuarios.ToListAsync();
                return Usuarioss;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<Usuarios> Obtener(int pId)
        {
            try
            {
                Usuarios Usuarioss = null;

                Usuarioss = await _Conexion.Usuarios.Where(x => x.Id == pId).FirstOrDefaultAsync();
                return Usuarioss;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Usuarios> Login(string Correo, string Clave)
        {
            try
            {
                await Task.CompletedTask;
                Usuarios Usuarioss = null;

                Usuarioss =  _Conexion.Usuarios.SingleOrDefault(x => x.Correo == Correo && x.Clave == Clave);
                return Usuarioss;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Usuarios> Insertar(Usuarios pUsuarios)
        {
            try
            {

                await _Conexion.Usuarios.AddAsync(pUsuarios);
                await _Conexion.SaveChangesAsync();


                return pUsuarios;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Usuarios> Modificar(Usuarios pUsuarios)
        {
            try
            {

                _Conexion.Usuarios.Update(pUsuarios);
                await _Conexion.SaveChangesAsync();

                return pUsuarios;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Eliminar(Usuarios pUsuarios)
        {
            try
            {
                _Conexion.Usuarios.Remove(pUsuarios);
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
