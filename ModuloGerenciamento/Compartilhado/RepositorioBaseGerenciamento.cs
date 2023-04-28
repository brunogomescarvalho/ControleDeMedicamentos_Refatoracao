using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace consoleApp.ModuloGerenciamento.Compartilhado
{
    public class RepositorioBaseGerenciamento
    {
        protected ArrayList registros = new ArrayList();

        private int contadorId = 1;

        public virtual void Adicionar(GerenciamentoBase entidade)
        {
            entidade.id = contadorId++;
            this.registros.Add(entidade);
        }

        public virtual GerenciamentoBase BuscarPorId(int id)
        {
            foreach (GerenciamentoBase item in BuscarTodos())
            {
                if (item.id == id)
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
    }
}