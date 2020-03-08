using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceAppGrupoCriar.Model
{
    // Classe do Modelo Piloto
    public class Piloto
    {
        public int codigoPiloto { get; set; }
        public string nomePiloto { get; set; }
        public TimeSpan hora { get; set; }
        public int numeroVolta { get; set; }
        public double velocidadeMediaVolta { get; set; }
        public TimeSpan tempoVolta { get; set; }
    }
}
