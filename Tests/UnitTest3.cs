using System;
using System.Collections.Generic;
using Xunit;
using Analise_de_Algoritmos_T1.Model;
using Analise_de_Algoritmos_T1.Interface;
using Analise_de_Algoritmos_T1.Model.Command;
using NUnit.Framework;

namespace Analise_de_Algoritmos_T1.Tests
{
    public class UnitTest3
    {
        private class MockLampada : ILampada
        {
            public bool Ligada { get; private set; } = false;

            public void Ligar() => Ligada = true;
            public void Desligar() => Ligada = false;
            public bool EstaLigada() => Ligada;
        }

        private class MockPersiana : IPersiana
        {
            public bool Aberta { get; private set; } = false;

            public void Abrir() => Aberta = true;
            public void Fechar() => Aberta = false;
            public bool EstaAberta() => Aberta;
        }

        private class MockArCondicionado : IArCondicionado
        {
            public bool Ligado { get; private set; } = false;
            public int Temperatura { get; private set; } = 20;

            public void Ligar() => Ligado = true;
            public void Desligar() => Ligado = false;
            
            public void AumentarTemperatura()
            {
                if (Temperatura < 30)
                    Temperatura++;
            }

            public void DiminuirTemperatura()
            {
                if (Temperatura > 15)
                    Temperatura--;
            }

            public void DefinirTemperatura(int temperatura)
            {
                if (temperatura >= 15 && temperatura <= 30)
                    Temperatura = temperatura;
            }

            public int ObterTemperatura() => Temperatura;
            public bool EstaLigado() => Ligado;
        }

        [Test]
        public void TestAdicionarDispositivosAoSistema()
        {
            var sistema = new SistemaAutomacao();
            var lampada1 = new MockLampada();
            var lampada2 = new MockLampada();
            var persiana = new MockPersiana();
            var ar = new MockArCondicionado();

            sistema.AdicionarLampada(lampada1);
            sistema.AdicionarLampada(lampada2);
            sistema.AdicionarPersiana(persiana);
            sistema.AdicionarArCondicionado(ar);

            Assert.AreEqual(2, sistema.ObterQuantidadeLampadas());
            Assert.AreEqual(1, sistema.ObterQuantidadePersianas());
            Assert.AreEqual(1, sistema.ObterQuantidadeArCondicionados());
        }

        [Test]
        public void TestControlarLampadas()
        {
            var sistema = new SistemaAutomacao();
            var lampada1 = new MockLampada();
            var lampada2 = new MockLampada();
            var lampada3 = new MockLampada();

            sistema.AdicionarLampada(lampada1);
            sistema.AdicionarLampada(lampada2);
            sistema.AdicionarLampada(lampada3);

            sistema.LigarTodasLampadas();

            Assert.AreEqual(3, sistema.ObterLampadasLigadas());
            Assert.True(lampada1.EstaLigada());
            Assert.True(lampada2.EstaLigada());
            Assert.True(lampada3.EstaLigada());

            sistema.DesligarTodasLampadas();

            Assert.AreEqual(0, sistema.ObterLampadasLigadas());
            Assert.False(lampada1.EstaLigada());
            Assert.False(lampada2.EstaLigada());
            Assert.False(lampada3.EstaLigada());
        }

        [Test]
        public void TestControlarPersianaEArCondicionado()
        {
            var sistema = new SistemaAutomacao();
            var persiana1 = new MockPersiana();
            var persiana2 = new MockPersiana();
            var ar1 = new MockArCondicionado();
            var ar2 = new MockArCondicionado();

            sistema.AdicionarPersiana(persiana1);
            sistema.AdicionarPersiana(persiana2);
            sistema.AdicionarArCondicionado(ar1);
            sistema.AdicionarArCondicionado(ar2);

            sistema.AbrirTodasPersianas();

            Assert.True(persiana1.EstaAberta());
            Assert.True(persiana2.EstaAberta());
            Assert.AreEqual(2, sistema.ObterPerسianasAbertas());

            sistema.LigarTodosArCondicionados();

            Assert.True(ar1.EstaLigado());
            Assert.True(ar2.EstaLigado());
            Assert.AreEqual(2, sistema.ObterArCondicionadosLigados());

            sistema.DesligarTodosArCondicionados();
            sistema.FecharTodasPersianas();

            Assert.False(ar1.EstaLigado());
            Assert.False(ar2.EstaLigado());
            Assert.False(persiana1.EstaAberta());
            Assert.False(persiana2.EstaAberta());
        }

        [Test]
        public void TestModoSono()
        {
            var sistema = new SistemaAutomacao();
            var lampadas = new List<ILampada>
            {
                new MockLampada(),
                new MockLampada()
            };
            var persianas = new List<IPersiana>
            {
                new MockPersiana(),
                new MockPersiana()
            };
            var arCondicionados = new List<IArCondicionado>
            {
                new MockArCondicionado(),
                new MockArCondicionado()
            };

            foreach (var lampada in lampadas) sistema.AdicionarLampada(lampada);
            foreach (var persiana in persianas) sistema.AdicionarPersiana(persiana);
            foreach (var ar in arCondicionados) sistema.AdicionarArCondicionado(ar);

            sistema.LigarTodasLampadas();
            sistema.AbrirTodasPersianas();
            sistema.LigarTodosArCondicionados();

            Assert.AreEqual(2, sistema.ObterLampadasLigadas());
            Assert.AreEqual(2, sistema.ObterPerسianasAbertas());
            Assert.AreEqual(2, sistema.ObterArCondicionadosLigados());

            sistema.AtivarModoSono();

            Assert.AreEqual(0, sistema.ObterLampadasLigadas());
            Assert.AreEqual(0, sistema.ObterPerسianasAbertas());
            Assert.AreEqual(0, sistema.ObterArCondicionadosLigados());
        }

        [Test]
        public void TestModoTrabalho()
        {
            var sistema = new SistemaAutomacao();
            var lampadas = new List<ILampada>
            {
                new MockLampada(),
                new MockLampada()
            };
            var persianas = new List<IPersiana>
            {
                new MockPersiana(),
                new MockPersiana()
            };
            var arCondicionados = new List<IArCondicionado>
            {
                new MockArCondicionado(),
                new MockArCondicionado()
            };

            foreach (var lampada in lampadas) sistema.AdicionarLampada(lampada);
            foreach (var persiana in persianas) sistema.AdicionarPersiana(persiana);
            foreach (var ar in arCondicionados) sistema.AdicionarArCondicionado(ar);

            sistema.AtivarModoTrabalho();

            Assert.AreEqual(2, sistema.ObterLampadasLigadas());
            Assert.AreEqual(2, sistema.ObterPerسianasAbertas());
            Assert.AreEqual(2, sistema.ObterArCondicionadosLigados());

            foreach (var ar in arCondicionados)
            {
                Assert.AreEqual(25, ar.ObterTemperatura());
            }
        }
    }
}
