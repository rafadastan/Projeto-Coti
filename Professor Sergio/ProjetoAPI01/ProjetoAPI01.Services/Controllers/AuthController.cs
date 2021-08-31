using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoApi01.CrossCutting.Security.Services;
using ProjetoAPI01.Repository.Interfaces;
using ProjetoAPI01.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI01.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(AuthPostModel model, 
            [FromServices] IUsuarioRepository usuarioRepository, 
            [FromServices] TokenService tokenService)
        {
            try
            {
                //procurar o usuario no banco de dados atraves do email e senha..
                var usuario = usuarioRepository.GetByEmailAndSenha(model.Email, model.Senha);

                //verificar se o usuario foi encontrado..
                if(usuario != null)
                {
                    //gerando o TOKEN do usuario..
                    var accessToken = tokenService.GenerateToken(usuario.Email);

                    //retornando o token de autenticação
                    return Ok(new
                    {
                        Mensagem = "Usuário autenticado com sucesso.",
                        accessToken
                    });
                }
                else
                {
                    //retornando erro HTTP 401 (Unauthorized)
                    return StatusCode(401, "Acesso Negado, usuário inválido.");
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
    }
}
