using consoleApp.ModuloCorpartilhado;
using consoleApp.ModuloEndereco;
using System.Collections;

namespace consoleApp.ModuloFornecedor
{
    public class TelaFornecedor : TelaBase
    {
        private CadastroEndereco cadastroEndereco;
        public TelaFornecedor(RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioBase = repositorioFornecedor;
            this.cadastroEndereco = new CadastroEndereco();
        }

        public override string nomeEntidade { get; set; } = "Fornecedor";
        public override void MostrarTabela(ArrayList registros, bool esperarTecla)
        {
            Console.WriteLine($"{"ID",-3} | {"NOME",-15} | {"CNPJ",-15} | {"TELEFONE",-15} | {cadastroEndereco.MostrarCabecalho()}");
            Console.WriteLine("----|-----------------|-----------------|-----------------|---------------------------|-------|---------------------------|------------|---------------");

            RenderizarTabela(registros, esperarTecla);
        }

        public override EntidadeBase ObterRegistro()
        {

            MostrarTexto("Informe o nome do fornecedor:");
            string nome = Console.ReadLine()!;

            if (String.IsNullOrWhiteSpace(nome) || nome.Length < 3)
                erros.Add("* Campo Nome inválido.");

            MostrarTexto("Informe o CNPJ:");
            string cnpj = Console.ReadLine()!;

            if (String.IsNullOrWhiteSpace(cnpj) || cnpj.Length < 8)
                erros.Add("* Campo CNPJ inválido.");

            MostrarTexto("Telefone:");
            string telefone = Console.ReadLine()!;

            if (String.IsNullOrWhiteSpace(telefone) || telefone.Length < 8)
                erros.Add("* Campo Telefone inválido.");

            Endereco? endereco = cadastroEndereco.CadastrarEndereco();
            if (endereco == null)
                erros.Add("* Endereço inválido.");

            if (erros.Count > 0)
                return null!;

            return new Fornecedor(nome, cnpj, telefone, endereco);
        }
    }
}