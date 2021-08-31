using AutoMapper;
using ProjetoAPI01.Domain.Entities;
using ProjetoAPI01.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI01.Services.Mappings
{
    public class ModelToEntityMap : Profile
    {
        public ModelToEntityMap()
        {
            CreateMap<EmpresaPostModel, Empresa>()
                .AfterMap((src, dest) =>
                {
                    dest.IdEmpresa = Guid.NewGuid();
                });

            CreateMap<EmpresaPutModel, Empresa>();

            CreateMap<FuncionarioPostModel, Funcionario>()
                .AfterMap((src, dest) =>
                {
                    dest.IdFuncionario = Guid.NewGuid();
                });

            CreateMap<FuncionarioPutModel, Funcionario>();
        }
    }
}
