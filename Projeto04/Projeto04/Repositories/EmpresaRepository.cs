using Dapper;
using Projeto04.Contracts;
using Projeto04.Entites;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Repositories
{
    /// <summary>
    /// Classe que implementa as operações de repositorio para Empresa
    /// </summary>
    public class EmpresaRepository : IEmpresaRepository
    {
        //atributo privado (acessado somente dentro da própria classe)
        private string connectionString;

        //método construtor com entrada de argumentos..
        public EmpresaRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Empresa obj)
        {
            //criando a query (comando SQL) para gravar empresa no banco
            var query = "insert into Empresa(IdEmpresa, RazaoSocial, Cnpj) "
                      + "values(@IdEmpresa, @RazaoSocial, @Cnpj)";

            //abrindo conexão com o banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                //executar o comando SQL (query)
                connection.Execute(query, obj);
            }
        }

        public void Alterar(Empresa obj)
        {
            var query = "update Empresa set RazaoSocial = @RazaoSocial, Cnpj = @Cnpj "
                      + "where IdEmpresa = @IdEmpresa";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Excluir(Empresa obj)
        {
            var query = "delete from Empresa where IdEmpresa = @IdEmpresa";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Empresa> Consultar()
        {
            var query = "select * from Empresa order by RazaoSocial";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Empresa>(query).ToList();
            }
        }
    }
}
