using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analise_de_Algoritmos_T1.Interface;

namespace Analise_de_Algoritmos_T1.Model
{
    internal class TipoEntregaRetiradaLocal : ITipoEntrega
    {
        public string Modalidade => "Retirada no Local";

        public double CalcularValorEntrega(double pesoTotalKg)
        {
            return 0;
        }
    }
}
