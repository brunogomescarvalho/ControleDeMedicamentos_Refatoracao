using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleApp.ModuloFuncionario;
using consoleApp.ModuloMedicamento;

namespace consoleApp.ModuloGerenciamento.Compartilhado
{
    public abstract class GerenciamentoBase
    {
        public int id { get; set; }
        public Medicamento medicamento { get; set; }
        public Funcionario funcionario { get; set; }
        public DateTime dataRegistro { get; set; }
        public int quantidade { get; set; }

        public GerenciamentoBase(Medicamento medicamento, Funcionario funcionario, DateTime dataRegistro, int quantidade)
        {
            this.quantidade = quantidade;
            this.medicamento = medicamento;
            this.funcionario = funcionario;
            this.dataRegistro = dataRegistro;
        }

       
       
    }
}