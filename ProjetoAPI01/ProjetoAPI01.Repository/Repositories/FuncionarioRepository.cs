using Microsoft.EntityFrameworkCore;
using ProjetoAPI01.Domain.Entities;
using ProjetoAPI01.Repository.Contexts;
using ProjetoAPI01.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoAPI01.Repository.Repositories
{
    public class FuncionarioRepository
        : BaseRepository<Funcionario, Guid>, IFuncionarioRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para inicialização do atributo
        public FuncionarioRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        //sobrescrita do método GetAll
        public override List<Funcionario> GetAll()
        {
            //Sintaxe LAMBDA
            return _context.Funcionario
                    .Include(f => f.Empresa) //JOIN
                    .ToList();

            //Sintaxe LINQ (Language Integrated Query)
            /*
            var query = from f in _context.Funcionario
                        join e in _context.Empresa on f.IdEmpresa equals e.IdEmpresa
                        select f;

            return query.ToList();
            */
        }

        //sobrescrita do método GetById
        public override Funcionario GetById(Guid id)
        {
            //Sintaxe LAMBDA
            return _context.Funcionario
                    .Include(f => f.Empresa) //JOIN
                    .FirstOrDefault(f => f.IdFuncionario.Equals(id));

            //Sintaxe LINQ (Language Integrated Query)
            /*
            var query = from f in _context.Funcionario
                        join e in _context.Empresa on f.IdEmpresa equals e.IdEmpresa
                        where f.IdFuncionario.Equals(id)
                        select f;

            return query.FirstOrDefault();
            */
        }

        public Funcionario GetByCpf(string cpf)
        {
            //Sintaxe LAMBDA
            return _context.Funcionario
                    .Include(f => f.Empresa) //JOIN
                    .FirstOrDefault(f => f.Cpf.Equals(cpf));

            //Sintaxe LINQ (Language Integrated Query)
            /*
            var query = from f in _context.Funcionario
                        join e in _context.Empresa on f.IdEmpresa equals e.IdEmpresa
                        where f.Cpf.Equals(cpf)
                        select f;

            return query.FirstOrDefault();
            */
        }

        public List<Funcionario> GetByDataAdmissao(DateTime dataMin, DateTime dataMax)
        {
            //Sintaxe LAMBDA
            return _context.Funcionario
                    .Include(f => f.Empresa) //JOIN
                    .Where(f => f.DataAdmissao >= dataMin
                             && f.DataAdmissao <= dataMax)
                    .OrderBy(f => f.DataAdmissao)
                    .ToList();

            //Sintaxe LINQ (Language Integrated Query)
            /*
            var query = from f in _context.Funcionario
                        join e in _context.Empresa on f.IdEmpresa equals e.IdEmpresa
                        where f.DataAdmissao >= dataMin
                           && f.DataAdmissao <= dataMax
                        orderby f.DataAdmissao ascending
                        select f;

            return query.ToList();
            */
        }
    }
}
