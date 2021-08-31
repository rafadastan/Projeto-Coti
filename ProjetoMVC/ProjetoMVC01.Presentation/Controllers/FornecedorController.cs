using Microsoft.AspNetCore.Mvc;
using ProjetoMVC01.Domain.Entities;
using ProjetoMVC01.Presentation.Models;
using ProjetoMVC01.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC01.Presentation.Controllers
{
    public class FornecedorController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Cadastro(FornecedorCadastroViewModel model,
            [FromServices] FornecedorRepository fornecedorRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fornecedor = new Fornecedor();

                    fornecedor.Nome = model.Nome;
                    fornecedor.Cnpj = model.Cnpj;

                    fornecedorRepository.Create(fornecedor);

                    TempData["MensagemSucesso"] = $"Fornecedor '{fornecedor.Nome}', cadastrado com sucesso.";

                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Ocorreu um erro: " + e.Message;
                }
            }
            else
            {
                TempData["MensagemAlerta"] = "Ocorreram erros de validação no preenchimento do formulário.";
            }

            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Consulta(FornecedorConsultaViewModel model,
            [FromServices] FornecedorRepository fornecedorRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Fornecedores = fornecedorRepository.GetByNome(model.Nome);

                    if (model.Fornecedores.Count > 0)
                    {
                        TempData["MensagemSucesso"] = $"Consulta realizada com sucesso. {model.Fornecedores.Count} fornecedore(s) obtido(s).";
                    }
                    else
                    {
                        TempData["MensagemAlerta"] = "Nenhum resultado foi encontrado para a busca realizada.";
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Ocorreu um erro: " + e.Message;
                }
            }
            else
            {
                TempData["MensagemAlerta"] = "Ocorreram erros de validação no preenchimento do formulário.";
            }

            return View(model);
        }

        public IActionResult Exclusao(Guid id, //Fornecedor/Exclusao?id=?
            [FromServices] FornecedorRepository fornecedorRepository)
        {
            try
            {
                var fornecedor = fornecedorRepository.GetById(id);

                if (fornecedor != null)
                {
                    fornecedorRepository.Delete(fornecedor);
                    TempData["MensagemSucesso"] = $"Fornecedor '{fornecedor.Nome}' excluído com sucesso.";
                }
                else
                {
                    TempData["MensagemAlerta"] = "Fornecedor não foi encontrado.";
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Ocorreu um erro: " + e.Message;
            }

            return View("Consulta");
        }

        public IActionResult Edicao(Guid id, //Fornecedor/Edicao?id=?
            [FromServices] FornecedorRepository fornecedorRepository)
        {
            var model = new FornecedorEdicaoViewModel();

            try
            {
                var fornecedor = fornecedorRepository.GetById(id);

                if (fornecedor != null) 
                {
                    model.IdFornecedor = fornecedor.IdFornecedor;
                    model.Nome = fornecedor.Nome;
                    model.Cnpj = fornecedor.Cnpj;
                }
                else
                {
                    TempData["MensagemAlerta"] = "Fornecedor não foi encontrado.";
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Ocorreu um erro: " + e.Message;
            }

            return View(model);
        }
    }
}
