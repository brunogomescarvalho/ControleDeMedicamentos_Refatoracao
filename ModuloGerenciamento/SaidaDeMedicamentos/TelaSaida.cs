using consoleApp.ModuloFuncionario;
using consoleApp.ModuloGerenciamento.Compartilhado;
using consoleApp.ModuloMedicamento;
using consoleApp.ModuloPaciente;
using System.Collections;

namespace consoleApp.ModuloGerenciamento.SaidaDeMedicamentos
{
    public class TelaSaida : TelaBaseGerenciamento
    {
        private RepositorioMedicamento repositorioMedicamento;
        private RepositorioFuncionario repositorioFuncionario;
        private RepositorioPaciente repositorioPaciente;
        private RepositorioSaida repositorioSaida;


        public TelaSaida(RepositorioSaida repositorioSaida, RepositorioMedicamento repositorioMedicamento, RepositorioFuncionario repositorioFuncionario, RepositorioPaciente repositorioPaciente)
        {
            this.repositorioSaida = repositorioSaida;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioBaseGerenciamento = repositorioSaida;
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public override string nomeEntidade { get; set; } = "Saída de Medicamentos";

        public override void Cadastrar()
        {
            MostrarTexto("--- Cadastrar Saída de Medicamentos");

            ArrayList medicamentos = repositorioMedicamento.BuscarTodos();
            ArrayList funcionarios = repositorioFuncionario.BuscarTodos();
            ArrayList pacientes = repositorioPaciente.BuscarTodos();

            bool listaMed = medicamentos.Count == 0;
            bool listaFunc = funcionarios.Count == 0;
            bool listaPac = pacientes.Count == 0;

            SaidaMedicamento saida = null!;

            if (listaMed || listaFunc || listaPac)
            {
                MostrarMensagem($"Lista de{(listaPac ? "pacientes" : listaMed ? "medicamentos" : "funcionários")} não possui registros", ConsoleColor.DarkYellow);
                return;
            }

            try
            {
                int idFuncionario = SolicitarId(funcionarios, "funcionário");

                Funcionario funcionario = repositorioFuncionario.BuscarPorId(idFuncionario);

                int idPaciente = SolicitarId(pacientes, "paciente");

                Paciente paciente = repositorioPaciente.BuscarPorId(idPaciente);

                int idMedicamento = SolicitarId(medicamentos, "medicamento");

                Medicamento medicamento = repositorioMedicamento.BuscarPorId(idMedicamento);

                MostrarTexto("\nInforme a quantidade informada na requisição do paciente");
                int quantidade = int.Parse(Console.ReadLine()!);

                saida = medicamento == null! || funcionario == null! || paciente == null ? null! :

                new SaidaMedicamento(paciente, medicamento, funcionario, DateTime.Now, quantidade);

                if (!saida.DescontarMedicamento())
                {
                    MostrarMensagem("\nA quantidade solicitada é superior a disponível em estoque.", ConsoleColor.Magenta); return;
                }

                repositorioBaseGerenciamento.Adicionar(saida);

                MostrarMensagem("Requisição de Saída de Medicamentos cadastrada com sucesso.", ConsoleColor.Green);

            }
            catch (FormatException)
            {
                MostrarMensagem("Digite apenas números ao informar o id.", ConsoleColor.Magenta);
            }
            catch (NullReferenceException)
            {
                MostrarMensagem("Id solicitado não encontrado.", ConsoleColor.DarkMagenta);
            }

        }

        public override void Visualizar()
        {
            MostrarTexto("--- Saídas Cadastradas ---\n");
            var registros = repositorioBaseGerenciamento.BuscarTodos();

            if (registros.Count == 0)
            {
                Console.WriteLine($"Lista de {nomeEntidade} não possui registros");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"{"ID",-5} | {"MEDICAMENTO",-15} | {"QTDE",-5} | {"DATA REGISTRO",-15} | {"PACIENTE\tNome",-23}  {"Idade",-6} {"Cartão SUS"}");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            foreach (SaidaMedicamento item in registros)
            {
                Console.WriteLine($"{item.id,-5} | {item.medicamento.nome,-15} | {item.quantidade,-5} | {item.dataRegistro,-15:d} | Id: {item.paciente.id,-3} {item.paciente.nomeCompleto,-20} {item.paciente.idade,-6} {item.paciente.cartaoDeSaude}");
            }

            Console.ReadKey();
        }

        public void VisualizarMaisSolicitados()
        {
            MostrarTexto("--- Medicamentos Mais Solicitados ---\n");

            ArrayList saidas = repositorioBaseGerenciamento.BuscarTodos();

            IDictionary<string, int> listaFiltrada = new Dictionary<string, int>();

            foreach (SaidaMedicamento item in saidas)
            {
                if (listaFiltrada.ContainsKey(item.medicamento.nome))
                    listaFiltrada[item.medicamento.nome] += item.quantidade;

                else
                    listaFiltrada.Add(item.medicamento.nome, item.quantidade);
            }

            IOrderedEnumerable<KeyValuePair<string, int>> ordenada = listaFiltrada.OrderByDescending(i => i.Value);

            Console.WriteLine($"{"NOME",-15} {"QTD SOLICITADA"}");

            foreach (var item in ordenada)
            {
                System.Console.WriteLine($"{item.Key,-20} {item.Value}");
            }
            Console.ReadKey();
        }



        // public override void Visualizar()
        // {
        //   MostrarTexto($"--- {nomeEntidade} ---");
        //     Console.WriteLine("1 --- Todas as Saídas");
        //     Console.WriteLine("2 --- Medicamentos mais solicitados");
        //     Console.WriteLine("9 --- Voltar");
        //     int opcao = int.Parse(Console.ReadLine()!);

        //     if (opcao == 1)
        //         VisualizarSaidas();

        //     else if (opcao == 2)
        //         VisualizarMedicamentosMaisSolicitados();

        //     else return;

        // }

    }
}