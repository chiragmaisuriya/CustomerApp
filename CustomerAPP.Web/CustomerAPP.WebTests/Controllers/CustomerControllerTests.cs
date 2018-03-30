using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using CustomerAPP.Data.Fakes;
using CustomerAPP.Model;

namespace CustomerAPP.Web.Controllers.Tests
{
    [TestClass()]
    public class CustomerControllerTests
    {

        private StubICustomerAPPUow stubICustomerAppUow;
        private bool getAllCalled;
        private bool getByIdCalled;
        private bool addCalled;
        private bool deleteByIdCalled;
        private bool updateGotCalled;
        private bool commitGotCalle;

        [TestInitialize()]
        public void Initialize()
        {
            getAllCalled = false;
            getByIdCalled = false;
            addCalled = false;
            deleteByIdCalled = false;
            updateGotCalled = false;
            commitGotCalle = false;
            
            stubICustomerAppUow = new StubICustomerAPPUow()
            {
                CustomersRepositoryGet = () => new StubIRepository<Customer>()
                {
                    GetAll = () =>
                    {
                        getAllCalled = true;
                        return new EnumerableQuery<Customer>(new List<Customer>()
                        { new Customer() { Address = "test", BirthDay = DateTime.Today, FirstName = "Test", LastName = "test" } });
                    },
                    GetByIdInt32 = (a) =>
                    {
                        getByIdCalled = true;
                        return new Customer() { Id =1, Address = "test", BirthDay = DateTime.Today, FirstName = "Test", LastName = "test" };
                    },
                    AddT0 = (a) => { addCalled = true; },
                    DeleteInt32 = (a) => { deleteByIdCalled = true; },
                    DeleteT0 = (a) => { deleteByIdCalled = true; },
                    UpdateT0 = (a) => { updateGotCalled = true; }

                },
                Commit = () => { }
            };
        }
        [TestMethod()]
        public void CustomerControllerTest()
        {


        }

        [TestMethod()]
        public void GetAllCustomers_Test()
        {
            //Arrange
            CustomerController customerController = new CustomerController(stubICustomerAppUow);

            //Act
            var result = customerController.GetAllCustomers();

            //Assert
            Assert.IsInstanceOfType(result , typeof(IEnumerable<Customer>));
            Assert.IsTrue(getAllCalled);
        }

        [TestMethod()]
        public void GetCustomerById_Test()
        {
            //Arrange
            CustomerController customerController = new CustomerController(stubICustomerAppUow);

            //Act
            var result = customerController.GetCustomerById(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(Customer));
            Assert.IsTrue(getByIdCalled);
        }

       
    }
}