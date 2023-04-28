using System.Collections;


namespace consoleApp.ModuloCorpartilhado
{
    public abstract class TelaBase
    {
        public RepositorioBase repositorioBase = null!;
        public abstract string nomeEntidade { get; set; }
        public abstract EntidadeBase ObterRegistro();
        public abstract void MostrarTabela(ArrayList registros, bool esperarTecla);
       
        public ArrayList erros = null!;

      
        public int MostrarMenu()
        {
            MostrarTexto($"--- {nomeEntidade} ---");
            Console.WriteLine("1 --- Cadastrar");
            Console.WriteLine("2 --- Visualizar");
            Console.WriteLine("3 --- Editar");
            Console.WriteLine("4 --- Excluir");
            Console.WriteLine("9 --- Voltar");

            return int.Parse(Console.ReadLine()!);

        }

        public virtual void Cadastrar()
        {
            MostrarTexto("---Cadastrar---");

            this.erros = new ArrayList();

            try
            {
                EntidadeBase entidade = ObterRegistro();

                repositorioBase.Adicionar(entidade);

                MostrarMensagem($"{nomeEntidade} cadastrado com sucesso", ConsoleColor.Green);
            }
            catch (NullReferenceException)
            {
                foreach (var item in erros)
                {
                    MostrarErros($"{item}", ConsoleColor.Magenta);
                }

                Console.ReadKey();
            }
        }

        public virtual void Visualizar()
        {
            MostrarTexto($"--- Listar Registros {nomeEntidade} ---\n");

            ArrayList registros = repositorioBase.BuscarTodos();

            if (!ListaContemItens(registros))
                return;

            MostrarTabela(registros, true);
        }

        public virtual void Editar()
        {
            this.erros = new ArrayList();

            MostrarTexto($"--- Editar Registro {nomeEntidade} ---");

            ArrayList registros = repositorioBase.BuscarTodos();

            if (!ListaContemItens(registros))
                return;

            MostrarTabela(registros, false);

            int id = 0;
            try
            {
                Console.WriteLine($"Informe o id do {nomeEntidade} para editar");
                id = int.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                erros.Add("Id informado em um formato inválido");
            }

            try
            {
                EntidadeBase entidade = ObterRegistro();

                repositorioBase.Editar(entidade, id);

                MostrarStatus("editado");
            }
            catch (NullReferenceException)
            {
                foreach (var item in erros)
                {
                    MostrarErros($"{item}", ConsoleColor.Magenta);
                }

                Console.ReadKey();
            }

        }

        public void Excluir()
        {
            MostrarTexto($"--- Excluir Registro {nomeEntidade} ---");

            ArrayList registros = repositorioBase.BuscarTodos();

            if (!ListaContemItens(registros))
                return;

            MostrarTabela(registros, false);
            int id = 0;

            try
            {
                Console.WriteLine("Informe o id para excluir");
                id = int.Parse(Console.ReadLine()!);

                repositorioBase.Excluir(id);

                MostrarStatus("excluído");
            }
            catch (FormatException)
            {
                MostrarMensagem("Id informado em um formato inválido", ConsoleColor.Magenta);
            }
        }



        protected void MostrarStatus(string funcao)
        {
            if (repositorioBase.ItemEncontrado())
            {
                MostrarMensagem($"{nomeEntidade} {funcao} com sucesso", ConsoleColor.Green);
            }
            else
                MostrarMensagem($"Não foi possível localizar o id solicitado", ConsoleColor.Magenta);
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