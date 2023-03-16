using Lab.Entities;
using Lab.Logic;
using Lab.Logic.Excepciones;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4Lab2023
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            MostrandoDatosEntidades();
            AddCustomer();
            UpdateCustomer();
            DeleteCustomer();


            Console.Write("\nPress 'Enter' to exit the process...");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }

        }
        private static void MostrandoDatosEntidades()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            CategoryLogic categoryLogic = new CategoryLogic();


            Console.WriteLine("| CustomerID |" + "| ContactName |" + " - " + "| CompanyName |");
            Console.WriteLine("");
            foreach (Customers customer in customerLogic.GetAll())
            {
                Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} - {customer.CompanyName}");
            }



            Console.WriteLine("");
            Console.WriteLine("| CategorietName |" + " - " + "| CategorieDescription |");
            Console.WriteLine("");
            foreach (Categories categorie in categoryLogic.GetAll())
            {
                Console.WriteLine($"{categorie.CategoryName} - {categorie.Description}");
            }
        }


        private static void AddCustomer()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            bool ingresoInvalido = true;
            string CustomerID;
            string ContactNameCustomers;
            string CompanyNameCustomers;

            while (ingresoInvalido)
            {
                try
                {

                    Console.WriteLine("");
                    Console.WriteLine(" =====Ingresando Datos===== ");


                    CustomerID = IngresoCustomerID();
                    ContactNameCustomers = IngresoContactName();
                    CompanyNameCustomers = IngresoCompanyName();

                    Customers newCustomer = new Customers(CustomerID, ContactNameCustomers, CompanyNameCustomers);

                    customerLogic.Add(newCustomer);


                    Console.WriteLine("| ContactName |" + " - " + "| CompanyName |");
                    Console.WriteLine("");
                    foreach (Customers customer in customerLogic.GetAll())
                    {
                        Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} - {customer.CompanyName}");
                    }

                    ingresoInvalido = false;
                }
                catch (EntityFoundException ex)
                {
                    ingresoInvalido = true;
                    Console.WriteLine(ex.Message);
                }
                catch (FieldNullException ex)
                {
                    ingresoInvalido = true;
                    Console.WriteLine(ex.Message);
                }
                catch (FieldLenghtInvalidException ex)
                {
                    ingresoInvalido = true;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {

                    ingresoInvalido = true;
                    Console.WriteLine("Ocurrio un error Inesperado");
                }
            }

        }

        private static string IngresoCustomerID()
        {
            bool ingresoInvalido = true;
            string customerID = string.Empty;

            while (ingresoInvalido)
            {
                Console.WriteLine(" Ingrese el CustomerID: ");
                customerID = Console.ReadLine();

                if (customerID == null || customerID.Length != 5)
                {
                    Console.WriteLine("Fallo, Debe ingresar Nuevamente la informacion");
                }
                else
                {
                    ingresoInvalido = false;
                }

            }
            return customerID;

        }
        private static string IngresoContactName()
        {
            bool ingresoInvalido = true;
            string ContactNameCustomers = string.Empty;

            while (ingresoInvalido)
            {
                Console.WriteLine(" Ingrese el ContactName de Customers: ");
                ContactNameCustomers = Console.ReadLine();

                if (ContactNameCustomers == null || ContactNameCustomers.Length < 30 && ContactNameCustomers.Length == 30)
                {
                    Console.WriteLine("Fallo, Debe ingresar Nuevamente la informacion");
                }
                else
                {
                    ingresoInvalido = false;
                }

            }
            return ContactNameCustomers;

        }
        private static string IngresoCompanyName()
        {
            bool ingresoInvalido = true;
            string CompanyNameCustomers = string.Empty;

            while (ingresoInvalido)
            {
                Console.WriteLine("Ingrese el CompanyName de Customers: ");
                CompanyNameCustomers = Console.ReadLine();

                if (CompanyNameCustomers == null || CompanyNameCustomers.Length < 40 && CompanyNameCustomers.Length == 40)
                {
                    Console.WriteLine("Fallo, Debe ingresar Nuevamente la informacion");
                }
                else
                {
                    ingresoInvalido = false;
                }

            }
            return CompanyNameCustomers;
        }

        
        
        private static void UpdateCustomer()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            string CustomerID;
            string ContactNameCustomers;
            string CompanyNameCustomers;
            bool ingresoInvalido = true;

            while (ingresoInvalido)
            {

                try
                {
                    Console.WriteLine("");
                    Console.WriteLine(" =====Editar de Datos===== ");

                    CustomerID = IngresoCustomerID();
                    ContactNameCustomers = IngresoContactName();
                    CompanyNameCustomers = IngresoCompanyName();

                    Customers newCustomer = new Customers(CustomerID, ContactNameCustomers, CompanyNameCustomers);
                    customerLogic.Update(newCustomer);

                    Console.WriteLine("| ContactName |" + " - " + "| CompanyName |");
                    Console.WriteLine("");
                    foreach (Customers customer in customerLogic.GetAll())
                    {
                        Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} - {customer.CompanyName}");
                    }
                    ingresoInvalido = false;
                }
                catch (EntityNotFoundException ex)
                {
                    ingresoInvalido = true;
                    Console.WriteLine(ex.Message);
                }
                catch (FieldNullException ex)
                {
                    ingresoInvalido = true;
                    Console.WriteLine(ex.Message);
                }
                catch (FieldLenghtInvalidException ex)
                {
                    ingresoInvalido = true;
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {

                    ingresoInvalido = true;
                    Console.WriteLine("Ocurrio un error Inesperado");
                }


            }
        }

        private static void DeleteCustomer()
        {

            CustomerLogic customerLogic = new CustomerLogic();
            string CustomerID;
            bool ingresoInvalido = true;

            while (ingresoInvalido)
            {

                try
                {

                    Console.WriteLine("");
                    Console.WriteLine(" =====Eliminacion de Datos===== ");

                    Console.WriteLine(" Ingrese el CustomerID que desea Eliminar: ");
                    CustomerID = Console.ReadLine();
                    customerLogic.Delete(CustomerID);

                    Console.WriteLine("| ContactName |" + " - " + "| CompanyName |");
                    Console.WriteLine("");
                    foreach (Customers customer in customerLogic.GetAll())
                    {
                        Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} - {customer.CompanyName}");
                    }
                    ingresoInvalido = false;
                }
                catch (EntityNotFoundException ex)
                {
                    ingresoInvalido = true;
                    Console.WriteLine(ex.Message);
                }

                catch (Exception)
                {
                    ingresoInvalido = true;
                    Console.WriteLine("Se debe ingresar nuevamente la informacion");
                }

            }
        }


    }
}

