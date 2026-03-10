using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analise_de_Algoritmos_T1.Exception;
using Analise_de_Algoritmos_T1.Interface;

namespace Analise_de_Algoritmos_T1.Model
{
    internal class TipoEntregaPac : ITipoEntrega
    {
        public double CalcularValorEntrega(double pesoTotalKg)
        {
            if (pesoTotalKg <= 1)
            {
                return 10;
            }

            if (pesoTotalKg <= 2)
            {
                return 15;
            }

            throw new TipoEntregaIncompativelException("Entregas acima de 2kg não são aceitas com PAC.");
        }
    }
}
