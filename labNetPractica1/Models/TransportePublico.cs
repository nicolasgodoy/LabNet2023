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

        public abstract string Avanzar();


        public abstract string Detenerse();

        public abstract string DescripcionTipo();

        public string Descripcion()
        {
            
            return DescripcionTipo() + " " + this.id + ": " + this.pasajeros + " pasajeros";

        }

    }
}
