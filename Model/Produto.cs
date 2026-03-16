using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analise_de_Algoritmos_T1.Exception;

namespace Analise_de_Algoritmos_T1.Model
{
    public class Produto
    {
        public string Nome { get; }
        public double Valor { get; }
        public double PesoKg { get; }

        public Produto(string nome, double valor, double pesoKg)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ProdutoConstrutorException("Nome do produto é obrigatório");

            if (valor < 0)
                throw new ProdutoConstrutorException("Valor não pode ser negativo");

            if (pesoKg < 0)
                throw new ProdutoConstrutorException("Peso não pode ser negativo");

            Nome = nome;
            Valor = valor;
            PesoKg = pesoKg;
        }
    }
}
