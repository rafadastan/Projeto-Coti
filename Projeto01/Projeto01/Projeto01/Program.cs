using Projeto01.Entities;
using Projeto01.Repositories;
using System;

namespace Projeto01
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = new Cliente();

            cliente.Id = Guid.NewGuid();

            Console.WriteLine("Entre com o Nome");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Entre com o Email");
            cliente.Email = Console.ReadLine();

            Console.WriteLine("Entre com o Cpf");
            cliente.Cpf = Console.ReadLine();

            var clienteRepository = new ClienteRepository();

            try
            {
                clienteRepository.ExportarDados(cliente);
                Console.WriteLine("\nDados Gravados com sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro!" + e.Message);
            }

            Console.ReadKey();
        }
    }
}
