using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI01.Domain.Entities;
using ProjetoAPI01.Repository.Interfaces;
using ProjetoAPI01.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI01.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        [HttpPost] //Cadastro
        public IActionResult Post(EmpresaPostModel model, 
            [FromServices] IEmpresaRepository empresaRepository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                //verificando se o cnpj informado já esta cadastrado no banco..
                if (empresaRepository.GetByCnpj(model.Cnpj) != null)
                    return UnprocessableEntity("O CNPJ informado já encontra-se cadastrado."); //422

                var empresa = mapper.Map<Empresa>(model);
                empresaRepository.Create(empresa);

                return Ok("Empresa cadastrada com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpPut] //Atualização
        public IActionResult Put(EmpresaPutModel model, 
            [FromServices] IEmpresaRepository empresaRepository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                //buscar no banco de dados a empresa atraves do id informado..
                var empresa = empresaRepository.GetById(model.IdEmpresa);

                //verificar se a empresa não foi encontrada..
                if (empresa == null)
                    return UnprocessableEntity("Empresa não encontrada.");

                empresa = mapper.Map<Empresa>(model);
                empresaRepository.Update(empresa);

                return Ok("Empresa atualizada com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpDelete("{idEmpresa}")] //Exclusão
        public IActionResult Delete(Guid idEmpresa, 
            [FromServices] IEmpresaRepository empresaRepository)
        {
            try
            {
                //buscar no banco de dados a empresa atraves do id informado..
                var empresa = empresaRepository.GetById(idEmpresa);

                //verificar se a empresa não foi encontrada..
                if (empresa == null)
                    return UnprocessableEntity("Empresa não encontrada.");

                empresaRepository.Delete(empresa);

                return Ok("Empresa excluída com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet] //Consulta de todas as empresas
        public IActionResult GetAll(
            [FromServices] IEmpresaRepository empresaRepository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                //consultar todas as empresas no repositorio..
                var empresas = empresaRepository.GetAll();

                //verificar se algum registro foi encontrado..
                if(empresas != null && empresas.Count > 0)
                {
                    //utilizando o automapper para transferir os dados da entidade para a model..
                    var model = mapper.Map<List<EmpresaGetModel>>(empresas);

                    //retorno os dados
                    return Ok(model);
                }
                else
                {
                    //204 NoContent (Sucesso!)
                    return NoContent();
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet("{idEmpresa}")] //Consulta de empresa por id
        public IActionResult GetById(Guid idEmpresa, 
            [FromServices] IEmpresaRepository empresaRepository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                //consultar 1 empresa atraves do id..
                var empresa = empresaRepository.GetById(idEmpresa);

                //verificar se a empresa foi encontrada
                if(empresa != null)
                {
                    //transferir os dados da entidade empresa para a model
                    var model = mapper.Map<EmpresaGetModel>(empresa);

                    //retorno os dados
                    return Ok(model);
                }
                else
                {
                    return NoContent(); //HTTP 204
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
    }
}
