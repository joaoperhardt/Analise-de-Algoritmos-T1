using Analise_de_Algoritmos_T1.Interface;
using Analise_de_Algoritmos_T1.Model;

namespace Analise_de_Algoritmos_T1.EntregaCreator
{
    internal abstract class EntregaCreator
    {
        public abstract ITipoEntrega FactoryMethod();

        public string CalcularFreteParaPedido(Pedido pedido)
        {
            var tipoEntrega = FactoryMethod();
            pedido.AlterarTipoEntrega(tipoEntrega);
            return pedido.ObterResumoEntrega();
        }
    }

    internal class PacCreator : EntregaCreator
    {
        public override ITipoEntrega FactoryMethod()
        {
            return new TipoEntregaPac();
        }
    }

    internal class SedexCreator : EntregaCreator
    {
        public override ITipoEntrega FactoryMethod()
        {
            return new TipoEntregaSedex();
        }
    }

    internal class RetiradaLocalCreator : EntregaCreator
    {
        public override ITipoEntrega FactoryMethod()
        {
            return new TipoEntregaRetiradaLocal();
        }
    }
}
