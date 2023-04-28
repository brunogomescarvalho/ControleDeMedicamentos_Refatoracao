using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace consoleApp.ModuloEndereco
{
    public struct Endereco
    {
         public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }

        public Endereco(string rua, int numero, string bairro, string cep, string complemento)
        {
            this.Rua = rua;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cep = cep;
            this.Complemento = complemento;
        }

        public override string ToString()
        {
            return $"{Rua}, {Numero}, {Bairro}, {Cep}, {Complemento}";
        }
    }
}