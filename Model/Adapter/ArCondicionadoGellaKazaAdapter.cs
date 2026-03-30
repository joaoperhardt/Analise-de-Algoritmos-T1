using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoritmosDotNet;
using Analise_de_Algoritmos_T1.Interface;

namespace Analise_de_Algoritmos_T1.Model.Adapter
{
    internal class ArCondicionadoGellaKazaAdapter : IArCondicionado
    {
        private readonly ArCondicionadoGellaKaza _arCondicionado;

        public ArCondicionadoGellaKazaAdapter(ArCondicionadoGellaKaza arCondicionado)
        {
            _arCondicionado = arCondicionado;
        }

        public void Ligar()
        {
            _arCondicionado.Ativar();
        }

        public void Desligar()
        {
            _arCondicionado.Desativar();
        }

        public void AumentarTemperatura()
        {
            _arCondicionado.AumentarTemperatura();
        }

        public void DiminuirTemperatura()
        {
            _arCondicionado.DiminuirTemperatura();
        }

        public void DefinirTemperatura(int temperatura)
        {
            int temperaturaAtual = _arCondicionado.GetTemperatura();

            // Ajusta temperatura gradualmente
            while (temperaturaAtual < temperatura)
            {
                _arCondicionado.AumentarTemperatura();
                temperaturaAtual++;
            }

            while (temperaturaAtual > temperatura)
            {
                _arCondicionado.DiminuirTemperatura();
                temperaturaAtual--;
            }
        }

        public int ObterTemperatura()
        {
            return _arCondicionado.GetTemperatura();
        }

        public bool EstaLigado()
        {
            return _arCondicionado.EstaLigado();
        }
    }
}
