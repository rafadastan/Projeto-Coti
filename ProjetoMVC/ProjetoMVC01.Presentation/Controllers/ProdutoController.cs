using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC01.Presentation.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Consulta()
        {
            return View();
        }
    }
}
