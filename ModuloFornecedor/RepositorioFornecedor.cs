using consoleApp.ModuloCorpartilhado;

namespace consoleApp.ModuloFornecedor
{
    public class RepositorioFornecedor : RepositorioBase
    {
        public override Fornecedor BuscarPorId(int id)
        {
            return (Fornecedor)base.BuscarPorId(id);
        }
    }
}