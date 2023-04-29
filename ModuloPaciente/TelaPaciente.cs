using consoleApp.ModuloCorpartilhado;
using consoleApp.ModuloEndereco;
using System.Collections;

namespace consoleApp.ModuloPaciente
{
    public class TelaPaciente : TelaBase
    {
        CadastroEndereco cadastroEndereco;

        public TelaPaciente(RepositorioPaciente repositorioPaciente)
        {
            this.repositorioBase = repositorioPaciente;
            this.cadastroEndereco = new CadastroEndereco();
        }

        public override string nomeEntidade { get; set; } = "Paciente";

        public override void MostrarTabela(ArrayList registros, bool esperarTecla)
        {
            Console.WriteLine($"{"ID",-3} | {"NOME COMPLETO",-20} | {"IDADE",-5} | {"CARTÃO SAÚDE",-12} | {"TELEFONE",-12} | {cadastroEndereco.MostrarCabecalho()}");
            Console.WriteLine("----|----------------------|-------|--------------|--------------|-------------------------------------------------------------");

            RenderizarTabela(registros, esperarTecla);
        }

        public override EntidadeBase ObterRegistro()
        {
            this.erros = new ArrayList();

            MostrarTexto("Informe o primeiro nome do paciente:");
            string nome = Console.ReadLine()!;

            if (nome.Trim() == string.Empty || nome.Trim().Length < 3)
            {
                this.erros.Add("* O campo nome precisa ter no mínimo três letras.");
            }

            MostrarTexto("Informe o sobrenome do paciente:");
            string sobreNome = Console.ReadLine()!;

            if (sobreNome.Trim() == string.Empty || sobreNome.Trim().Length < 3)
            {
                this.erros.Add("* O campo sobrenome precisa ter no mínimo três letras.");
            }
            DateTime dataNascimento = default;
            try
            {
                MostrarTexto("Data de nascimento: (dd/MM/yyyy)");
                dataNascimento = Convert.ToDateTime(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                this.erros.Add("* Data informada em um formato inválido");
            }

            MostrarTexto("Nr Cartão saúde:");
            string nrCartao = Console.ReadLine()!;

            if (nrCartao.Trim() == string.Empty)
            {
                this.erros.Add("* O Número do Cartao é campo obrigatório.");
            }

            MostrarTexto("Telefone:");
            string telefone = Console.ReadLine()!;

            Endereco? endereco = cadastroEndereco.CadastrarEndereco();

            if (endereco == null)
            {
                erros.Add("* Endereço contém campos inválidos");
            }


            return erros.Count > 0 ? null! : new Paciente(nome, sobreNome, dataNascimento, nrCartao, telefone, endereco);
        }
    }
}