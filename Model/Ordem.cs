using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analise_de_Algoritmos_T1.Enum;

namespace Analise_de_Algoritmos_T1.Model
{
    public class Ordem
    {
        public TipoOrdem tipoOrdem { get; private set; }
        public Investidor investidor { get; private set; }
        public double valor { get; private set; }
        public Ordem(TipoOrdem tipoOrdem, Investidor investidor, double valor)
        {
            this.tipoOrdem = tipoOrdem;
            this.investidor = investidor;
            this.valor = valor;
        }
    }
}
