using System.Collections;
using consoleApp.ModuloCorpartilhado;


namespace consoleApp.ModuloGerenciamento.Compartilhado
{
    public abstract class TelaBaseGerenciamento : IMostraInfos
    {
        protected RepositorioBaseGerenciamento repositorioBaseGerenciamento = null!;

        public abstract string nomeEntidade { get; set; }

        protected IMostraInfos info = null!;

        protected ArrayList erros = null!;

        public TelaBaseGerenciamento()
        {
            this.info = this;
        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($" --- {nomeEntidade} ---");
                Console.WriteLine("1 --- Cadastrar");
                Console.WriteLine("2 --- Visualizar");
                Console.WriteLine("9 --- Voltar");
                int opcao = int.Parse(Console.ReadLine()!);

                switch (opcao)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        Visualizar();
                        break;
                    case 9:
                        return;
                    default:
                        MostrarMenu();
                        break;
                }
            }
        }

        public abstract void Cadastrar();
        public abstract void Visualizar();

        protected static int SolicitarId(ArrayList medicamentos, string entidade)
        {
            Console.Clear();
            foreach (var item in medicamentos)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nInforme o id do {entidade}");
            int id = int.Parse(Console.ReadLine()!);

            return id;
        }

    }
}