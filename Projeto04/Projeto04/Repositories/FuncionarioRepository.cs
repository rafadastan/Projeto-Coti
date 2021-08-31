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
    /// Classe que implementa as operações de repositorio para Funcionário
    /// </summary>
    public class FuncionarioRepository : IFuncionarioRepository
    {
        //atributo privado(acessado somente dentro da própria classe)
        private string connectionString;

        //método construtor com entrada de argumentos..
        public FuncionarioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Funcionario obj)
        {
            var query = "insert into Funcionario(IdFuncionario, Nome, Matricula, Cpf, DataAdmissao, IdEmpresa) "
                      + "values(@IdFuncionario, @Nome, @Matricula, @Cpf, @DataAdmissao, @IdEmpresa)";

            using (var connection = new SqlConnection())
            {
                connection.Execute(query, obj);
            }

            //EXECUTANDO UMA PROCEDURE -> SP_InserirFuncionario
            //Parametros -> @IdFuncionario, @Nome, @Matricula, @Cpf, @DataAdmissao, @IdEmpresa

            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Execute("SP_InserirFuncionario",
            //        new
            //        {
            //            @IdFuncionario = obj.IdFuncionario,
            //            @Nome = obj.Nome,
            //            @Matricula = obj.Matricula,
            //            @Cpf = obj.Cpf,
            //            @DataAdmissao = obj.DataAdmissao,
            //            @IdEmpresa = obj.IdEmpresa
            //        },
            //        commandType: CommandType.StoredProcedure);
            //}
        }

        public void Alterar(Funcionario obj)
        {
            var query = "update Funcionario set Nome = @Nome, Matricula = @Matricula, Cpf = @Cpf, DataAdmissao = @DataAdmissao "
                      + "IdEmpresa = @IdEmpresa where IdFuncionario = @IdFuncionario";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Excluir(Funcionario obj)
        {
            var query = "delete from Funcionario where IdFuncionario = @IdFuncionario";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Funcionario> Consultar()
        {
            var query = "select * from Funcionario order by Nome";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query).ToList();
            }
        }
    }
}
