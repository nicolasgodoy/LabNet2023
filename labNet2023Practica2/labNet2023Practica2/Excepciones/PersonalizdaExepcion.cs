using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNet2023Practica2.Excepciones
{
    public class PersonalizadaExepcion : Exception
    {
        public override string Message { get; }
        public PersonalizadaExepcion(string mensaje):base(mensaje)
        {
            Message = "Mensaje Personalizado" + " " + base.Message;
        }
    }
}
