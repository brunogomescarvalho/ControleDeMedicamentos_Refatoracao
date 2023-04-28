using System.Collections;

namespace consoleApp.ModuloCorpartilhado
{

    public interface IMostraInfos
    {
        public abstract string nomeEntidade { get; set; }

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
