using consoleApp.ModuloCorpartilhado;

namespace consoleApp.ModuloPaciente
{
    public class RepositorioPaciente : RepositorioBase
    {
        public override Paciente BuscarPorId(int id)
        {
            return (Paciente)base.BuscarPorId(id);
        }
    }
}