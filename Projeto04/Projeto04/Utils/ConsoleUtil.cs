using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Utils
{
    public class ConsoleUtil
    {
        public static string Input(string mensagem)
        {
            Console.WriteLine(mensagem);
            return Console.ReadLine();
        }
    }
}
