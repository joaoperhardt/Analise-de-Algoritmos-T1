using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analise_de_Algoritmos_T1.Interface;
using Analise_de_Algoritmos_T1.Model.Command;

namespace Analise_de_Algoritmos_T1.Model
{
    internal class SistemaAutomacao
    {
        private readonly List<ILampada> _lampadas;
        private readonly List<IPersiana> _persianas;
        private readonly List<IArCondicionado> _arCondicionados;

        public SistemaAutomacao()
        {
            _lampadas = new List<ILampada>();
            _persianas = new List<IPersiana>();
            _arCondicionados = new List<IArCondicionado>();
        }


        public void AdicionarLampada(ILampada lampada)
        {
            _lampadas.Add(lampada);
        }

        public void AdicionarPersiana(IPersiana persiana)
        {
            _persianas.Add(persiana);
        }

        public void AdicionarArCondicionado(IArCondicionado arCondicionado)
        {
            _arCondicionados.Add(arCondicionado);
        }

  
        public void LigarTodasLampadas()
        {
            foreach (var lampada in _lampadas)
            {
                lampada.Ligar();
            }
        }
        public void DesligarTodasLampadas()
        {
            foreach (var lampada in _lampadas)
            {
                lampada.Desligar();
            }
        }
        public void AbrirTodasPersianas()
        {
            foreach (var persiana in _persianas)
            {
                persiana.Abrir();
            }
        }
        public void FecharTodasPersianas()
        {
            foreach (var persiana in _persianas)
            {
                persiana.Fechar();
            }
        }
        public void LigarTodosArCondicionados()
        {
            foreach (var ar in _arCondicionados)
            {
                ar.Ligar();
            }
        }
        public void DesligarTodosArCondicionados()
        {
            foreach (var ar in _arCondicionados)
            {
                ar.Desligar();
            }
        }
        public void DefinirTemperaturaGeral(int temperatura)
        {
            foreach (var ar in _arCondicionados)
            {
                ar.DefinirTemperatura(temperatura);
            }
        }
        public void AtivarModoSono()
        {
            var comando = new ModoSonoCommand(_lampadas, _persianas, _arCondicionados);
            comando.Executar();
        }
        public void AtivarModoTrabalho()
        {
            var comando = new ModoTrabalhoCommand(_lampadas, _persianas, _arCondicionados);
            comando.Executar();
        }

        public int ObterQuantidadeLampadas() => _lampadas.Count;

        public int ObterQuantidadePersianas() => _persianas.Count;

        public int ObterQuantidadeArCondicionados() => _arCondicionados.Count;

        public int ObterLampadasLigadas() => _lampadas.Count(l => l.EstaLigada());

        public int ObterPersianasAbertas() => _persianas.Count(p => p.EstaAberta());

        public int ObterArCondicionadosLigados() => _arCondicionados.Count(a => a.EstaLigado());

    }
}
