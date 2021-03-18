using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Ciudadano
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public ICollection<Tarea> Tareas { get; set; }
    }
}
