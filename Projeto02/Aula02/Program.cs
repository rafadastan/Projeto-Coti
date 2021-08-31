using Projeto02.Entites;
using Projeto02.Repsoitories;
using Projeto02.Utils;
using System;
using System.Collections.Generic;

namespace Aula02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nCONTROLE DE FUNCIONÁRIOS\n");

            //instanciando a classe Funcionario (objeto)
            var funcionario = new Funcionario(); //espaço de memória

            //instanciando as associações de Funcionario com Setor e Função
            funcionario.Setor = new Setor(); //espaço de memória
            funcionario.Funcao = new Funcao(); //espaço de memória

            //instanciando a lista de dependentes do funcionário
            funcionario.Dependentes = new List<Dependente>();

            //preenchendo os dados do funcionario..
            funcionario.Id = Guid.NewGuid();
            funcionario.Nome = ConsoleUtil.Input("\nInforme o nome do funcionário:");
            funcionario.Matricula = ConsoleUtil.Input("\nInforme a matrícula do funcionário:");
            funcionario.Cpf = ConsoleUtil.Input("\nInforme o cpf do funcionário:");
            funcionario.DataAdmissao = DateTime.Parse(ConsoleUtil.Input("\nInforme a data de admissão:"));

            //preenchendo os dados do setor associado ao funcionário..
            funcionario.Setor.Id = Guid.NewGuid();
            funcionario.Setor.Nome = ConsoleUtil.Input("\nInforme o nome do setor:");

            //preenchendo os dados da função associada ao funcionário..
            funcionario.Funcao.Id = Guid.NewGuid();
            funcionario.Funcao.Descricao = ConsoleUtil.Input("\nInforme a descrição da função:");

            //solicitar que o usuario informe a quantidade de dependentes
            //que deseja incluir para o funcionário..
            var quantidade = int.Parse(ConsoleUtil.Input("\nInforme a quantidade de dependentes:"));

            //laço de repetição -> for
            for (int i = 0; i < quantidade; i++)
            {
                //criando um objeto da classe Dependente
                var dependente = new Dependente();

                dependente.Id = Guid.NewGuid();
                dependente.Nome = ConsoleUtil.Input("\nInforme o nome do dependente:");
                dependente.DataNascimento = DateTime.Parse(ConsoleUtil.Input("\nData de Nascimento:"));
                dependente.Observacoes = ConsoleUtil.Input("\nObservações:");

                //adicionando o dependente no funcionário..
                funcionario.Dependentes.Add(dependente);
            }

            var funcionarioRepository = new FuncioarioRepositoryJSON();
            var funcionarioRepositoryXML = new FuncionarioRepositoryXML();


            try
            {
                funcionarioRepository.ExportarDados(funcionario);

                funcionarioRepositoryXML.ExportarDados(funcionario);

                Console.WriteLine("\n Dados gravado com sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro " + e.Message);
            }
        }
    }
}
