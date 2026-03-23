using Analise_de_Algoritmos_T1.Model;
using Analise_de_Algoritmos_T1.Enum;
using NUnit.Framework;
using Xunit;

namespace Analise_de_Algoritmos_T1_Tests
{
    public class UnitTest2
    {
        [Test]
        public void TestValorAcaoAlterado250()
        {
            Acao acaoMercado = new Acao("Mercado Livre", 150);
            Investidor pedroInvestidor = new Investidor("Pedro");
            acaoMercado.RegistrarOrdem(new Ordem(TipoOrdem.Compra, pedroInvestidor, 250));

            Investidor joao = new Investidor("João");

            acaoMercado.InscreverInvestidor(joao);
            acaoMercado.InscreverInvestidor(pedroInvestidor);

            acaoMercado.RegistrarOrdem(new Ordem(TipoOrdem.Venda, joao, 250));

            Assert.That(acaoMercado.GetValorAcao() == 250);
        }

        [Test]
        public void TestSequenciaDeOrdensAtualizaParaUltimoMatch()
        {
            var acao = new Acao("Empresa3", 100);
            var a = new Investidor("A");
            var b = new Investidor("B");

            acao.RegistrarOrdem(new Ordem(TipoOrdem.Compra, a, 100));
            acao.RegistrarOrdem(new Ordem(TipoOrdem.Compra, a, 150));
            acao.RegistrarOrdem(new Ordem(TipoOrdem.Venda, b, 150));

            Assert.AreEqual(150, acao.GetValorAcao());
        }

        [Test]
        public void TestMultiplosInvestidoresInscritosRecebemNotificacao()
        {
            var acao = new Acao("Tesla", 300);
            var investidor1 = new Investidor("Alice");
            var investidor2 = new Investidor("Bob");
            var investidor3 = new Investidor("Carlos");

            acao.InscreverInvestidor(investidor1);
            acao.InscreverInvestidor(investidor2);
            acao.InscreverInvestidor(investidor3);

            acao.RegistrarOrdem(new Ordem(TipoOrdem.Compra, investidor1, 350));
            acao.RegistrarOrdem(new Ordem(TipoOrdem.Venda, investidor2, 350));

            Assert.AreEqual(350, acao.GetValorAcao());
        }

        [Test]
        public void TestOrdemCompraSemMatchNaoAlteraValor()
        {
            var acao = new Acao("Nvidia", 800);
            var investidor = new Investidor("Investidor");

            acao.RegistrarOrdem(new Ordem(TipoOrdem.Compra, investidor, 850));

            Assert.AreEqual(800, acao.GetValorAcao());
        }

        [Test]
        public void TestOrdemVendaSemMatchNaoAlteraValor()
        {
            var acao = new Acao("Apple", 180);
            var investidor = new Investidor("Investidor");

            acao.RegistrarOrdem(new Ordem(TipoOrdem.Venda, investidor, 170));

            Assert.AreEqual(180, acao.GetValorAcao());
        }

        [Test]
        public void TestMultiplasOrdensAguardandoMatch()
        {
            var acao = new Acao("Amazon", 150);
            var comprador1 = new Investidor("Comprador1");
            var comprador2 = new Investidor("Comprador2");
            var comprador3 = new Investidor("Comprador3");
            var vendedor = new Investidor("Vendedor");

            acao.RegistrarOrdem(new Ordem(TipoOrdem.Compra, comprador1, 160));
            acao.RegistrarOrdem(new Ordem(TipoOrdem.Compra, comprador2, 170));
            acao.RegistrarOrdem(new Ordem(TipoOrdem.Compra, comprador3, 180));

            Assert.AreEqual(150, acao.GetValorAcao());

            acao.RegistrarOrdem(new Ordem(TipoOrdem.Venda, vendedor, 160));

            Assert.AreEqual(160, acao.GetValorAcao());
        }

        [Test]
        public void TestMatchComApenasUmaOrdemDoTipoOposto()
        {
            var acao = new Acao("Google", 2800);
            var comprador = new Investidor("Comprador");
            var vendedor1 = new Investidor("Vendedor1");
            var vendedor2 = new Investidor("Vendedor2");

            acao.RegistrarOrdem(new Ordem(TipoOrdem.Venda, vendedor1, 2750));
            acao.RegistrarOrdem(new Ordem(TipoOrdem.Venda, vendedor2, 2750));

            acao.RegistrarOrdem(new Ordem(TipoOrdem.Compra, comprador, 2750));

            Assert.AreEqual(2750, acao.GetValorAcao());

            acao.RegistrarOrdem(new Ordem(TipoOrdem.Compra, comprador, 2750));

            Assert.AreEqual(2750, acao.GetValorAcao());
        }

        [Test]
        public void TestValorAcaoNaoAlteraComMatchDeMesmoTipo()
        {
            var acao = new Acao("Microsoft", 400);
            var investidor1 = new Investidor("Inv1");
            var investidor2 = new Investidor("Inv2");

            acao.RegistrarOrdem(new Ordem(TipoOrdem.Compra, investidor1, 410));
            acao.RegistrarOrdem(new Ordem(TipoOrdem.Compra, investidor2, 410));

            Assert.AreEqual(400, acao.GetValorAcao());
        }

        [Test]
        public void TestMatchComValoresIguaisAposOrdensPendentes()
        {
            var acao = new Acao("Netflix", 500);
            var comprador = new Investidor("Comprador");
            var vendedor = new Investidor("Vendedor");

            acao.RegistrarOrdem(new Ordem(TipoOrdem.Venda, vendedor, 480));
            Assert.AreEqual(500, acao.GetValorAcao());

            acao.RegistrarOrdem(new Ordem(TipoOrdem.Compra, comprador, 480));

            Assert.AreEqual(480, acao.GetValorAcao());
        }
    }
}