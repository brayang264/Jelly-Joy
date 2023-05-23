using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelly_Joy
{
    public class OpBasicas
    {
        public static bool EsNumero(string numero)
        {
            bool flag = int.TryParse(numero, out int num);
            return flag;
        }
        public static int ConvertirANum(string numero)
        {
            if(!EsNumero(numero))
            {
                return -1;
            }
            return int.Parse(numero);
        }
    }
}
