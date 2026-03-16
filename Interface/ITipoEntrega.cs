using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analise_de_Algoritmos_T1.Interface
{
    public interface ITipoEntrega
    {
        string Modalidade { get; }
        double CalcularValorEntrega(double pesoTotalKg);
    }
}
