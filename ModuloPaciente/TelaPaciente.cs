using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleApp.ModuloCorpartilhado;
using consoleApp.ModuloEndereco;

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

           info.RenderizarTabela(registros, esperarTecla);
        }

        public override EntidadeBase ObterRegistro()
        {
            info.MostrarTexto("Informe o primeiro nome do paciente:");
            string nome = Console.ReadLine()!;

            info.MostrarTexto("Informe o sobrenome do paciente:");
            string sobreNome = Console.ReadLine()!;

            info.MostrarTexto("Data de nascimento: (dd/MM/yyyy)");

            DateTime dataNascimento = Convert.ToDateTime(Console.ReadLine()!);

            info.MostrarTexto("Nr Cartão saúde:");
            string nrCartao = Console.ReadLine()!;

            info.MostrarTexto("Telefone:");
            string telefone = Console.ReadLine()!;

            Endereco? endereco = cadastroEndereco.CadastrarEndereco();
            
            return new Paciente(nome, sobreNome, dataNascimento, nrCartao, telefone, endereco);
        }
    }
}