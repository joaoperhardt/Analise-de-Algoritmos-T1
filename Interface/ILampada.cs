using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analise_de_Algoritmos_T1.Interface
{
    public interface ILampada
    {
        void Ligar();
        void Desligar();
        bool EstaLigada();
    }
}
