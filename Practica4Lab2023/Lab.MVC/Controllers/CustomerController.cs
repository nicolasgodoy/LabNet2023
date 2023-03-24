using Lab.Entities;
using Lab.Logic;
using Lab.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            List<CustomersViewModel> listCustomer = customerLogic.GetAll()
            .Select(c => new CustomersViewModel { Id = c.CustomerID, companyName = c.CompanyName, contactName = c.ContactName }).ToList();

            return View(listCustomer);

        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewData["Action"] = "Add";
            return View("AddOrUpdate", new CustomersViewModel());
        }

        [HttpPost]
        public ActionResult Add(CustomersViewModel customerView)
        {
            
            CustomerLogic customerLogic = new CustomerLogic();
            Customers customerEntity = new Customers { CustomerID = customerView.Id, CompanyName = customerView.companyName, ContactName = customerView.contactName };
            customerLogic.Add(customerEntity);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            CustomerLogic customerLogic = new CustomerLogic();
            
            Customers customer = customerLogic.Get(id);
            CustomersViewModel model = new CustomersViewModel()
            {
                Id = customer.CustomerID,
                companyName = customer.CompanyName,
                contactName = customer.ContactName
            };
            ViewData["Action"] = "Update";
            return View("AddOrUpdate", model);
        }

        [HttpPost]
        public ActionResult Update(CustomersViewModel customerView)
        {
            CustomerLogic customerLogic = new CustomerLogic();
            Customers customerEntity = new Customers { CustomerID = customerView.Id, CompanyName = customerView.companyName, ContactName = customerView.contactName };
            customerLogic.Update(customerEntity);

            return RedirectToAction("Index");

        }




        public ActionResult Delete(string id)
        {
            CustomerLogic customerLogic = new CustomerLogic();
            customerLogic.Delete(id);
            return RedirectToAction("Index");

        }

    }
}