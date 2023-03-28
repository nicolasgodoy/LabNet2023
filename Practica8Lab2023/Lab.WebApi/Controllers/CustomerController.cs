using Lab.Entities;
using Lab.Logic;
using Lab.Logic.Excepciones;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Lab.WebApi.Controllers
{

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
                return Json(listaCustomer);
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


                return Json(customer);
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