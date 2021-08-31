using ProjetoAPI01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI01.Repository.Interfaces
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario, Guid>
    {
        List<Funcionario> GetByDataAdmissao(DateTime dataMin, DateTime dataMax);
        Funcionario GetByCpf(string cpf);        
    }
}
