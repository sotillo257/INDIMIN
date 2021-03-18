using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int DiaSemanaId { get; set; }
        public DiaSemana DiaSemana { get; set; }
        public int CiudadanoId { get; set; }
        public Ciudadano Ciudadano { get; set; }
    }
}
