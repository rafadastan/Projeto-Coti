using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI01.CrossCutting.Settings
{
    public class TokenSettings
    {
        //armazenar uma chave secreta utilizada
        //para criptografar o conteudo do TOKEN..
        public string SecretKey { get; set; }
    }
}
