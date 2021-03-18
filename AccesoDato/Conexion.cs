using Microsoft.EntityFrameworkCore;
using System;
using Modelo;
namespace AccesoDato
{
    public class Conexion : DbContext
    {
        //public Conexion(DbContextOptions<Conexion> options) : base(options) 
        //{
            
        //}

        public DbSet<Ciudadano> Ciudadano { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<DiaSemana> DiaSemana { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Data Source=SOTILLOCOMPUTER;Initial Catalog=INDIMIN;Persist Security Info=True;User ID=SA;Password=12345;");
        }
    }


       

}
