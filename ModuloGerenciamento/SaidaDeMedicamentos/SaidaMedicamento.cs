using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleApp.ModuloFuncionario;
using consoleApp.ModuloGerenciamento.Compartilhado;
using consoleApp.ModuloMedicamento;
using consoleApp.ModuloPaciente;

namespace consoleApp.ModuloGerenciamento.SaidaDeMedicamentos
{
    public class SaidaMedicamento : GerenciamentoBase
    {
        public Paciente paciente;
        public SaidaMedicamento(Paciente paciente, Medicamento medicamento, Funcionario funcionario, DateTime dataRegistro, int quantidade) : base(medicamento, funcionario, dataRegistro, quantidade)
        {
            this.paciente = paciente;
        }

        public bool DescontarMedicamento()
        {
            return this.medicamento.DeduzirQuantidade(this.quantidade);
        }
    }
}