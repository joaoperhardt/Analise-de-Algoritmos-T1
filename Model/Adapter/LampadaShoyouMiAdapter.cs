using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoritmosDotNet;
using Analise_de_Algoritmos_T1.Interface;

namespace Analise_de_Algoritmos_T1.Model.Adapter
{
    internal class LampadaShoyouMiAdapter : ILampada
    {
        private readonly LampadaShoyuMi _lampada;

        public LampadaShoyouMiAdapter(LampadaShoyuMi lampada)
        {
            _lampada = lampada;
        }

        public void Ligar()
        {
            _lampada.Ligar();
        }

        public void Desligar()
        {
            _lampada.Desligar();
        }

        public bool EstaLigada()
        {
            return _lampada.EstaLigada();
        }
    }
}
