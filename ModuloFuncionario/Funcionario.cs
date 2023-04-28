using System;
using consoleApp.ModuloCorpartilhado;
using consoleApp.ModuloEndereco;

namespace consoleApp.ModuloFuncionario
{
    public class Funcionario : EntidadeBase
    {
        public string telefone { get; set; }
        public Endereco? endereco { get; set; }
        public string cpf { get; set; }


        public Funcionario(string nome, string cpf, string telefone, Endereco? endereco) : base(nome)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.endereco = endereco;
            this.cpf = cpf;
        }

        public override void Editar(EntidadeBase entidade)
        {
            Funcionario funcionario = (Funcionario)entidade;

            this.nome = funcionario.nome;
            this.telefone = funcionario.telefone;
            this.endereco = funcionario.endereco;
            this.cpf = funcionario.cpf;
        }

        public override string ToString()
        {
            return $"{id,-5} | {nome,-20} | {cpf,-5}";
        }

    }
}