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
    public class FuncionariosController : ControllerBase
    {
        [HttpPost] //Cadastro
        public IActionResult Post(FuncionarioPostModel model, 
            [FromServices] IFuncionarioRepository funcionarioRepository, 
            [FromServices] IEmpresaRepository empresaRepository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                //verificar se o cpf ja esta cadastrado na base de dados..
                if (funcionarioRepository.GetByCpf(model.Cpf) != null)
                    return UnprocessableEntity("O CPF informado já encontra-se cadastrado."); //422

                //verificar se a empresa não existe no banco de dados..
                if(empresaRepository.GetById(model.IdEmpresa) == null)
                    return UnprocessableEntity("Empresa não encontrada."); //422

                var funcionario = mapper.Map<Funcionario>(model);
                funcionarioRepository.Create(funcionario);

                return Ok("Funcionário cadastrado com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpPut] //Atualização
        public IActionResult Put(FuncionarioPutModel model,
            [FromServices] IFuncionarioRepository funcionarioRepository,
            [FromServices] IEmpresaRepository empresaRepository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                //buscando o funcionario no banco de dados atraves do ID..
                var funcionario = funcionarioRepository.GetById(model.IdFuncionario);

                //verificar se o funcionario não foi encontrado..
                if (funcionario == null)
                    return UnprocessableEntity("Funcionário não encontrado."); //422

                //verificar se a empresa não existe no banco de dados..
                if (empresaRepository.GetById(model.IdEmpresa) == null)
                    return UnprocessableEntity("Empresa não encontrada."); //422

                funcionario = mapper.Map<Funcionario>(model);
                funcionarioRepository.Update(funcionario);

                return Ok("Funcionário atualizado com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpDelete("{idFuncionario}")] //Exclusão
        public IActionResult Delete(Guid idFuncionario, 
            [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            try
            {
                //buscando o funcionario no banco de dados atraves do ID..
                var funcionario = funcionarioRepository.GetById(idFuncionario);

                //verificar se o funcionario não foi encontrado..
                if (funcionario == null)
                    return UnprocessableEntity("Funcionário não encontrado."); //422

                funcionarioRepository.Delete(funcionario);

                return Ok("Funcionário excluído com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet] //Consulta de todos os funcionários
        public IActionResult GetAll(
            [FromServices] IFuncionarioRepository funcionarioRepository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                //consultar todos os funcionarios no repositorio
                var funcionarios = funcionarioRepository.GetAll();

                //verificar se algum registro foi obtido..
                if(funcionarios != null && funcionarios.Count > 0)
                {
                    //transferir os dados dos funcionarios para a classe model atraves do automapper
                    var model = mapper.Map<List<FuncionarioGetModel>>(funcionarios);

                    //retornar os dados
                    return Ok(model);
                }
                else
                {
                    return NoContent(); //HTTP 204 (vazio)
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet("{idFuncionario}")] //Consulta de funcionário por id
        public IActionResult GetById(Guid idFuncionario, 
            [FromServices] IFuncionarioRepository funcionarioRepository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                //buscar 1 funcionario no banco de dados baseado no id..
                var funcionario = funcionarioRepository.GetById(idFuncionario);

                //verificar se algum funcionario foi encontrado
                if(funcionario != null)
                {
                    //converter os dados do funcionario para o objeto model, atraves do automapper
                    var model = mapper.Map<FuncionarioGetModel>(funcionario);

                    //retornar os dados
                    return Ok(model);
                }
                else
                {
                    return NoContent(); //HTTP 204 (vazio)
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet("{dataAdmissaoMin}/{dataAdmissaoMax}")]
        public IActionResult GetByDataAdmissao(DateTime dataAdmissaoMin, DateTime dataAdmissaoMax, 
            [FromServices] IFuncionarioRepository funcionarioRepository, 
            [FromServices] IMapper mapper)
        {
            try
            {
                //consultar funcionarios por data de admissão
                var funcionarios = funcionarioRepository.GetByDataAdmissao(dataAdmissaoMin, dataAdmissaoMax);

                //verificar se algum registro foi obtido..
                if (funcionarios != null && funcionarios.Count > 0)
                {
                    //transferir os dados dos funcionarios para a classe model atraves do automapper
                    var model = mapper.Map<List<FuncionarioGetModel>>(funcionarios);

                    //retornar os dados
                    return Ok(model);
                }
                else
                {
                    return NoContent(); //HTTP 204 (vazio)
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
    }
}
