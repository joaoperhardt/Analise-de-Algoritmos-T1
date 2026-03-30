using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoritmosDotNet;
using Analise_de_Algoritmos_T1.Interface;

namespace Analise_de_Algoritmos_T1.Model.Adapter
{
    internal class LampadaPhelippesAdapter : ILampada
    {
        private readonly LampadaPhellipes _lampada;

        public LampadaPhelippesAdapter(LampadaPhellipes lampada)
        {
            _lampada = lampada;
        }

        public void Ligar()
        {
            _lampada.SetIntensidade(100); // Liga com intensidade máxima
        }

        public void Desligar()
        {
            _lampada.SetIntensidade(0); // Intensidade 0 = desligada
        }

        public bool EstaLigada()
        {
            return _lampada.GetIntensidade() > 0;
        }
    }
}
