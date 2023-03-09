using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNet2023Practica2.Modelos
{
    public class ResultadoCalculo
    {
        public string Mensaje { get; }
        public bool Exitoso { get; }
        public int Valor { get; }
       

        public ResultadoCalculo(string mensaje, bool exitoso)
        {
            this.Mensaje = mensaje;
            this.Exitoso = exitoso;
           
        }

        public ResultadoCalculo(string mensaje, bool exitoso, int valor)
        {
            this.Mensaje = mensaje;
            this.Exitoso = exitoso;
            this.Valor = valor;

        }

    }
}
