using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI01.Services.Models
{
    public class FuncionarioPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do funcionário.")]
        public Guid IdFuncionario { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do funcionário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a matrícula do funcionário.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de admissão do funcionário.")]
        public DateTime DataAdmissao { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do funcionário.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe a empresa do funcionário.")]
        public Guid IdEmpresa { get; set; }
    }
}
