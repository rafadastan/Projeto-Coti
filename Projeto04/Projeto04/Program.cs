using Projeto04.Entites;
using Projeto04.Repositories;
using Projeto04.Utils;
using System;

namespace Projeto04
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Projeto04;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            Console.WriteLine("\nCADASTRO DE EMPRESA\n");

            //instanciando os objetos
            var empresa = new Empresa();
            var empresaRepository = new EmpresaRepository(connectionString);

            try
            {
                empresa.IdEmpresa = Guid.NewGuid();
                empresa.RazaoSocial = ConsoleUtil.Input("Informe a Razão Social:");
                empresa.Cnpj = ConsoleUtil.Input("Informe o CNPJ:");

                empresaRepository.Inserir(empresa);

                Console.WriteLine("\nEmpresa cadastrada com sucesso.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
