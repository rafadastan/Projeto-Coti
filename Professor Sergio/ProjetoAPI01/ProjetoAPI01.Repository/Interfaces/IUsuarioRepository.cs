using ProjetoAPI01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI01.Repository.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, Guid>
    {
        Usuario GetByEmail(string email);
        Usuario GetByEmailAndSenha(string email, string senha);
    }
}
