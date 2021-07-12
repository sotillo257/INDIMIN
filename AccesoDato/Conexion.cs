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
            _Conexion =  Conexion;
        }

        public Conexion(DbContextOptions<Conexion> options)
       : base(options)
        {
        }

        public virtual DbSet<Ciudadano> Ciudadano { get; set; }
        public virtual DbSet<Tarea> Tarea { get; set; }
        public virtual DbSet<DiaSemana> DiaSemana { get; set; }
        public virtual DbSet<CuentaAxie> CuentaAxie { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        //{
            
        //    optionsBuilder.UseSqlServer(_Conexion);
        //}
    }


       

}
