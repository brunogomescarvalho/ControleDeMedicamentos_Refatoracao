using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleApp.ModuloFuncionario;
using consoleApp.ModuloGerenciamento.Compartilhado;
using consoleApp.ModuloMedicamento;
using consoleApp.ModuloPaciente;

namespace consoleApp.ModuloGerenciamento.EntradaDeMedicamentos
{
    public class EntradaMedicamento : GerenciamentoBase
    {
        public EntradaMedicamento(Medicamento medicamento, Funcionario funcionario, DateTime dataRegistro, int quantidade) : base(medicamento, funcionario, dataRegistro, quantidade)
        {
            this.CompensarMedicamento();
        }

        public void CompensarMedicamento()
        {
            this.medicamento.AdicionarQuantidade(this.quantidade);
        }


    }
}