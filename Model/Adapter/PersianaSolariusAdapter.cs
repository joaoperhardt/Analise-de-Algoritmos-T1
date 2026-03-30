using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoritmosDotNet;
using Analise_de_Algoritmos_T1.Interface;

namespace Analise_de_Algoritmos_T1.Model.Adapter
{
    internal class PersianaSolariusAdapter : IPersiana
    {
        private readonly PersianaSolarius _persiana;

        public PersianaSolariusAdapter(PersianaSolarius persiana)
        {
            _persiana = persiana;
        }

        public void Abrir()
        {
            _persiana.SubirPersiana();
        }

        public void Fechar()
        {
            _persiana.DescerPersiana();
        }

        public bool EstaAberta()
        {
            return _persiana.EstaAberta();
        }
    }
}
