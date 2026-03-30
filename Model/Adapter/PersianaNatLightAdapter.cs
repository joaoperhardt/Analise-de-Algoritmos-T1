using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoritmosDotNet;
using Analise_de_Algoritmos_T1.Interface;

namespace Analise_de_Algoritmos_T1.Model.Adapter
{
    internal class PersianaNatLightAdapter : IPersiana
    {
        private readonly PersianaNatLight _persiana;

        public PersianaNatLightAdapter(PersianaNatLight persiana)
        {
            _persiana = persiana;
        }

        public void Abrir()
        {
            // Garante que as palhetas estão abertas antes de erguer
            _persiana.AbrirPalheta();
            _persiana.SubirPalheta();
        }

        public void Fechar()
        {
            // Desce as palhetas primeiro (se estiverem erguidas)
            _persiana.DescerPalheta();
            // Depois fecha as palhetas
            _persiana.FecharPalheta();
        }

        public bool EstaAberta()
        {
            // Considera aberta se as palhetas estão erguidas
            return _persiana.EstaPalhetaErguida();
        }
    }
}
