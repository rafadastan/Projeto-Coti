using Newtonsoft.Json;
using Projeto02.Entites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Repsoitories
{
    public class FuncioarioRepositoryJSON
    {
        public void ExportarDados(Funcionario funcionario)
        {
            var nomeArquivo = $"funcionario_{funcionario.Id}.json";

            using (var streamWriter = new StreamWriter("c:\\temp\\" + nomeArquivo))
            {
                var dados = JsonConvert.SerializeObject(funcionario, Formatting.Indented);
                streamWriter.WriteLine(dados);
            }
        }
    }
}
