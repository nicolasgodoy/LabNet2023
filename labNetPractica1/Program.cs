using labNetPractica1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica1
{
    class Program
    {

        static void Main(string[] args)
        {

            string mensajeEstadoOmnibus;
            string mensajeEstadotaxis;
            int pasajerosOmnibus;


            List<TransportePublico> transportePublicos = new List<TransportePublico>();


            Console.WriteLine(" ===== Ingreso de Omnibus ===== ");
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("Ingrese la Cantidad de pasajeros del Omnibus " + "|" + i + "|");
                pasajerosOmnibus = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Estan todos sus pasajeros en sus asientos?: (SI/NO) ");
                mensajeEstadoOmnibus = Convert.ToString(Console.ReadLine().ToUpper());

                bool estadoAsientos;
                if (mensajeEstadoOmnibus == "SI")
                {
                    estadoAsientos = true;

                }
                else
                {
                    estadoAsientos = false;
                }

                Omnibus omnibus = new Omnibus(i, estadoAsientos, pasajerosOmnibus);
                transportePublicos.Add(omnibus);
                Console.WriteLine("\n");
            }


            /* ===================================== */

            int pasajerosTaxi;


            Console.WriteLine(" ===== Ingreso de Taxis ===== ");
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("Ingrese la Cantidad de pasajeros del Taxi " + "|" + i + "|");
                pasajerosTaxi = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Los pasajeros tienen puesto el cinturon?: (SI/NO) ");
                mensajeEstadotaxis = Convert.ToString(Console.ReadLine().ToUpper());

                bool estadoCinturones;
                if (mensajeEstadotaxis == "SI")
                {
                    estadoCinturones = true;
                }
                else
                {
                    estadoCinturones = false;
                }

                Taxi taxi = new Taxi(i, estadoCinturones, pasajerosTaxi);
                transportePublicos.Add(taxi);
                Console.WriteLine("\n");
            }

            foreach (TransportePublico item in transportePublicos)
            {
                Console.WriteLine(item.Descripcion());
                Console.WriteLine(item.Avanzar());
                Console.WriteLine(item.Detenerse());
                Console.WriteLine("\n");
            }



            Console.ReadLine();
        }
    }
}













