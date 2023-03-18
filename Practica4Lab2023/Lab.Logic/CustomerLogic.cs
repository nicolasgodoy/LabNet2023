using Lab.Data;
using Lab.Entities;
using Lab.Logic.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Logic
{
    public class CustomerLogic : BaseLogic
    {

        // 1. METHOD SINTAX
        public Customers GetCustomerObject()
        {
            return context.Customers.FirstOrDefault();

        }


        // 4. QUERY SINTAX
        public List<Customers> GetCustomerRegionWA()
        {
            var result = from r in context.Customers
                         where r.Region == "WA"
                         select r;
            return result.ToList();

        }

        

        // 6. QUERY SINTAX
        public List<string> GetNameCustomerUpper()
        {
            var result = from u in context.Customers
                        select u.ContactName.ToUpper();
            return result.ToList(); ;

        }

        // 6. QUERY SINTAX
        public List<string> GetNameCustomerLower()
        {
            var result = from u in context.Customers
                         select u.ContactName.ToLower();
            return result.ToList();

        }

        // 7. QUERY SINTAX
        public List<CustomersOrdersDto> GetCustomerJoinOrders()
        {
            DateTime orderDate = new DateTime(1997,1,1);
            var result = from c in context.Customers
                         join o in context.Orders on c.CustomerID equals o.CustomerID
                         where o.OrderDate > orderDate && c.Region == "WA"
                         select new CustomersOrdersDto
                         {
                             CustomerID = c.CustomerID,
                             CompanyName = c.CompanyName,
                             ContactName = c.ContactName,
                             ContactTitle = c.ContactTitle,
                             Address = c.Address,
                             City = c.City,
                             Region = c.Region,
                             PostalCode = c.PostalCode,
                             Country = c.Country,
                             Phone = c.Phone,
                             Fax = c.Fax,

                             OrderID = o.OrderID,
                             EmployeeID = o.EmployeeID,
                             OrderDate = o.OrderDate,
                             RequiredDate = o.RequiredDate,
                             ShippedDate = o.ShippedDate,
                             ShipVia = o.ShipVia,
                             Freight = o.Freight,
                             ShipName = o.ShipName,
                             ShipAddress = o.ShipAddress,
                             ShipCity = o.ShipCity,
                             ShipRegion = o.ShipRegion,
                             ShipPostalCode = o.ShipPostalCode,
                             ShipCountry = o.ShipCountry
                         };
            return result.ToList();

        }

    }
}
