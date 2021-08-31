using ProjetoAPI01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI01.Repository.Interfaces
{
    public interface IEmpresaRepository : IBaseRepository<Empresa, Guid>
    {
        Empresa GetByCnpj(string cnpj);
    }
}
