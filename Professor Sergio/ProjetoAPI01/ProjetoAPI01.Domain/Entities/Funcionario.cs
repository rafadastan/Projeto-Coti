using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI01.Domain.Entities
{
    public class Funcionario
    {
        #region Propriedades

        public Guid IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid IdEmpresa { get; set; }

        #endregion

        #region Associações

        public Empresa Empresa { get; set; }

        #endregion
    }
}
