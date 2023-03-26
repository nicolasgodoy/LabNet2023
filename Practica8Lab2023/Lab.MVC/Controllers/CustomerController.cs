using Lab.Entities;
using Lab.Logic;
using Lab.MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab.Logic.Excepciones;
using System;

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

            {
                return View(listCustomer);
            }

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

            if (ModelState.IsValid)
            {
                try
                {
                    CustomerLogic customerLogic = new CustomerLogic();
                    Customers customerEntity = new Customers { CustomerID = customerView.Id, CompanyName = customerView.companyName, ContactName = customerView.contactName };
                    customerLogic.Add(customerEntity);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    //Falto logica para mostrar mjs en pantalla
                }
                
            }


            ViewData["Action"] = "Add";
            return View("AddOrUpdate", new CustomersViewModel());

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

            if (ModelState.IsValid)
            {
                try
                {
                    CustomerLogic customerLogic = new CustomerLogic();
                    Customers customerEntity = new Customers { CustomerID = customerView.Id, CompanyName = customerView.companyName, ContactName = customerView.contactName };
                    customerLogic.Update(customerEntity);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    //falto logica para mostrar msj en pantalla 
                }

            }
                
            ViewData["Action"] = "Update";
            return View("AddOrUpdate", new CustomersViewModel());
        }

        
        public ActionResult Delete(string id)
        {
            try
            {
                CustomerLogic customerLogic = new CustomerLogic();
                customerLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                //falto logica para mostrar msj en pantalla
            }

            return RedirectToAction("Index");


        }
    }
}