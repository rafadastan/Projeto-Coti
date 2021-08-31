using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI01.Domain.Entities
{
    public class Empresa
    {
        #region Propriedades

        public Guid IdEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }

        #endregion

        #region Associações

        public List<Funcionario> Funcionarios { get; set; }

        #endregion
    }
}
