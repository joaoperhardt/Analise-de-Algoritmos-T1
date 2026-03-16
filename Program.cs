using Analise_de_Algoritmos_T1.Model;

namespace Analise_de_Algoritmos_T1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Cliente().Executar();
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
