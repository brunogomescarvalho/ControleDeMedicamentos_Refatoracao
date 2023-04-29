using consoleApp.ModuloEndereco;
using consoleApp.ModuloFuncionario;
using System.Collections;

namespace consoleApp.ModuloCorpartilhado
{
    public class TelaFuncionario : TelaBase
    {
        public override string nomeEntidade { get; set; } = "Funcionário";
        private CadastroEndereco cadastroEndereco;
        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioBase = repositorioFuncionario;
            this.cadastroEndereco = new CadastroEndereco();
        }

        public override void MostrarTabela(ArrayList registros, bool esperarTecla)
        {
            Console.WriteLine($"{"ID",-5} | {"NOME",-20} | {"CPF",-15}");
            Console.WriteLine("------|----------------------|--------------");

            RenderizarTabela(registros, esperarTecla);
        }

        public override Funcionario ObterRegistro()
        {
            MostrarTexto("Informe o nome do funcionário:");
            string nome = Console.ReadLine()!;

            if (String.IsNullOrWhiteSpace(nome) || nome.Length < 3)
                erros.Add("* Campo Nome inválido.");

            MostrarTexto("Informe o CPF:");
            string cpf = Console.ReadLine()!;

            if (String.IsNullOrWhiteSpace(cpf) || cpf.Length < 10)
                erros.Add("* Campo CPF inválido.");

            MostrarTexto("Telefone:");
            string telefone = Console.ReadLine()!;

            if (String.IsNullOrWhiteSpace(telefone) || telefone.Length < 8)
                erros.Add("* Campo Telefone inválido.");

            Endereco? endereco = cadastroEndereco.CadastrarEndereco();
            if (endereco == null)
                erros.Add("* Endereço inválido.");

            if (erros.Count > 0)
                return null!;

            return new Funcionario(nome, cpf, telefone, endereco);
        }

    }

}
