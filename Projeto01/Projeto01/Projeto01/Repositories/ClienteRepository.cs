using Projeto01.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Projeto01.Repositories
{
    public class ClienteRepository
    {
        public void ExportarDados(Cliente cliente)
        {
            using (var streamWriter = new StreamWriter("c:\\temp\\clientes.txt"))
            {
                streamWriter.WriteLine("Id.....: " + cliente.Id);
                streamWriter.WriteLine("Nome.....: " + cliente.Nome);
                streamWriter.WriteLine("Email.....: " + cliente.Email);
                streamWriter.WriteLine("Cpf.....: " + cliente.Cpf);
                streamWriter.WriteLine("\n");
            }
        }
    }
}
