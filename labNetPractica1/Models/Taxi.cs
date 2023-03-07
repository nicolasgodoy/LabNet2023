using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica1.Models
{
    internal class Taxi : TransportePublico
    {
        private bool estadoCinturones;

        public Taxi(int id, bool estadoCinturones, int pasajeros):base(id, pasajeros)
        {
            this.estadoCinturones = estadoCinturones;
        }
        public override string Avanzar()
        {
            if (estadoCinturones)
            {
                return "Puede iniciar su viaje sin problemas, Que tenga buen dia!!";
            }
            else
            {
                return "Por cuestiones de seguridad, pedirlo a su pasajero que se ponga el cinturon";
            }
        }

        public override string Detenerse()
        {
            return "El Taxi se detuvo. Ahora pueden bajar los pasajeros.";
        }

        public override string DescripcionTipo()
        {
            return "Taxi";
        }
    }
}
