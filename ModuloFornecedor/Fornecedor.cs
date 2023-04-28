using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleApp.ModuloCorpartilhado;
using consoleApp.ModuloEndereco;

namespace consoleApp.ModuloFornecedor
{
    public class Fornecedor : EntidadeBase 
    {
        public string cnpj { get; set; }
        public string telefone { get; set; }
        public Endereco? endereco { get; set; }

        public Fornecedor(string nome, string cnpj, string telefone, Endereco? endereco) : base(nome)
        {
            this.cnpj = cnpj;
            this.telefone = telefone;
            this.endereco = endereco;
        }

        public override void Editar(EntidadeBase entidade)
        {
            Fornecedor fornecedor = (Fornecedor)entidade;

            this.nome = fornecedor.nome;
            this.cnpj = fornecedor.cnpj;
            this.telefone = fornecedor.telefone;
            this.endereco = fornecedor.endereco;
        }

          public override string ToString()
        {
            return $"{id,-3} | {nome,-15} | {cnpj,-15} | {telefone,-15} | {endereco}";
        }
    }
}