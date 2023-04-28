using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleApp.ModuloCorpartilhado;

namespace consoleApp.ModuloPaciente
{
    public class RepositorioPaciente : RepositorioBase
    {
        public override Paciente BuscarPorId(int id)
        {
            return(Paciente) base.BuscarPorId(id);
        }
    }
}