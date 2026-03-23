using Analise_de_Algoritmos_T1.Model;
using Analise_de_Algoritmos_T1.Enum;

namespace Analise_de_Algoritmos_T1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Investidor investidor1 = new Investidor("Gabriel");

            Investidor investidor2 = new Investidor("Pedro");

            Acao acaoMercado = new Acao("Mercado Livre", 200);
            acaoMercado.InscreverInvestidor(investidor1);
            acaoMercado.InscreverInvestidor(investidor2);
            acaoMercado.RegistrarOrdem(new Ordem(TipoOrdem.Venda, investidor1, 220));
            acaoMercado.RegistrarOrdem(new Ordem(TipoOrdem.Compra, investidor2, 220));
        }
    }
}
