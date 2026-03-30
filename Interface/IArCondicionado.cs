using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analise_de_Algoritmos_T1.Interface
{
    public interface IArCondicionado
    {
        void Ligar();
        void Desligar();
        void AumentarTemperatura();
        void DiminuirTemperatura();
        void DefinirTemperatura(int temperatura);
        int ObterTemperatura();
        bool EstaLigado();
    }
}
