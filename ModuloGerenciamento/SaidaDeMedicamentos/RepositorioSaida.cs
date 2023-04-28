using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleApp.ModuloGerenciamento.Compartilhado;

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