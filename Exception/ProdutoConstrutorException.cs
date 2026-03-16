using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analise_de_Algoritmos_T1.Exception
{
    public class ProdutoConstrutorException : System.Exception
    {

        public ProdutoConstrutorException(string message) :base(message) { } 
    }
}
