using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analise_de_Algoritmos_T1.Interface;

namespace Analise_de_Algoritmos_T1.Model
{
    internal class TipoEntregaSedex : ITipoEntrega
    {
        public double CalcularValorEntrega(double pesoTotalKg)
        {
            if (pesoTotalKg <= 0.5)
            {
                return 12.50;
            }

            if (pesoTotalKg <= 1)
            {
                return 20;
            }

            return 46.50 + CalcularValorAdicional(pesoTotalKg);
        }

        private double CalcularValorAdicional(double pesoTotalKg)
        {
            return ((pesoTotalKg - 1) / 0.1) * 1.5;
        }
    }
}
