using Lab.Entities;
using Lab.Logic.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab.Logic.Tests
{
    [TestClass()]
    public class CustomerLogicTests
    {
        [TestMethod()]
        public void ValidFieldFailTest()
        {

            FieldNullException fieldNullException = null;
            try
            {
                CustomerLogic customerLogic = new CustomerLogic();
                Customers customer = new Customers();
                customerLogic.ValidField(customer);
            }
            catch (FieldNullException ex)
            {
                fieldNullException = ex;
            }


            Assert.IsNotNull(fieldNullException);

           
        }

        [TestMethod()]
        public void ValidFieldTest()
        {

            FieldNullException fieldNullException = null;
            try
            {
                CustomerLogic customerLogic = new CustomerLogic();
                Customers customer = new Customers("ZZZZZ", "Nicolas","Google");
                customerLogic.ValidField(customer);
            }
            catch (FieldNullException ex)
            {
                fieldNullException = ex;
            }


            Assert.IsNull(fieldNullException);


        }
    }
}