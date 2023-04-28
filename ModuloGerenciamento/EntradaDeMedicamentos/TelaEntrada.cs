using System.Collections;
using System;
using consoleApp.ModuloFuncionario;
using consoleApp.ModuloMedicamento;
using consoleApp.ModuloPaciente;
using consoleApp.ModuloGerenciamento.Compartilhado;

namespace consoleApp.ModuloGerenciamento.EntradaDeMedicamentos
{
    public class TelaEntrada : TelaBaseGerenciamento
    {
        private RepositorioMedicamento repositorioMedicamento;

        private RepositorioFuncionario repositorioFuncionario;


        public TelaEntrada(RepositorioEntrada repositorioEntrada, RepositorioMedicamento repositorioMedicamento, RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioBaseGerenciamento = repositorioEntrada;
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public override string nomeEntidade { get; set; } = "Entrada de Medicamentos";

        public override void Cadastrar()
        {
            this.erros = new ArrayList();

            info.MostrarTexto("--- Cadastrar Entrada de Medicamentos");

            var medicamentos = repositorioMedicamento.BuscarTodos();
            var funcionarios = repositorioFuncionario.BuscarTodos();

            var listaMed = medicamentos.Count == 0;
            var listaFunc = funcionarios.Count == 0;


            if (listaMed || listaMed)
            {
                Console.WriteLine($"Lista de {(listaMed ? "medicamentos" : "funcionários")} não possui registros");
                Console.ReadKey();
                return;
            }

            try
            {
                int idFuncionario = SolicitarId(funcionarios, "funcionário");
                Funcionario funcionario = repositorioFuncionario.BuscarPorId(idFuncionario);

                Console.WriteLine("\nInforme o id do medicamento");
                int idMedicamento = SolicitarId(medicamentos, "medicamento");

                Medicamento medicamento = repositorioMedicamento.BuscarPorId(idMedicamento);

                info.MostrarTexto("\nInforme a quantidade a ser inserida");
                int quantidade = int.Parse(Console.ReadLine()!);

                EntradaMedicamento entrada = funcionario == null || medicamento == null ? null! :
                new EntradaMedicamento(medicamento!, funcionario!, DateTime.Now, quantidade);

                if (funcionario == null)
                    erros.Add("* Funcionário não encontrado");
                if (medicamento == null)
                    erros.Add("* Medicamento não encontrado");

                repositorioBaseGerenciamento.Adicionar(entrada);

                info.MostrarMensagem("Entrada de medicamentos cadastrada com sucesso", ConsoleColor.Green);
            }
            catch (FormatException)
            {
                info.MostrarMensagem("Digite apenas números ao informar o id.", ConsoleColor.Magenta);
            }
            catch (NullReferenceException)
            {
                foreach (var item in erros)
                {
                    info.MostrarErros($"{item}", ConsoleColor.Magenta);
                }

                Console.ReadKey();
            }

        }

        public override void Visualizar()
        {
            info.MostrarTexto("--- Entradas Cadastradas ---\n");
            var registros = repositorioBaseGerenciamento.BuscarTodos();

            if (!info.ListaContemItens(registros))
                return;

            Console.WriteLine($"{"ID",-5} | {"MEDICAMENTO",-20} | {"QTDE",-5} | {"DATA REGISTRO",-15}");

            foreach (GerenciamentoBase item in registros)
            {
                Console.WriteLine($"{item.id,-5} | {item.medicamento.nome,-20} | {item.quantidade,-5} | {item.dataRegistro,-15}");
            }

            Console.ReadKey();
        }

        public void VisualizarEmFalta()
        {
            info.MostrarTexto("--- Medicamentos em Falta ---\n");

            ArrayList medicamentos = repositorioMedicamento.BuscarTodos();
            ArrayList medicamentosEmFalta = new ArrayList();

            foreach (Medicamento item in medicamentos)
            {
                if (item.quantidade == 0)
                    medicamentosEmFalta.Add(item);
            }
            if (!info.ListaContemItens(medicamentosEmFalta))
            {
                info.MostrarMensagem("Nenhum medicamento em falta até o momento", ConsoleColor.Green);
            }

            info.RenderizarTabela(medicamentosEmFalta, true);
        }

        // public override void Visualizar()
        // {
        //     info.MostrarTexto($"--- {nomeEntidade} ---");
        //     Console.WriteLine("1 --- Todas as Entradas");
        //     Console.WriteLine("2 --- Medicamentos em falta");
        //     Console.WriteLine("9 --- Voltar");
        //     int opcao = int.Parse(Console.ReadLine()!);

        //     if (opcao == 1)
        //         VisualizarEntradas();

        //     else if (opcao == 2)
        //         VisualizarMedicamentosEmFalta();

        //     else return;

        // }
    }
}