using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analise_de_Algoritmos_T1.Interface;

namespace Analise_de_Algoritmos_T1.Model
{
    internal class Pedido
    {
        private ITipoEntrega _tipoEntrega;

        private List<Produto> _produtos;

        public Pedido(ITipoEntrega tipoEntrega, List<Produto> produtos)
            {
                _tipoEntrega = tipoEntrega;
                _produtos = produtos;
        }
    }
}
