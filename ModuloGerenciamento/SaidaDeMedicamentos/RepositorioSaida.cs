using consoleApp.ModuloGerenciamento.Compartilhado;
using System.Collections;

namespace consoleApp.ModuloGerenciamento.SaidaDeMedicamentos
{
    public class RepositorioSaida : RepositorioBaseGerenciamento, IComparer
    {

        public int Compare(object? x, object? y)
        {
            SaidaMedicamento sx = (SaidaMedicamento)x!;
            SaidaMedicamento sy = (SaidaMedicamento)y!;

            if (sx.medicamento.id > sy.medicamento.id)
                return 1;

            else if (sx.medicamento.id == sy.medicamento.id)
                return 0;

            else
                return -1;

        }
    }
}