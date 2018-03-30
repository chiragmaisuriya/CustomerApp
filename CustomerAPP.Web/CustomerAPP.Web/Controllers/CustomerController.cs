using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CustomerAPP.Data;
using CustomerAPP.Model;

namespace CustomerAPP.Web.Controllers
{
    [BasicAuthentication]
    public class CustomerController : ApiControllerBase
    {
        public CustomerController(ICustomerAPPUow uow)
        {
            Uow = uow;
        }

        [HttpGet]
        [ActionName("GetAllCustomers")]
      
        public IEnumerable<Customer> GetAllCustomers()
        {
            return  Uow.CustomersRepository.GetAll().OrderBy(c => c.FirstName);
        }

       
        [HttpGet]
        [ActionName("GetCustomerById")]
        public Customer GetCustomerById(int id)
        {
            var customer =  Uow.CustomersRepository.GetById(id);
            if (customer != null) return customer;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        [HttpPost]
        [ActionName("CreateNewCustomer")]
        public HttpResponseMessage CreateNewCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                Uow.CustomersRepository.Add(customer);
                Uow.Commit();

                var response = Request.CreateResponse(HttpStatusCode.Created, customer);

                // Compose location header that tells how to get this session

                response.Headers.Location =
                    new Uri(Url.Link(WebApiConfig.ControllerAndId, new {id = customer.Id}));

                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Update an existing customer
        [HttpPut]
        [ActionName("UpdateCustomer")]
        public HttpResponseMessage UpdateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {

                Uow.CustomersRepository.Update(customer);
                Uow.Commit();
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE 
        public HttpResponseMessage Delete(int id)
        {
            Uow.CustomersRepository.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}

