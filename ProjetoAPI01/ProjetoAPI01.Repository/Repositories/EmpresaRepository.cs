using ProjetoAPI01.Domain.Entities;
using ProjetoAPI01.Repository.Contexts;
using ProjetoAPI01.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoAPI01.Repository.Repositories
{
    public class EmpresaRepository 
        : BaseRepository<Empresa, Guid>, IEmpresaRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para inicialização
        public EmpresaRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public Empresa GetByCnpj(string cnpj)
        {
            //LAMBDA
            /*
            return _context.Empresa
                    .FirstOrDefault(e => e.Cnpj.Equals(cnpj));
            */

            var query = from e in _context.Empresa
                        where e.Cnpj.Equals(cnpj)
                        select e;

            return query.FirstOrDefault();
        }
    }
}
