using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analise_de_Algoritmos_T1.Model
{
    internal class Produto
    {
        public string Nome { get; }
        public double Valor { get; }
        public double PesoKg { get; }

        public Produto(string nome, double valor, double pesoKg)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto é obrigatório");

            if (valor < 0)
                throw new ArgumentException("Valor não pode ser negativo");

            if (pesoKg < 0)
                throw new ArgumentException("Peso não pode ser negativo");

            Nome = nome;
            Valor = valor;
            PesoKg = pesoKg;
        }
    }
}
