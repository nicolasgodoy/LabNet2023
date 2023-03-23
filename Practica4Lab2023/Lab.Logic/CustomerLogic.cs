using Lab.Entities;
using Lab.Logic.Excepciones;
using Lab.Logic.Interfaces;
using System.Collections.Generic;
using System.Linq;



namespace Lab.Logic
{
    public class CustomerLogic : BaseLogic, IABMLogic<Customers>
    {
        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }

        public void Add(Customers newCustomer)
        {
            ValidField(newCustomer);
            var customerExist = context.Customers.Find(newCustomer.CustomerID);

            if (customerExist != null)
            {
                throw new EntityFoundException("Customer Repetido, Vuelve a ingresar los datos");
            }

            context.Customers.Add(newCustomer);
            context.SaveChanges();
        }

        public void ValidField(Customers customer)
        {
            if (customer.CustomerID == null || customer.CompanyName == null)
            {
                throw new FieldNullException("los campos CustomerID y CompanyName son obligatorios");
            }

            if (customer.CustomerID.Length != 5)
            {
                throw new FieldLenghtInvalidException("La longitud de CustomerID es invalida");
            }
        }

        public void ValidEntityNotFound(Customers customer)
        {

            if (customer == null)
            {
                throw new EntityNotFoundException("Customer no fue encontrado");
            }
        }

        public void Update(Customers customer)
        {
            ValidField(customer);
            var customerUpdate = context.Customers.Find(customer.CustomerID);
            ValidEntityNotFound(customerUpdate);

            customerUpdate.CustomerID = customer.CustomerID;
            customerUpdate.ContactName = customer.ContactName;
            customerUpdate.CompanyName = customer.CompanyName;
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var customerDelete = context.Customers.First(n => n.CustomerID == id);
            ValidEntityNotFound(customerDelete);
            context.Customers.Remove(customerDelete);
            context.SaveChanges();
        }


    }
}
