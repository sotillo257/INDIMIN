using Microsoft.EntityFrameworkCore;
using System;
using Modelo;
namespace AccesoDato
{
    public class Conexion : DbContext
    {
        private string _Conexion;
        public Conexion(string Conexion) 
        {
            _Conexion = Conexion;
        }

        public DbSet<Ciudadano> Ciudadano { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<DiaSemana> DiaSemana { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(_Conexion);
        }
    }


       

}
