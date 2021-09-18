using Projeto02.Entites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto02.Repsoitories
{
    public class FuncionarioRepositoryXML
    {
        public void ExportarDados(Funcionario funcionario)
        {
            var nomeArquivo = $"funcionario_{funcionario.Id}.xml";
            var xmlSerializer = new XmlSerializer(funcionario.GetType());

            using (var streamWriter = new StreamWriter("c:\\temp\\" + nomeArquivo))
            {
                xmlSerializer.Serialize(streamWriter, funcionario);
            }
        }
    }
}
