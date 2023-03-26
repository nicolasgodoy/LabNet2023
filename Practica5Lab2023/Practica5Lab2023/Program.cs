using Lab.Entities;
using Lab.Logic;
using Lab.Logic.Dto;
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

            string opcionesMenu = string.Empty;
            int Contador = 0;

            Console.WriteLine("============== Crud de Customers ==============");
            Console.WriteLine(" Ingrese una opcion para acceder alguna Query ");
            Console.WriteLine(" 1 - Ingresar a la query 1 ");
            Console.WriteLine(" 2 - Ingresar a la query 2 ");
            Console.WriteLine(" 3 - Ingresar a la query 3 ");
            Console.WriteLine(" 4 - Ingresar a la query 4 ");
            Console.WriteLine(" 5 - Ingresar a la query 5 ");
            Console.WriteLine(" 6 - Ingresar a la query 6 ");
            Console.WriteLine(" 7 - Ingresar a la query 7 ");
            Console.WriteLine(" 8 - Ingresar a la query 8 ");
            Console.WriteLine(" 9 - Ingresar a la query 9 ");
            Console.WriteLine(" 10 - Ingresar a la query 10 ");
            Console.WriteLine(" 0 - Para terminar el programa ");

            opcionesMenu = Console.ReadLine();

            while (opcionesMenu != "0")
            {

                if (opcionesMenu == "1")
                {
                    MetodoQuery1();
                }
                else if (opcionesMenu == "2")
                {
                    MetodoQuery2();

                }
                else if (opcionesMenu == "3")
                {
                    MetodoQuery3();

                }
                else if (opcionesMenu == "4")
                {
                    MetodoQuery4();

                }
                else if (opcionesMenu == "5")
                {
                    MetodoQuery5();

                }
                else if (opcionesMenu == "6")
                {
                    MetodoQuery6();

                }
                else if (opcionesMenu == "7")
                {
                    MetodoQuery7();

                }
                else if (opcionesMenu == "8")
                {
                    MetodoQuery8();

                }
                else if (opcionesMenu == "9")
                {
                    MetodoQuery9();

                }
                else if (opcionesMenu == "10")
                {
                    MetodoQuery10();

                }
                else
                {
                    Console.WriteLine("Ocurrio un error, o no ingreso una de las opciones");

                }


                Contador++;

                Console.WriteLine("============== Crud de Customers ==============");
                Console.WriteLine(" Ingrese una opcion para acceder alguna Query ");
                Console.WriteLine(" 1 - Ingresar a la query 1 ");
                Console.WriteLine(" 2 - Ingresar a la query 2 ");
                Console.WriteLine(" 3 - Ingresar a la query 3 ");
                Console.WriteLine(" 4 - Ingresar a la query 4 ");
                Console.WriteLine(" 5 - Ingresar a la query 5 ");
                Console.WriteLine(" 6 - Ingresar a la query 6 ");
                Console.WriteLine(" 7 - Ingresar a la query 7 ");
                Console.WriteLine(" 8 - Ingresar a la query 8 ");
                Console.WriteLine(" 9 - Ingresar a la query 9 ");
                Console.WriteLine(" 10 - Ingresar a la query 10 ");
                Console.WriteLine(" 0 - Para terminar el programa ");
                opcionesMenu = Console.ReadLine();

            }


            Console.Write("\nPress 'Enter' to exit the process...");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
        }
    


        private static void MetodoQuery1()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            Customers customerObject = customerLogic.GetCustomerObject();
            Console.WriteLine("================ QUERY 1 ================");

            Console.WriteLine($" {customerObject.CustomerID} - {customerObject.CompanyName} - {customerObject.ContactName} - {customerObject.ContactTitle} - {customerObject.Address} " +
            $"- {customerObject.City} - {customerObject.Region} - {customerObject.PostalCode} - {customerObject.Country} - {customerObject.Phone} - {customerObject.Fax} ");
        }

        private static void MetodoQuery2()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            List<Products> listProductSinStock = productsLogic.GetProductSinStock();

            Console.WriteLine("\n");
            Console.WriteLine("================ QUERY 2 ================");

            foreach (Products productSinStock in listProductSinStock)
            {
                Console.WriteLine($" {productSinStock.ProductID} - {productSinStock.ProductName} - {productSinStock.SupplierID} - {productSinStock.Suppliers} - {productSinStock.CategoryID} " +
                $"- {productSinStock.Categories} - {productSinStock.QuantityPerUnit} - {productSinStock.UnitPrice} - {productSinStock.UnitsInStock} - {productSinStock.UnitsOnOrder} - {productSinStock.ReorderLevel} ");
            }
        }

        private static void MetodoQuery3()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            List<Products> listProductStock = productsLogic.GetProductStock();
            Console.WriteLine("\n");
            Console.WriteLine("================ QUERY 3 ================");


            foreach (Products productStock in listProductStock)
            {
                Console.WriteLine($" {productStock.ProductID} - {productStock.ProductName} - {productStock.SupplierID} - {productStock.Suppliers} - {productStock.CategoryID} " +
                $"- {productStock.Categories} - {productStock.QuantityPerUnit} - {productStock.UnitPrice} - {productStock.UnitsInStock} - {productStock.UnitsOnOrder} - {productStock.ReorderLevel} ");
            }
        }

        private static void MetodoQuery4()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            List<Customers> listCustomer = customerLogic.GetCustomerRegionWA();
            Console.WriteLine("\n");
            Console.WriteLine("================ QUERY 4 ================");

            foreach (Customers customer in listCustomer)
            {
                Console.WriteLine($" {customer.CustomerID} - {customer.CompanyName} - {customer.ContactName} - {customer.ContactTitle} - {customer.Address} " +
                $"- {customer.City} - {customer.Region} - {customer.PostalCode} - {customer.Country} - {customer.Phone} - {customer.Fax} ");
            }
        }

        private static void MetodoQuery5()
        {

            ProductsLogic productsLogic = new ProductsLogic();
            Console.WriteLine("\n");
            Console.WriteLine("================ QUERY 5 ================");
            Products product = productsLogic.GetProductsOrNull();

            if (product == null)
            {
                Console.WriteLine("El Producto no Existe o es null");
            }
            else
            {
                Console.WriteLine("El Producto Existe");
            }
        }

        private static void MetodoQuery6()
        {

            CustomerLogic customerLogic = new CustomerLogic();
            List<string> listNameCustomerUpper = customerLogic.GetNameCustomerUpper();

            Console.WriteLine("\n");
            Console.WriteLine("================ QUERY 6 Mayusculas ================");


            foreach (string item in listNameCustomerUpper)
            {
                Console.WriteLine($"{item}");

            }

            Console.WriteLine("\n");
            Console.WriteLine("================ QUERY 6 Minusculas ================");

            List<string> listNameCustomerLower = customerLogic.GetNameCustomerLower();

            foreach (string item in listNameCustomerLower)
            {
                Console.WriteLine($"{item}");

            }
        }
        private static void MetodoQuery7()
        {

            CustomerLogic customerLogic = new CustomerLogic();
            List<CustomersOrdersDto> listCustomersOrdersDto = customerLogic.GetCustomerJoinOrders();
            Console.WriteLine("\n");
            Console.WriteLine("================ QUERY 7 ================");

            foreach (CustomersOrdersDto customerOrdersDto in listCustomersOrdersDto)
            {
                Console.WriteLine($" {customerOrdersDto.CustomerID} - {customerOrdersDto.Region} - {customerOrdersDto.OrderDate} ");

            }
        }

        private static void MetodoQuery8()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            List<Customers> listCustomer = customerLogic.GetCustomerPrimerosTres();
            Console.WriteLine("\n");
            Console.WriteLine("================ QUERY 8 ================");

            foreach (Customers customer in listCustomer)
            {
                Console.WriteLine($" {customer.CustomerID} - {customer.CompanyName} - {customer.ContactName} - {customer.ContactTitle} - {customer.Address} " +
                $"- {customer.City} - {customer.Region} - {customer.PostalCode} - {customer.Country} - {customer.Phone} - {customer.Fax} ");
            }
        }

        private static void MetodoQuery9()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            List<Products> listProductStock = productsLogic.GetProductsOrderByName();
            Console.WriteLine("\n");
            Console.WriteLine("================ QUERY 9 ================");


            foreach (Products productStock in listProductStock)
            {
                Console.WriteLine($" {productStock.ProductID} - {productStock.ProductName} - {productStock.SupplierID} - {productStock.Suppliers} - {productStock.CategoryID} " +
                $"- {productStock.Categories} - {productStock.QuantityPerUnit} - {productStock.UnitPrice} - {productStock.UnitsInStock} - {productStock.UnitsOnOrder} - {productStock.ReorderLevel} ");
            }
        }

        private static void MetodoQuery10()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            List<Products> listProductStock = productsLogic.GetProductsOrderByStockDesc();
            Console.WriteLine("\n");
            Console.WriteLine("================ QUERY 10 ================");


            foreach (Products productStock in listProductStock)
            {
                Console.WriteLine($" {productStock.ProductID} - {productStock.ProductName} - {productStock.SupplierID} - {productStock.Suppliers} - {productStock.CategoryID} " +
                $"- {productStock.Categories} - {productStock.QuantityPerUnit} - {productStock.UnitPrice} - {productStock.UnitsInStock} - {productStock.UnitsOnOrder} - {productStock.ReorderLevel} ");
            }
        }

        private static void MetodoQuery11()
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            List<Categories> listCategories = categoriesLogic.GetCategoriesWidthProducts();
            Console.WriteLine("\n");
            Console.WriteLine("================ QUERY 11 ================");


            foreach (Categories categories in listCategories)
            {
                Console.WriteLine($" {categories.CategoryID} - {categories.CategoryName} - ");
            }
        }


    }
}

