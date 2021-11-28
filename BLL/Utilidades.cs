using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasWPF.BLL
{
    public class Utilidades
    {
        public static int Toint(string valor)
        {
            int retorno;

            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static float ToFloat(string valor)
        {
            float retorno;

            float.TryParse(valor, out retorno);

            return retorno;
        }
    }
}
