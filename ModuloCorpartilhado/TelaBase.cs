using System.Collections;


namespace consoleApp.ModuloCorpartilhado
{
    public abstract class TelaBase : IMostraInfos
    {
        public RepositorioBase repositorioBase = null!;
        public abstract string nomeEntidade { get; set; }
        public abstract EntidadeBase ObterRegistro();
        public abstract void MostrarTabela(ArrayList registros, bool esperarTecla);
        protected IMostraInfos info = null!;
        public ArrayList erros = null!;

        public TelaBase()
        {
            this.info = this;
        }

        public int MostrarMenu()
        {
            info.MostrarTexto($"--- {nomeEntidade} ---");
            Console.WriteLine("1 --- Cadastrar");
            Console.WriteLine("2 --- Visualizar");
            Console.WriteLine("3 --- Editar");
            Console.WriteLine("4 --- Excluir");
            Console.WriteLine("9 --- Voltar");

            return int.Parse(Console.ReadLine()!);

        }

        public virtual void Cadastrar()
        {
            info.MostrarTexto("---Cadastrar---");

            this.erros = new ArrayList();

            try
            {
                EntidadeBase entidade = ObterRegistro();

                repositorioBase.Adicionar(entidade);

                info.MostrarMensagem($"{nomeEntidade} cadastrado com sucesso", ConsoleColor.Green);
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

        public virtual void Visualizar()
        {
            info.MostrarTexto($"--- Listar Registros {nomeEntidade} ---\n");

            ArrayList registros = repositorioBase.BuscarTodos();

            if (!info.ListaContemItens(registros))
                return;

            MostrarTabela(registros, true);
        }

        public virtual void Editar()
        {
            this.erros = new ArrayList();

            info.MostrarTexto($"--- Editar Registro {nomeEntidade} ---");

            ArrayList registros = repositorioBase.BuscarTodos();

            if (!info.ListaContemItens(registros))
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
                    info.MostrarErros($"{item}", ConsoleColor.Magenta);
                }

                Console.ReadKey();
            }

        }

        public void Excluir()
        {
            info.MostrarTexto($"--- Excluir Registro {nomeEntidade} ---");

            ArrayList registros = repositorioBase.BuscarTodos();

            if (!info.ListaContemItens(registros))
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
                info.MostrarMensagem("Id informado em um formato inválido", ConsoleColor.Magenta);
            }
        }



        protected void MostrarStatus(string funcao)
        {
            if (repositorioBase.ItemEncontrado())
            {
                info.MostrarMensagem($"{nomeEntidade} {funcao} com sucesso", ConsoleColor.Green);
            }
            else
                info.MostrarMensagem($"Não foi possível localizar o id solicitado", ConsoleColor.Magenta);
        }
    }

}