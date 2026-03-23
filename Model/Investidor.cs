using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Analise_de_Algoritmos_T1.Model
{
    public class Investidor
    {
        private string _nome;
        private List<Ordem> _ordens;

        public Investidor(string nome)
        {
            this._nome = nome;
            _ordens = new List<Ordem>();
        }

        public void NotificarAlteracaoValor(double novoValorAcao, string nomeAcao)
        {
            Console.WriteLine("Caro/a " + _nome + " a" + " ação " + nomeAcao + " agora está valendo " + novoValorAcao);
        }
    }
}
