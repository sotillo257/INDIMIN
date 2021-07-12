using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo
{
    public class CuentaAxie
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string RoninWallet { get; set; }
        public int UsuariosId { get; set; }
        [NotMapped]
        public DetalleCuentaAxie DetalleCuentaAxie { get; set; }

    }
}
