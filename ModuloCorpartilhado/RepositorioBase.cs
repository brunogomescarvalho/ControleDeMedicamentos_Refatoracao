using System.Collections;

namespace consoleApp.ModuloCorpartilhado
{
    public abstract class RepositorioBase
    {
        protected ArrayList registros = new ArrayList();

        private EntidadeBase? entidadeBase;

        private int contadorId = 1;

        public virtual void Adicionar(EntidadeBase entidade)
        {
            entidade.SetId(contadorId++);
            this.registros.Add(entidade);
        }

        public virtual EntidadeBase BuscarPorId(int id)
        {
            foreach (EntidadeBase item in BuscarTodos())
            {
                if (item.GetId() == id)
                {
                    return item;
                }
            }
            return null!;
        }

        public ArrayList BuscarTodos()
        {
            return registros;
        }

        public virtual void Editar(EntidadeBase entidadeModificada, int id)
        {
            entidadeBase = BuscarPorId(id);
            entidadeBase?.Editar(entidadeModificada);
        }

        public void Excluir(int id)
        {
            entidadeBase = BuscarPorId(id);

            if (entidadeBase != null)
            {
                this.registros.Remove(entidadeBase);
            }
        }

        public bool ItemEncontrado()
        {
            return this.entidadeBase != null;
        }
    }
}