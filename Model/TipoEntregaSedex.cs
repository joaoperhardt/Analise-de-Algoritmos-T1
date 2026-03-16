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
        public string Modalidade => "Sedex";

        public double CalcularValorEntrega(double pesoTotalKg)
        {
            if (pesoTotalKg <= 0.5)
                return 12.50;

            if (pesoTotalKg <= 1)
                return 20;

            return CalcularValorAcimaDe1Kg(pesoTotalKg);
        }

        private double CalcularValorAcimaDe1Kg(double pesoTotalKg)
        {
            var valorBase = 46.50;
            var valorAdicional = CalcularValorAdicional(pesoTotalKg);
            return valorBase + valorAdicional;
        }

        private double CalcularValorAdicional(double pesoTotalKg)
        {
            var pesoAdicionalKg = pesoTotalKg - 1;
            var quantidadeCentenas = pesoAdicionalKg / 0.1;
            return quantidadeCentenas * 1.5;
        }
    }
}
