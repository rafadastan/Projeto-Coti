using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Entites
{
    /// <summary>
    /// Classe de entidade para modelo de dados de Empresa
    /// </summary>
    public class Empresa
    {
        public Guid IdEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }

        public List<Funcionario> Funcionarios { get; set; }
    }
}
