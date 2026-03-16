using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analise_de_Algoritmos_T1.Interface
{
    internal interface ITipoEntrega
    {
        string Modalidade { get; }
        double CalcularValorEntrega(double pesoTotalKg);
    }
}
