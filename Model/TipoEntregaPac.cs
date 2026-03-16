using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analise_de_Algoritmos_T1.Exception;
using Analise_de_Algoritmos_T1.Interface;

namespace Analise_de_Algoritmos_T1.Model
{
    public class TipoEntregaPac : ITipoEntrega
    {
        public string Modalidade => "PAC";

        public double CalcularValorEntrega(double pesoTotalKg)
        {
            if (pesoTotalKg <= 1)
                return 10;

            if (pesoTotalKg <= 2)
                return 15;

            throw new TipoEntregaIncompativelException(
                $"PAC não aceita pedidos acima de 2kg (pedido com {pesoTotalKg:F2}kg)"
            );
        }
    }
}
