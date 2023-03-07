using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace labNetPractica1.Models
{
    internal class Omnibus : TransportePublico
    {
        private bool estadoAsientos;

        public Omnibus(int id, bool estadoAsientos, int pasajeros) : base(id, pasajeros)
        {
            this.estadoAsientos = estadoAsientos;
        }
        public override string Avanzar()
        {
            if (this.estadoAsientos)
            {
                return "Entonces puede avanzar sin problemas, Buen Viaje!!";
            }
            else
            {
                return "Por favor controle y verifique que todos sus pasajeros esten en sus asientos!!";
            }
        }

        public override string Detenerse()
        {
            return "El Omnibus se detuvo. Ahora pueden bajar los pasajeros.";
        }

        public override string DescripcionTipo()
        {
            return "Omnibus";
        }
    }
}
