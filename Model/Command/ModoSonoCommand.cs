using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analise_de_Algoritmos_T1.Interface;

namespace Analise_de_Algoritmos_T1.Model.Command
{
    internal class ModoSonoCommand : IComando
    {
        private readonly IEnumerable<ILampada> _lampadas;
        private readonly IEnumerable<IPersiana> _persianas;
        private readonly IEnumerable<IArCondicionado> _arCondicionados;

        public ModoSonoCommand(
            IEnumerable<ILampada> lampadas,
            IEnumerable<IPersiana> persianas,
            IEnumerable<IArCondicionado> arCondicionados)
        {
            _lampadas = lampadas;
            _persianas = persianas;
            _arCondicionados = arCondicionados;
        }

        public void Executar()
        {
            foreach (var lampada in _lampadas)
            {
                lampada.Desligar();
            }

            foreach (var persiana in _persianas)
            {
                persiana.Fechar();
            }

            foreach (var ar in _arCondicionados)
            {
                ar.Desligar();
            }
        }
    }
}
