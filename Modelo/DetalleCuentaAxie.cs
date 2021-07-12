using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class DetalleCuentaAxie
    {
        public int CantidadSLP { get; set; }
        public int SLPEnRoninWallet { get; set; }
        public int SLPEnJuego { get; set; }
        public int DiasParaReclamarSLP { get; set; }
        public DateTime FechaParaReclamarSLP { get; set; }
        public int Ranking { get; set; }
        public int Copas { get; set; }
        public double SLP_A_USDT { get; set; }
        public int PromedioSLPDiario { get; set; }
        public int WinRate { get; set; }
    }
}
