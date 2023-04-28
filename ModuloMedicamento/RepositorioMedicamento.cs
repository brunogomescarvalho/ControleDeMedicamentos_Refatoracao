using consoleApp.ModuloCorpartilhado;
using System.Collections;

namespace consoleApp.ModuloMedicamento
{
    public class RepositorioMedicamento : RepositorioBase, IComparer
    {

         public int Compare(object? x, object? y)
        {
            Medicamento mx = (Medicamento)x!;
            Medicamento my = (Medicamento)y!;

            if (mx.quantidade > my.quantidade)
                return 1;

            else if (mx.quantidade == my.quantidade)
                return 0;
                
            else return -1;
        }

        public override Medicamento BuscarPorId(int id)
        {
            return (Medicamento)base.BuscarPorId(id);
        }

        public bool ItemCadastrado(string nome, int id)
        {
            string nomeLower = "";
            foreach (Medicamento item in BuscarTodos())
            {
                foreach (var i in item.nome!)
                    nomeLower += i.ToString().ToLower();

                if (nomeLower == nome.ToLower() && id == item.fornecedor.id)
                    return true;
                nomeLower = "";
            }

            return false;
        }
    }
}