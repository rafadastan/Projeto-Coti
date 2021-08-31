using ProjetoAPI01.Domain.Entities;
using ProjetoAPI01.Repository.Contexts;
using ProjetoAPI01.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoAPI01.Repository.Repositories
{
    public class UsuarioRepository
        : BaseRepository<Usuario, Guid>, IUsuarioRepository
    {
        private readonly SqlServerContext _context;

        public UsuarioRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public Usuario GetByEmail(string email)
        {
            //LAMBDA
            /*
            return _context.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email));
            */

            //LINQ -> Language integrated query
            var query = from u in _context.Usuario
                        where u.Email.Equals(email)
                        select u;

            return query.FirstOrDefault();
        }

        public Usuario GetByEmailAndSenha(string email, string senha)
        {
            //LAMBDA
            /*
            return _context.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email)
                                      && u.Senha.Equals(senha));
            */

            //LINQ -> Language integrated query
            var query = from u in _context.Usuario
                        where u.Email.Equals(email) 
                           && u.Senha.Equals(senha)
                        select u;

            return query.FirstOrDefault();
        }
    }
}
