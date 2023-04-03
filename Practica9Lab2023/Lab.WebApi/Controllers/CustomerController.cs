using Lab.Entities;
using Lab.Logic;
using Lab.Logic.Excepciones;
using Lab.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Lab.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET,POST,PUT,DELETE,OPTIONS")]
    public class CustomerController : ApiController
    {
        // GET: Customer
        // GET api/values
        
        public IHttpActionResult Get()
        {
            try
            {
                CustomerLogic customerLogic = new CustomerLogic();
                List<Customers> listaCustomer = customerLogic.GetAll();
                List<CustomerDto> listCustomerDto = new List<CustomerDto>();

                foreach (Customers item in listaCustomer)
                {
                    CustomerDto customerdto = new CustomerDto();
                    customerdto.CustomerID = item.CustomerID;
                    customerdto.CompanyName = item.CompanyName;
                    customerdto.ContactName = item.ContactName;
                    listCustomerDto.Add(customerdto);
                }
                return Json(listCustomerDto);

            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
           
        }

        // GET api/Customers/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                CustomerLogic customerLogic = new CustomerLogic();
                Customers customer = customerLogic.Get(id);

                if(customer == null)
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }

                CustomerDto customerdto = new CustomerDto();
                customerdto.CustomerID = customer.CustomerID;
                customerdto.CompanyName = customer.CompanyName;
                customerdto.ContactName = customer.ContactName;
                


                return Json(customerdto);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            
        }

        // POST api/values
        public IHttpActionResult Post([FromBody] Customers newCustomer)
        {
            try
            {
                CustomerLogic customerLogic = new CustomerLogic();
                customerLogic.Add(newCustomer);
                return StatusCode(HttpStatusCode.Created);

            }
            catch (EntityFoundException ex)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            catch (FieldNullException ex)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            catch (FieldLenghtInvalidException ex)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            { 
                return StatusCode(HttpStatusCode.InternalServerError);
            }
           
        }

        // PUT api/values/5
        public IHttpActionResult Put([FromBody]  Customers customer)
        {
            try
            {
                CustomerLogic customerLogic = new CustomerLogic();
                customerLogic.Update(customer);
                return StatusCode(HttpStatusCode.OK);
            }
            catch (FieldNullException ex)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            catch (FieldLenghtInvalidException ex)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                CustomerLogic customerLogic = new CustomerLogic();
                customerLogic.Delete(id);
                return StatusCode(HttpStatusCode.OK);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            
        }

        


    }
}