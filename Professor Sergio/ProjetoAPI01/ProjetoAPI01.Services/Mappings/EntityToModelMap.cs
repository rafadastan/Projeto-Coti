using AutoMapper;
using ProjetoAPI01.Domain.Entities;
using ProjetoAPI01.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI01.Services.Mappings
{
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Empresa, EmpresaGetModel>();
            CreateMap<Funcionario, FuncionarioGetModel>();
        }
    }
}
