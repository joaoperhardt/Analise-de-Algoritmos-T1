using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analise_de_Algoritmos_T1.Exception;
using Analise_de_Algoritmos_T1.Interface;

namespace Analise_de_Algoritmos_T1.Model
{
    public class Pedido
    {
        private readonly List<Produto> _produtos;
        private ITipoEntrega _tipoEntrega;

        public Pedido(ITipoEntrega tipoEntrega)
        {
            _tipoEntrega = tipoEntrega ?? throw new ArgumentNullException(nameof(tipoEntrega));
            _produtos = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            _produtos.Add(produto);
        }

        public double CalcularPesoTotal()
        {
            return _produtos.Sum(p => p.PesoKg);
        }

        public double CalcularValorEntrega()
        {
            var pesoTotal = CalcularPesoTotal();
            return _tipoEntrega.CalcularValorEntrega(pesoTotal);
        }

        public bool PodeSerEntregue()
        {
            try
            {
                CalcularValorEntrega();
                return true;
            }
            catch (TipoEntregaIncompativelException)
            {
                return false;
            }
        }

        public string ObterResumoEntrega()
        {
            double pesoTotal = CalcularPesoTotal();

            try
            {
                double valor = CalcularValorEntrega();
                return $"{_tipoEntrega.Modalidade}: R$ {valor:F2} para {pesoTotal:F2}kg";
            }
            catch (TipoEntregaIncompativelException)
            {
                return $"{_tipoEntrega.Modalidade}: Não disponível para {pesoTotal:F2}kg";
            }
        }

        public void AlterarTipoEntrega(ITipoEntrega novoTipo)
        {
            _tipoEntrega = novoTipo ?? throw new ArgumentNullException(nameof(novoTipo));
        }
    }
}
