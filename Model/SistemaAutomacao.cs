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

        #region Gerenciamento de Dispositivos

        /// <summary>
        /// Adiciona uma lâmpada ao sistema
        /// </summary>
        public void AdicionarLampada(ILampada lampada)
        {
            _lampadas.Add(lampada);
        }

        /// <summary>
        /// Adiciona uma persiana ao sistema
        /// </summary>
        public void AdicionarPersiana(IPersiana persiana)
        {
            _persianas.Add(persiana);
        }

        /// <summary>
        /// Adiciona um ar-condicionado ao sistema
        /// </summary>
        public void AdicionarArCondicionado(IArCondicionado arCondicionado)
        {
            _arCondicionados.Add(arCondicionado);
        }

        #endregion

        #region Controle Individual de Dispositivos

        /// <summary>
        /// Liga todas as lâmpadas
        /// </summary>
        public void LigarTodasLampadas()
        {
            foreach (var lampada in _lampadas)
            {
                lampada.Ligar();
            }
        }

        /// <summary>
        /// Desliga todas as lâmpadas
        /// </summary>
        public void DesligarTodasLampadas()
        {
            foreach (var lampada in _lampadas)
            {
                lampada.Desligar();
            }
        }

        /// <summary>
        /// Abre todas as persianas
        /// </summary>
        public void AbrirTodasPersianas()
        {
            foreach (var persiana in _persianas)
            {
                persiana.Abrir();
            }
        }

        /// <summary>
        /// Fecha todas as persianas
        /// </summary>
        public void FecharTodasPersianas()
        {
            foreach (var persiana in _persianas)
            {
                persiana.Fechar();
            }
        }

        /// <summary>
        /// Liga todos os ar-condicionados
        /// </summary>
        public void LigarTodosArCondicionados()
        {
            foreach (var ar in _arCondicionados)
            {
                ar.Ligar();
            }
        }

        /// <summary>
        /// Desliga todos os ar-condicionados
        /// </summary>
        public void DesligarTodosArCondicionados()
        {
            foreach (var ar in _arCondicionados)
            {
                ar.Desligar();
            }
        }

        /// <summary>
        /// Define a temperatura de todos os ar-condicionados
        /// </summary>
        public void DefinirTemperaturaGeral(int temperatura)
        {
            foreach (var ar in _arCondicionados)
            {
                ar.DefinirTemperatura(temperatura);
            }
        }

        #endregion

        #region Modos de Operação (Command Pattern)

        /// <summary>
        /// Ativa o Modo Sono
        /// - Ar-condicionado: DESLIGADO
        /// - Lâmpadas: DESLIGADAS
        /// - Persianas: FECHADAS
        /// </summary>
        public void AtivarModoSono()
        {
            var comando = new ModoSonoCommand(_lampadas, _persianas, _arCondicionados);
            comando.Executar();
        }

        /// <summary>
        /// Ativa o Modo Trabalho
        /// - Ar-condicionado: LIGADO (25°C)
        /// - Lâmpadas: LIGADAS
        /// - Persianas: ABERTAS
        /// </summary>
        public void AtivarModoTrabalho()
        {
            var comando = new ModoTrabalhoCommand(_lampadas, _persianas, _arCondicionados);
            comando.Executar();
        }

        #endregion

        #region Consultas de Estado

        /// <summary>
        /// Obtém a quantidade de lâmpadas no sistema
        /// </summary>
        public int ObterQuantidadeLampadas() => _lampadas.Count;

        /// <summary>
        /// Obtém a quantidade de persianas no sistema
        /// </summary>
        public int ObterQuantidadePersianas() => _persianas.Count;

        /// <summary>
        /// Obtém a quantidade de ar-condicionados no sistema
        /// </summary>
        public int ObterQuantidadeArCondicionados() => _arCondicionados.Count;

        /// <summary>
        /// Verifica quantas lâmpadas estão ligadas
        /// </summary>
        public int ObterLampadasLigadas() => _lampadas.Count(l => l.EstaLigada());

        /// <summary>
        /// Verifica quantas persianas estão abertas
        /// </summary>
        public int ObterPerسianasAbertas() => _persianas.Count(p => p.EstaAberta());

        /// <summary>
        /// Verifica quantos ar-condicionados estão ligados
        /// </summary>
        public int ObterArCondicionadosLigados() => _arCondicionados.Count(a => a.EstaLigado());

        #endregion
    }
}
