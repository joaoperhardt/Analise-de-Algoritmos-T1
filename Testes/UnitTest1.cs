using Analise_de_Algoritmos_T1.Exception;
using Analise_de_Algoritmos_T1.Interface;
using Analise_de_Algoritmos_T1.Model;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace Testes
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPesoTotalPedido3Produtos()
        {
            ITipoEntrega entregaPac = new TipoEntregaPac();
            Pedido pedido = new Pedido(entregaPac);
            pedido.AdicionarProduto(new Produto("Camisa polo", 20.0, 0.5));
            pedido.AdicionarProduto(new Produto("Calça Jeans", 120, 0.25));
            pedido.AdicionarProduto(new Produto("Carrinho de mão", 250, 3));

            double pesoTotal = pedido.CalcularPesoTotal();
            NUnit.Framework.Assert.AreEqual(3.75, pesoTotal);
        }

        [Test]
        public void TestExcaoProdutoPesoNegativo()
        {
            NUnit.Framework.Assert.Catch<ProdutoConstrutorException>(() =>
            {
                var produto = new Produto("Camisa", 20, -2);
            });
        }

        [Test]
        public void TestExecaoProdutoValorNegativo()
        {
            NUnit.Framework.Assert.Catch<ProdutoConstrutorException>(() =>
            {
                var produto = new Produto("Camisa", -20, 2);
            });
        }

        [Test]
        public void TestPedidoEntregaIncompativel()
        {
            Pedido pedido = new Pedido(new TipoEntregaPac());
            pedido.AdicionarProduto(new Produto("Caixa muito pesada", 200, 200));
            NUnit.Framework.Assert.Catch<TipoEntregaIncompativelException>(() => pedido.CalcularValorEntrega());
        }

        [Test]
        public void TestCalcularValorEntregaTipoEntregaPac()
        {
            Pedido pedido = new Pedido(new TipoEntregaPac());
            pedido.AdicionarProduto(new Produto("Camisa", 20, 0.3));

            NUnit.Framework.Assert.AreEqual(10, pedido.CalcularValorEntrega());
        }

        [Test]
        public void TestCalcularValorEntregaTipoEntregaRetiradaLocal()
        {
            Pedido pedido = new Pedido(new TipoEntregaRetiradaLocal());
            pedido.AdicionarProduto(new Produto("Calça Jeans", 200, 0.5));
            pedido.AdicionarProduto(new Produto("Bermuda", 40, 0.5));
            pedido.AdicionarProduto(new Produto("Chinelo", 200, 0.5));

            NUnit.Framework.Assert.AreEqual(0, pedido.CalcularValorEntrega());

        }

        [Test]
        public void TestCalcularValorEntregaTipoEntregaSedex()
        {
            Pedido pedido = new Pedido(new TipoEntregaSedex());
            pedido.AdicionarProduto(new Produto("Calça Jeans", 200, 0.5));
            pedido.AdicionarProduto(new Produto("Bermuda", 40, 0.5));
            pedido.AdicionarProduto(new Produto("Chinelo", 200, 0.5));

            NUnit.Framework.Assert.AreEqual(54, pedido.CalcularValorEntrega());
        }

    }
}