using consoleApp.ModuloCorpartilhado;
using consoleApp.ModuloEndereco;
using consoleApp.ModuloFornecedor;
using consoleApp.ModuloFuncionario;
using consoleApp.ModuloGerenciamento;
using consoleApp.ModuloGerenciamento.EntradaDeMedicamentos;
using consoleApp.ModuloGerenciamento.SaidaDeMedicamentos;
using consoleApp.ModuloMedicamento;
using consoleApp.ModuloPaciente;

RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
RepositorioEntrada repositorioEntrada = new RepositorioEntrada();
RepositorioSaida repositorioSaida = new RepositorioSaida();

AdicionarAlgunsDadosNoSistema(repositorioMedicamento, repositorioPaciente, repositorioFuncionario, repositorioSaida, repositorioFornecedor);

TelaBase tela = null!;
MenuGerenciamento menuGerenciamento = null!;
bool continuar = true;


while (continuar)
{
    try
    {
        Console.Clear();
        Console.WriteLine("  ---- Menu ----");
        Console.WriteLine("1 ---- Funcionarios");
        Console.WriteLine("2 ---- Pacientes");
        Console.WriteLine("3 ---- Medicamentos");
        Console.WriteLine("4 ---- Fornecedor");
        Console.WriteLine("5 ---- Gerenciamento Estoque");
        Console.WriteLine("9 ---- Sair");
        int opcaoMenu = int.Parse(Console.ReadLine()!);

        switch (opcaoMenu)
        {
            case 1: tela = new TelaFuncionario(repositorioFuncionario); break;

            case 2: tela = new TelaPaciente(repositorioPaciente); break;

            case 3: tela = new TelaMedicamento(repositorioFornecedor, repositorioMedicamento); break;

            case 4: tela = new TelaFornecedor(repositorioFornecedor); break;

            case 5: menuGerenciamento = new MenuGerenciamento(repositorioFuncionario, repositorioFornecedor, repositorioMedicamento, repositorioPaciente, repositorioEntrada, repositorioSaida); break;

            case 9: continuar = false; continue;

            default: continue;

        }
        if (opcaoMenu == 5)
            menuGerenciamento.MostrarMenu();

        else if (opcaoMenu == 1 || opcaoMenu == 2 || opcaoMenu == 3 || opcaoMenu == 4)
        {
            int opcaoSubMenu = 0;

            while (opcaoSubMenu != 9)
            {
                opcaoSubMenu = tela.MostrarMenu();

                switch (opcaoSubMenu)
                {
                    case 1: tela.Cadastrar(); break;

                    case 2: tela.Visualizar(); break;

                    case 3: tela.Editar(); break;

                    case 4: tela.Excluir(); break;

                }
            }
        }

    }
    catch (FormatException)
    {
        Console.WriteLine("Para escolher a opção utilize apenas números.");
        Console.ReadLine();
    }
}



