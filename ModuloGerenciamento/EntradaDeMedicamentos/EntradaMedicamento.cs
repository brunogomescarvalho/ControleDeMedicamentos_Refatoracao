using consoleApp.ModuloFuncionario;
using consoleApp.ModuloGerenciamento.Compartilhado;
using consoleApp.ModuloMedicamento;


namespace consoleApp.ModuloGerenciamento.EntradaDeMedicamentos;

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