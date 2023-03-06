using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica1.Models
{
    abstract class TransportePublico
    {
        private int id;
        private int pasajeros;


        public TransportePublico(int id, int pasajeros)
        {
            this.id = id;
            this.pasajeros = pasajeros;
        }

        public abstract void Avanzar();


        public abstract void Detenerse();

        public abstract string DescripcionTipo();

        public void Descripcion()
        {
            Console.WriteLine(DescripcionTipo() + " " + this.id + ": " + this.pasajeros + " pasajeros");
            
        }

    }
}