static void AdicionarAlgunsDadosNoSistema
(
  RepositorioMedicamento repositorioMedicamento,
  RepositorioPaciente repositorioPaciente,
  RepositorioFuncionario repositorioFuncionario,
  RepositorioSaida repositorioSaida,
  RepositorioFornecedor repositorioFornecedor)
{
    var medicamentos = repositorioMedicamento.BuscarTodos();
    var pacientes = repositorioPaciente.BuscarTodos();
    var funcionarios = repositorioFuncionario.BuscarTodos();
    var fornecedores = repositorioFornecedor.BuscarTodos();

    repositorioFornecedor.Adicionar(new Fornecedor("Eurofarma", "12345678901", " 11 1234-5678", new Endereco("Av. Vereador J. Diniz", 3146, "Industrial", "88201-111", "São Paulo")));
    repositorioFornecedor.Adicionar(new Fornecedor("EMS", "12345678002", "19 3838-8800", new Endereco("Rod. Jorn F.A Proença", 8, "Chácara Boa Vista", "13186-901", "Hortolândia")));
    repositorioFornecedor.Adicionar(new Fornecedor("Aché", "12345678903", "11 3777-8000", new Endereco("Av. Brigadeiro Faria Lima", 201, "Jardim Paulistano", "01452-000", "São Paulo")));
    repositorioFornecedor.Adicionar(new Fornecedor("Novartis", "12345678904", "11 5532-7122", new Endereco("Rua Francisco L. Vieira", 273, "Parque Ind Anhangüera", "05119-000", "São Paulo")));
    repositorioFornecedor.Adicionar(new Fornecedor("Sanofi", "12345678905", "11 5532-5151", new Endereco("Av. Mutinga", 1805, "Pirituba", "05110-000", "São Paulo")));
    repositorioFornecedor.Adicionar(new Fornecedor("Pfizer", "12345678906", "11 5629-8000", new Endereco("Av. Pres J. Kubitschek", 1838, "Vila Nova Conceição", "04543-000", "São Paulo")));

    repositorioPaciente.Adicionar(new Paciente("Joaci", "Gentil", DateTime.Now.AddYears(-34), "123456", "49 32252340", new Endereco("Paraguai", 146, "Frei Rogério", "88509888", "Casa")));
    repositorioPaciente.Adicionar(new Paciente("Rosemeri", "Gomes", DateTime.Now.AddYears(-63), "987654", "49 32226869", new Endereco("Orli Freitas", 222, "Centro", "88509000", "Ap 202")));
    repositorioPaciente.Adicionar(new Paciente("Nair", "Dos Santos", DateTime.Now.AddYears(-88), "2589", "49 32232274", new Endereco("Pernambuco", 273, "São Cristóvão", "88509120", "Casa Amarela")));

    repositorioFuncionario.Adicionar(new Funcionario("João Silva", "111.222.333-44", "1111-2222", new Endereco("Rua B", 123, "Bairro 3", "3222-5678", "Ap 202")));
    repositorioFuncionario.Adicionar(new Funcionario("Maria Souza", "222.333.444-55", "2222-3333", new Endereco("Rua A", 123, "Bairro 5", "3224-1678", "Casa Madeira")));
    repositorioFuncionario.Adicionar(new Funcionario("Pedro Santos", "333.444.555-66", "3333-4444", new Endereco("Rua D", 123, "Bairro 2", "32266-7898", "CASA")));
    repositorioFuncionario.Adicionar(new Funcionario("Ana Costa", "444.555.666-77", "4444-5555", new Endereco("Rua F", 123, "Bairro 1", "3225-2340", "AP 05")));

    repositorioMedicamento.Adicionar(new Medicamento("Paracetamol", (Fornecedor)fornecedores[0]!, "Analgésico e antitérmico", new DateTime(2023, 4, 1), new DateTime(2025, 3, 31), "123456", 110));
    repositorioMedicamento.Adicionar(new Medicamento("Dipirona", (Fornecedor)fornecedores[0]!, "Analgésico e antitérmico", new DateTime(2023, 4, 2), new DateTime(2025, 4, 1), "123457", 8));
    repositorioMedicamento.Adicionar(new Medicamento("Ibuprofeno", (Fornecedor)fornecedores[1]!, "Analgésico e anti-inflamatório", new DateTime(2023, 4, 3), new DateTime(2025, 5, 2), "123458", 15));
    repositorioMedicamento.Adicionar(new Medicamento("Diclofenaco", (Fornecedor)fornecedores[1]!, "Analgésico e anti-inflamatório", new DateTime(2023, 4, 4), new DateTime(2025, 6, 1), "123459", 25));
    repositorioMedicamento.Adicionar(new Medicamento("Atenolol", (Fornecedor)fornecedores[2]!, "Anti-hipertensivo", new DateTime(2023, 4, 5), new DateTime(2025, 7, 1), "123460", 23));
    repositorioMedicamento.Adicionar(new Medicamento("Losartana", (Fornecedor)fornecedores[2]!, "Anti-hipertensivo", new DateTime(2023, 4, 6), new DateTime(2025, 8, 1), "123461", 11));
    repositorioMedicamento.Adicionar(new Medicamento("Levotiroxina", (Fornecedor)fornecedores[4]!, "Hormônio da tireoide", new DateTime(2023, 4, 9), new DateTime(2025, 11, 1), "123464", 0));
    repositorioMedicamento.Adicionar(new Medicamento("Metformina", (Fornecedor)fornecedores[4]!, "Antidiabético oral", new DateTime(2023, 4, 10), new DateTime(2025, 12, 1), "123465", 0));
    repositorioMedicamento.Adicionar(new Medicamento("Captopril", (Fornecedor)fornecedores[0]!, "Inibidor da enzima conversora de angiotensina", new DateTime(2023, 4, 11), new DateTime(2025, 1, 1), "123466", 100));
    repositorioMedicamento.Adicionar(new Medicamento("AAS", (Fornecedor)fornecedores[0]!, "Anti-inflamatório e antiplaquetário", new DateTime(2023, 4, 12), new DateTime(2025, 2, 1), "123467", 150));
    repositorioMedicamento.Adicionar(new Medicamento("Prednisona", (Fornecedor)fornecedores[1]!, "Corticosteroide", new DateTime(2023, 4, 13), new DateTime(2025, 3, 1), "123468", 200));
    repositorioMedicamento.Adicionar(new Medicamento("Dexametasona", (Fornecedor)fornecedores[1]!, "Corticosteroide", new DateTime(2023, 4, 14), new DateTime(2025, 4, 1), "123469", 250));
    repositorioMedicamento.Adicionar(new Medicamento("Furosemida", (Fornecedor)fornecedores[2]!, "Diurético de alça", new DateTime(2023, 4, 15), new DateTime(2025, 5, 1), "123470", 300));
    repositorioMedicamento.Adicionar(new Medicamento("Hidroclorotiazida", (Fornecedor)fornecedores[2]!, "Diurético tiazídico", new DateTime(2023, 4, 16), new DateTime(2025, 6, 1), "123471", 350));
    repositorioMedicamento.Adicionar(new Medicamento("Sinvastatina", (Fornecedor)fornecedores[3]!, "Inibidor da HMG-CoA redutase", new DateTime(2023, 4, 17), new DateTime(2025, 7, 1), "123472", 400));

    repositorioSaida.Adicionar(new SaidaMedicamento((Paciente)pacientes[0]!, (Medicamento)medicamentos[10]!, (Funcionario)funcionarios[0]!, DateTime.Now, 6));
    repositorioSaida.Adicionar(new SaidaMedicamento((Paciente)pacientes[0]!, (Medicamento)medicamentos[11]!, (Funcionario)funcionarios[0]!, DateTime.Now, 7));
    repositorioSaida.Adicionar(new SaidaMedicamento((Paciente)pacientes[1]!, (Medicamento)medicamentos[0]!, (Funcionario)funcionarios[0]!, DateTime.Now, 8));
    repositorioSaida.Adicionar(new SaidaMedicamento((Paciente)pacientes[1]!, (Medicamento)medicamentos[3]!, (Funcionario)funcionarios[0]!, DateTime.Now, 2));
    repositorioSaida.Adicionar(new SaidaMedicamento((Paciente)pacientes[2]!, (Medicamento)medicamentos[4]!, (Funcionario)funcionarios[0]!, DateTime.Now, 3));
    repositorioSaida.Adicionar(new SaidaMedicamento((Paciente)pacientes[2]!, (Medicamento)medicamentos[5]!, (Funcionario)funcionarios[0]!, DateTime.Now, 2));
    repositorioSaida.Adicionar(new SaidaMedicamento((Paciente)pacientes[2]!, (Medicamento)medicamentos[6]!, (Funcionario)funcionarios[0]!, DateTime.Now, 1));
    repositorioSaida.Adicionar(new SaidaMedicamento((Paciente)pacientes[1]!, (Medicamento)medicamentos[3]!, (Funcionario)funcionarios[0]!, DateTime.Now, 5));
}


