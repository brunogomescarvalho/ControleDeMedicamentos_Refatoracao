using System;
using consoleApp.ModuloCorpartilhado;

namespace consoleApp.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase
    {
        public override Funcionario BuscarPorId(int id)
        {
            return(Funcionario)base.BuscarPorId(id);
        }
        
    }
}