using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Analise_de_Algoritmos_T1.Model
{
    public class Acao
    {
        private string _nome;
        private List<Ordem> _ordens;
        private double _valorAcao;
        private List<Investidor> _investidoresInscritos;


        public Acao(string nome, double valorAcao)
        {
            _nome = nome;
            _valorAcao = valorAcao;
            _ordens = new List<Ordem>();
            _investidoresInscritos = new List<Investidor>();
        }

        public void InscreverInvestidor(Investidor investidor)
        {
            this._investidoresInscritos.Add(investidor);
        }

        public void RegistrarOrdem(Ordem ordem)
        {
            this.AlteracaoDeValorNovaOrdem(ordem);

        }

        private void NotificarInvestidores()
        {
            foreach (Investidor investidor in _investidoresInscritos)
            {
                investidor.NotificarAlteracaoValor(this._valorAcao, this._nome);
            }
        }

        private void AlteracaoDeValorNovaOrdem(Ordem ordem)
        {
            int indiceOrdemOposta = _ordens.FindIndex(ordemContraposta => ordemContraposta.tipoOrdem != ordem.tipoOrdem
                                                  && ordemContraposta.valor == ordem.valor);

            if (indiceOrdemOposta > -1)
            {
                _ordens.Remove(_ordens[indiceOrdemOposta]);
                this.AtualizarValor(ordem.valor);
                return;
            }
            _ordens.Add(ordem);
        }

        private void AtualizarValor(double valor)
        {
            this._valorAcao = valor;
            this.NotificarInvestidores();
        }

        public double GetValorAcao()
        {
            return this._valorAcao;
        }
    }
}
