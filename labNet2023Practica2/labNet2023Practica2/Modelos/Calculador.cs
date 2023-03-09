using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNet2023Practica2.Modelos
{

    public class Calculador
    {


        public ResultadoCalculo DividirPorCero(int numero)
        {
            ResultadoCalculo resultado;
            try
            {
                int valor = numero / 0;
                resultado = new ResultadoCalculo(string.Empty, true);
                return resultado;
            }
            catch (DivideByZeroException ex)
            {
                resultado = new ResultadoCalculo(ex.Message, false);
                return resultado;
            }
           
        }

        
        public ResultadoCalculo CalculoDividendoDivisor(int Dividendo, int Divisor)
        {
            ResultadoCalculo resultado;
            try
            {
                int valor = Dividendo / Divisor;
                resultado = new ResultadoCalculo(string.Empty, true, valor);
                return resultado;
            }
            catch (DivideByZeroException ex)
            {
                resultado = new ResultadoCalculo(Mensajes.ChukNorris + "\n" + ex.Message, false);
                return resultado;
            }
            
        }
        
    }
}
