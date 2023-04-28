using consoleApp.ModuloFornecedor;
using consoleApp.ModuloFuncionario;
using consoleApp.ModuloGerenciamento.EntradaDeMedicamentos;
using consoleApp.ModuloGerenciamento.SaidaDeMedicamentos;
using consoleApp.ModuloMedicamento;
using consoleApp.ModuloPaciente;

namespace consoleApp.ModuloGerenciamento
{
    public class MenuGerenciamento
    {
        RepositorioMedicamento repositorioMedicamento;
        RepositorioFuncionario repositorioFuncionario;
        RepositorioFornecedor repositorioFornecedor;
        RepositorioPaciente repositorioPaciente;
        RepositorioEntrada repositorioEntrada;
        RepositorioSaida repositorioSaida;
        TelaEntrada telaEntrada;
        TelaSaida telaSaida;

        public MenuGerenciamento(RepositorioFuncionario repositorioFuncionario, RepositorioFornecedor repositorioFornecedor, RepositorioMedicamento repositorioMedicamento, RepositorioPaciente repositorioPaciente, RepositorioEntrada repositorioEntrada, RepositorioSaida repositorioSaida)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioFornecedor = repositorioFornecedor;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioEntrada = repositorioEntrada;
            this.repositorioSaida = repositorioSaida;
            this.telaEntrada = new TelaEntrada(repositorioEntrada, repositorioMedicamento, repositorioFuncionario);
            this.telaSaida = new TelaSaida(repositorioSaida, repositorioMedicamento, repositorioFuncionario, repositorioPaciente);

        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("  --- Gerenciamento --- ");
                Console.WriteLine("1 --- Entrada de Medicamentos");
                Console.WriteLine("2 --- Saída de Medicamentos");
                Console.WriteLine("3 --- Visualizar medicamentos em falta");
                Console.WriteLine("4 --- Visualizar medicamentos mais solicitados");
                Console.WriteLine("9 --- Voltar");
                int opcao = int.Parse(Console.ReadLine()!);

                switch (opcao)
                {
                    case 1: telaEntrada.MostrarMenu(); break;
                    case 2: telaSaida.MostrarMenu(); break;
                    case 3: telaEntrada.VisualizarEmFalta(); break;
                    case 4: telaSaida.VisualizarMaisSolicitados(); break;
                    case 9: break;
                    default: MostrarMenu(); break;
                }

                if (opcao == 9)
                    break;

            }
        }
    }
}