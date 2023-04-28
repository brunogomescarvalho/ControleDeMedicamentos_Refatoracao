using System.Collections;
using consoleApp.ModuloCorpartilhado;


namespace consoleApp.ModuloGerenciamento.Compartilhado
{
    public abstract class TelaBaseGerenciamento
    {
        protected RepositorioBaseGerenciamento repositorioBaseGerenciamento = null!;

        public abstract string nomeEntidade { get; set; }

        protected ArrayList erros = null!;


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

        
        public void MostrarMensagem(string msg, ConsoleColor cor)
        {
            Console.Clear();
            Console.ForegroundColor = cor;
            Console.WriteLine($"{msg}");
            Console.ResetColor();
            Console.ReadKey();

        }
        public void MostrarTexto(string texto)
        {
            Console.Clear();
            Console.WriteLine(texto);
        }

        public bool ListaContemItens(ArrayList registros)
        {
            if (registros.Count == 0)
            {
                MostrarMensagem($"Nenhum {nomeEntidade} cadastrado até o momento...", ConsoleColor.Yellow);
                return false;
            }
            return true;
        }


        public virtual void RenderizarTabela(ArrayList lista, bool esperarTecla)
        {
            foreach (var item in lista)
                Console.WriteLine(item);

            if (esperarTecla)
                Console.ReadKey();
        }

        public void MostrarErros(string msg, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine($"{msg}");
            Console.ResetColor();
        }

    }
}