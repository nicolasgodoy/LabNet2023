using Microsoft.VisualStudio.TestTools.UnitTesting;
using labNet2023Practica2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNet2023Practica2.Modelos.Tests
{
    [TestClass()]
    public class CalculadorTests
    {
        [TestMethod()]
        public void DividirPorCeroTest()
        {
            Calculador calculos = new Calculador();

            ResultadoCalculo resultado = calculos.DividirPorCero(10);

            Assert.IsFalse(resultado.Exitoso);
            
            Assert.AreEqual("Intento de dividir por cero.", resultado.Mensaje);
        }

        [TestMethod()]
        public void CalculoDividendoDivisorExitosoTest()
        {
            Calculador calculos = new Calculador();

            ResultadoCalculo resultadoDividendoDivisor = calculos.CalculoDividendoDivisor(10,5);

            Assert.IsTrue(resultadoDividendoDivisor.Exitoso);

            Assert.AreEqual(string.Empty, resultadoDividendoDivisor.Mensaje);


        }

        [TestMethod()]
        public void CalculoDividendoDivisorNoExitosoTest()
        {
            Calculador calculos = new Calculador();

            ResultadoCalculo resultadoDividendoDivisor = calculos.CalculoDividendoDivisor(10, 0);

            Assert.IsFalse(resultadoDividendoDivisor.Exitoso);

            Assert.AreEqual("Solo Chuck Norris divide por cero!" + "\n" + "Intento de dividir por cero.", resultadoDividendoDivisor.Mensaje);


        }
    }
}