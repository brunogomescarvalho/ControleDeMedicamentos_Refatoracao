using System.Collections;
using consoleApp.ModuloCorpartilhado;
using consoleApp.ModuloFornecedor;

namespace consoleApp.ModuloMedicamento
{
    public class TelaMedicamento : TelaBase
    {
        RepositorioFornecedor repositorioFornecedor;
        RepositorioMedicamento repositorioMedicamento;

        public override string nomeEntidade { get; set; } = "Medicamento";

        public TelaMedicamento(RepositorioFornecedor repositorioFornecedor, RepositorioMedicamento repositorioMedicamento)
        {
            this.repositorioBase = repositorioMedicamento;
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
        }

        public override EntidadeBase ObterRegistro()
        {
            Fornecedor fornecedor = BuscarFornecedor();

            if (fornecedor == null)
                return null!;

            info.MostrarTexto("Informe o nome:");
            string nome = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 3)
                erros.Add("* Nome do medicamento inválido.");

            info.MostrarTexto("Informe a descrição:");
            string descricao = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(descricao) || descricao.Length < 3)
                erros.Add("* Descrição do medicamento inválida.");

            DateTime dataFabricacao = default;
            DateTime dataVenc = default;
            int qtd = default;
            try
            {
                info.MostrarTexto("Informe a data de fabricação: (dd/MM/yyyy)");
                dataFabricacao = Convert.ToDateTime(Console.ReadLine()!);

                info.MostrarTexto("Informe a data de vencimento: (dd/MM/yyyy)");
                dataVenc = Convert.ToDateTime(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                erros.Add("* Data informada em um formato inválido.");
            }

            info.MostrarTexto("Informe o Lote:");
            string lote = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(lote) || lote.Length < 3)
                erros.Add("* Lote do medicamento inválido.");

            try
            {
                info.MostrarTexto("Informe a quantidade:");
                qtd = int.Parse(Console.ReadLine()!);

                if (qtd < 0)
                    erros.Add("* A quantidade não pode ser menor que zero.");
            }
            catch (FormatException)
            {
                erros.Add("* Quantidade informada em um formato inválido.");
            }

            bool itemJaCadastrado = repositorioMedicamento.ItemCadastrado(nome, fornecedor.id);

            return itemJaCadastrado || erros.Count > 0 ? null! : new Medicamento(nome, fornecedor, descricao, dataFabricacao, dataVenc, lote, qtd);

        }


        private Fornecedor BuscarFornecedor()
        {
            ArrayList fornecedores = repositorioFornecedor.BuscarTodos();
            Fornecedor fornecedor = null!;

            if (!info.ListaContemItens(fornecedores))
                return null!;

            info.RenderizarTabela(fornecedores, false);

            Console.WriteLine("\nInforme o id do fornecedor:");
            string id = Console.ReadLine()!;

            fornecedor = repositorioFornecedor.BuscarPorId(int.Parse(id));

            if (fornecedor == null)
            {
                erros.Add("Fornecedor não encontrado.");
            }

            return fornecedor!;
        }

        public override void MostrarTabela(ArrayList registros, bool esperarTecla)
        {

            if (!info.ListaContemItens(registros))
                return;

            registros.Sort(repositorioMedicamento);

            Console.WriteLine($"{"ID",-5} | {"NOME",-20} | {"QTD",-5} | {"FORNECEDOR",-15} | {"FABRICAÇÃO",-12:d} | {"VALIDADE",-12:d} | {"LOTE",-6}");
            Console.WriteLine("------|----------------------|-------|-----------------|--------------|--------------|------------");

            foreach (Medicamento item in registros)
            {
                Console.ForegroundColor = item.quantidade == 0 ? ConsoleColor.Magenta : item.quantidade < 20 ? ConsoleColor.DarkYellow : ConsoleColor.White;
                Console.WriteLine(item);
                Console.ResetColor();
            }
            Console.ReadKey();

        }

    }
}