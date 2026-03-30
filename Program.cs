using Analise_de_Algoritmos_T1.Model;
using Analise_de_Algoritmos_T1.Model.Adapter;
using AlgoritmosDotNet;

namespace Analise_de_Algoritmos_T1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Automação Residencial IoT ===\n");

            var sistema = new SistemaAutomacao();

            Console.WriteLine("Configurando dispositivos...\n");

            LampadaShoyouMiAdapter lampadaShoyou = new LampadaShoyouMiAdapter(new LampadaShoyuMi());
            LampadaPhelippesAdapter lampadaPhelippes = new LampadaPhelippesAdapter(new LampadaPhellipes());

            sistema.AdicionarLampada(lampadaShoyou);
            sistema.AdicionarLampada(lampadaPhelippes);

            PersianaSolariusAdapter persianaSolarius = new PersianaSolariusAdapter(new PersianaSolarius());
            PersianaNatLightAdapter persianaNatLight = new PersianaNatLightAdapter(new PersianaNatLight());

            sistema.AdicionarPersiana(persianaSolarius);
            sistema.AdicionarPersiana(persianaNatLight);

            ArCondicionadoVentoBaumnAdapter arVentoBaumn = new ArCondicionadoVentoBaumnAdapter(new ArCondicionadoVentoBaumn());
            ArCondicionadoGellaKazaAdapter arGellaKaza = new ArCondicionadoGellaKazaAdapter(new ArCondicionadoGellaKaza());

            sistema.AdicionarArCondicionado(arVentoBaumn);
            sistema.AdicionarArCondicionado(arGellaKaza);

            Console.WriteLine($"✓ {sistema.ObterQuantidadeLampadas()} lâmpadas configuradas");
            Console.WriteLine($"✓ {sistema.ObterQuantidadePersianas()} persianas configuradas");
            Console.WriteLine($"✓ {sistema.ObterQuantidadeArCondicionados()} ar-condicionados configurados\n");

            Console.WriteLine("--- Teste: Controle Individual ---");

            sistema.LigarTodasLampadas();
            Console.WriteLine("✓ Todas as lâmpadas ligadas");

            sistema.AbrirTodasPersianas();
            Console.WriteLine("✓ Todas as persianas abertas");

            sistema.LigarTodosArCondicionados();
            sistema.DefinirTemperaturaGeral(22);
            Console.WriteLine("✓ Todos os ar-condicionados ligados (22°C)\n");

            ExibirEstado(sistema);

            Console.WriteLine("\n--- Ativando Modo Trabalho ---");
            sistema.AtivarModoTrabalho();
            Console.WriteLine("✓ Modo Trabalho ativado");
            Console.WriteLine("  • Lâmpadas: LIGADAS");
            Console.WriteLine("  • Persianas: ABERTAS");
            Console.WriteLine("  • Ar-condicionado: LIGADO (25°C)\n");

            ExibirEstado(sistema);

            Console.WriteLine("\n--- Ativando Modo Sono ---");
            sistema.AtivarModoSono();
            Console.WriteLine("✓ Modo Sono ativado");
            Console.WriteLine("  • Lâmpadas: DESLIGADAS");
            Console.WriteLine("  • Persianas: FECHADAS");
            Console.WriteLine("  • Ar-condicionado: DESLIGADO\n");

            ExibirEstado(sistema);

            Console.WriteLine("\n=== Sistema funcionando corretamente! ===");
            Console.WriteLine("\nOBS: Quando a biblioteca LibDispositivosIot for adicionada,");
            Console.WriteLine("remova o arquivo ExternalDevices.cs e importe a biblioteca real.");

        }

        private static void ExibirEstado(SistemaAutomacao sistema)
        {
            Console.WriteLine("Estado atual:");
            Console.WriteLine($"  • Lâmpadas ligadas: {sistema.ObterLampadasLigadas()}/{sistema.ObterQuantidadeLampadas()}");
            Console.WriteLine($"  • Persianas abertas: {sistema.ObterPerسianasAbertas()}/{sistema.ObterQuantidadePersianas()}");
            Console.WriteLine($"  • Ar-condicionados ligados: {sistema.ObterArCondicionadosLigados()}/{sistema.ObterQuantidadeArCondicionados()}");
        }
    }
}
