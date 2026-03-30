using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoritmosDotNet;
using Analise_de_Algoritmos_T1.Interface;

namespace Analise_de_Algoritmos_T1.Model.Adapter
{
    internal class ArCondicionadoVentoBaumnAdapter : IArCondicionado
    {
        private readonly ArCondicionadoVentoBaumn _arCondicionado;

        public ArCondicionadoVentoBaumnAdapter(ArCondicionadoVentoBaumn arCondicionado)
        {
            _arCondicionado = arCondicionado;
        }

        public void Ligar()
        {
            _arCondicionado.Ligar();
        }

        public void Desligar()
        {
            _arCondicionado.Desligar();
        }

        public void AumentarTemperatura()
        {
            int temperaturaAtual = _arCondicionado.GetTemperatura();
            _arCondicionado.DefinirTemperatura(temperaturaAtual + 1);
        }

        public void DiminuirTemperatura()
        {
            int temperaturaAtual = _arCondicionado.GetTemperatura();
            _arCondicionado.DefinirTemperatura(temperaturaAtual - 1);
        }

        public void DefinirTemperatura(int temperatura)
        {
            _arCondicionado.DefinirTemperatura(temperatura);
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
