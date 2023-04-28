using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace consoleApp.ModuloEndereco
{
    public class CadastroEndereco
    {
        public Endereco? CadastrarEndereco()
        {
            MostrarTexto("--- Cadastro Endereço ---\nInforme a rua:");
            string rua = Console.ReadLine()!;

            MostrarTexto("Informe o número:");
            string nr = Console.ReadLine()!;
            int numero = int.TryParse(nr, out numero) ? int.Parse(nr) : default;

            MostrarTexto("Informe o bairro:");
            string bairro = Console.ReadLine()!;

            MostrarTexto("Informe o cep:");
            string cep = Console.ReadLine()!;

            MostrarTexto("Informe o complemento:");
            string complemento = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(rua) ||
            string.IsNullOrWhiteSpace(bairro) ||
            string.IsNullOrWhiteSpace(cep) ||
            string.IsNullOrWhiteSpace(complemento))

                return null;

            return new Endereco(rua, numero, bairro, cep, complemento);

        }

        protected void MostrarTexto(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
        }

        public string MostrarCabecalho()
        {
            return "ENDEREÇO";
        }
    }
}