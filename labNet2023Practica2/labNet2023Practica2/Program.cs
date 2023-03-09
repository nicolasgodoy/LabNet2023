using labNet2023Practica2.Excepciones;
using labNet2023Practica2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNet2023Practica2
{
    public class Program
    {

        static void Main(string[] args)
        {
            Ejercicio1();
            Ejercicio2();
            Ejercicio3();
            Ejercicio4();

            Console.ReadLine();
        }

        private static void Ejercicio1()
        {
            string numeroIngresado;
            int numero;
            bool esNumero;

            Calculador calculos = new Calculador();

            Console.WriteLine("Ingrese un numero: ");
            numeroIngresado = Console.ReadLine();

            esNumero = int.TryParse(numeroIngresado, out numero);
            if (esNumero == false)
            {
                Console.WriteLine("Solo se permite el ingreso de numeros enteros");
                return;
            }

            ResultadoCalculo resultado = calculos.DividirPorCero(numero);

            if (resultado.Exitoso)
            {
                Console.WriteLine(Mensajes.OperacionExitosa);
            }
            else
            {
                Console.WriteLine(Mensajes.OperacionNoExitosa);
                Console.WriteLine(resultado.Mensaje);
            }
        }

        private static void Ejercicio2()
        {
            int numeroDividendo;
            int numeroDivisor;
            string numeroIngresado;
            bool esNumero;

            Calculador calculos = new Calculador();

            try
            {
                Console.WriteLine("\n");
                Console.WriteLine("Ingrese el Dividendo: ");
                numeroIngresado = Console.ReadLine();

                esNumero = int.TryParse(numeroIngresado, out numeroDividendo);
                if (esNumero == false)
                {
                    throw new NumeroInvalidoExcepcion();
                }

                Console.WriteLine("Ingrese el Divisor: ");
                numeroIngresado = Console.ReadLine();

                esNumero = int.TryParse(numeroIngresado, out numeroDivisor);
                if (esNumero == false)
                {
                    throw new NumeroInvalidoExcepcion();
                }

            }
            catch (NumeroInvalidoExcepcion ex)
            {
                Console.WriteLine(Mensajes.NumeroInvalido);
                return;
            }

            ResultadoCalculo resultadoDividendoDivisor = calculos.CalculoDividendoDivisor(numeroDividendo, numeroDivisor);

            if (resultadoDividendoDivisor.Exitoso)
            {
                Console.WriteLine(Mensajes.OperacionExitosa);
                Console.WriteLine("Resultado: " + resultadoDividendoDivisor.Valor);
            }
            else
            {
                Console.WriteLine(Mensajes.OperacionNoExitosa);
                Console.WriteLine(resultadoDividendoDivisor.Mensaje);
            }

        }

        private static void Ejercicio3()
        {
            Logic logic = new Logic();

            try
            {
                Console.WriteLine("\n");

                Console.WriteLine("Ejecucion de MetodoLogic");

                logic.MetodoLogic();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType().Name.ToString());

            }
        }
        private static void Ejercicio4()
        {

            try
            {
                Console.WriteLine("\n");
                
                throw new PersonalizadaExepcion("|" +" Mensaje Personalizado 2");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType().Name.ToString());

            }
        }
    }
}
