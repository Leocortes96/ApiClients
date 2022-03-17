using ApiClients.Controllers;
using ApiClients.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest
{
    [TestClass]
    public class ControllerTests: BaseTets
    {
        [TestMethod]
        public async Task GetAllCustomers()
        {
            var nameBD = Guid.NewGuid().ToString();
            var context = BuildContext(nameBD);

            context.customers.Add(new customers()
            {
                name = "Lorena",
                last_name = "Rodrigez",
                id_document_type = 1,
                document_number = "1053847584",
                business_name = "Azure",
                id_providers = 2,
                sales_last_year = 8000000
            });
            context.customers.Add(new customers()
            {
                name = "Leonardo",
                last_name = "Naranjo",
                id_document_type = 1,
                document_number = "1053854446",
                business_name = "Azure",
                id_providers = 2,
                sales_last_year = 8000000
            });

            await context.SaveChangesAsync();

            var context2 = BuildContext(nameBD);

            var controller = new customersController(context2);
            var res = await controller.Getcustomers();

            var customer = res.Value;
            Assert.AreEqual(2, customer.Count());
        }

        [TestMethod]
        public async Task GetCustomerWhithIdNotFound()
        {
            var nameBD = Guid.NewGuid().ToString();
            var context = BuildContext(nameBD);

            var controller = new customersController(context);
            var response = await controller.Getcustomers(1);

            var result = response.Result as StatusCodeResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public async Task GetCustomerWhithIdCorrect()
        {
            var nameBD = Guid.NewGuid().ToString();
            var context = BuildContext(nameBD);

            context.customers.Add(new customers()
            {
                name = "Lorena",
                last_name = "Rodrigez",
                id_document_type = 1,
                document_number = "1053847584",
                business_name = "Azure",
                id_providers = 2,
                sales_last_year = 8000000
            });
            context.customers.Add(new customers()
            {
                name = "Leonardo",
                last_name = "Naranjo",
                id_document_type = 1,
                document_number = "1053854446",
                business_name = "Azure",
                id_providers = 2,
                sales_last_year = 8000000
            });

            await context.SaveChangesAsync();

            var context2 = BuildContext(nameBD);
            var controller = new customersController(context2);
            var id = 1;
            var response = await controller.Getcustomers(id);
            var result = response.Value;

            Assert.AreEqual(id, result.id);
        }

        [TestMethod]
        public async Task CreateCustomer()
        {
            var nameBD = Guid.NewGuid().ToString();
            var context = BuildContext(nameBD);

            var newCustomer = new customers()
            {
                name = "Lorena",
                last_name = "Rodrigez",
                id_document_type = 1,
                document_number = "1053847584",
                business_name = "Azure",
                id_providers = 2,
                sales_last_year = 8000000
            };

            var controller = new customersController(context);
            var response = await controller.Postcustomers(newCustomer);

            Assert.IsNotNull(response);

            var context2 = BuildContext(nameBD);
            var cantidad = await context2.customers.CountAsync();

            Assert.AreEqual(1, cantidad);
        }

        [TestMethod]
        public async Task PutCustomer()
        {
            var nameBD = Guid.NewGuid().ToString();
            var context = BuildContext(nameBD);

            context.customers.Add(new customers()
            {
                id = 1,
                name = "Leonardo",
                last_name = "Naranjo",
                id_document_type = 1,
                document_number = "1053854446",
                business_name = "Azure",
                id_providers = 2,
                sales_last_year = 8000000
            });
            await context.SaveChangesAsync();

            var context2 = BuildContext(nameBD);
            var controller = new customersController(context2);

            var createDTO = new customers()
            {
                id = 1,
                name = "Camilo",
                last_name = "Naranjo",
                id_document_type = 1,
                document_number = "1053854446",
                business_name = "Azure",
                id_providers = 2,
                sales_last_year = 8000000
            };

            var id = 1;
            var response = await controller.Putcustomers(id, createDTO);
            var result = response as StatusCodeResult;

            Assert.AreEqual(204, result.StatusCode);

            var context3 = BuildContext(nameBD);
            var exist = await context3.customers.AnyAsync(x => x.name == "Camilo");

            Assert.IsTrue(exist);
        }

        [TestMethod]
        public async Task DeletedCustomerIdNotFound()
        {
            var nameBD = Guid.NewGuid().ToString();
            var context = BuildContext(nameBD);

            var controller = new customersController(context);
            var response = await controller.Deletecustomers(1);

            var result = response as StatusCodeResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public async Task DeletedCustomer()
        {
            var nameBD = Guid.NewGuid().ToString();
            var context = BuildContext(nameBD);

            context.customers.Add(new customers()
            {
                id = 1,
                name = "Leonardo",
                last_name = "Naranjo",
                id_document_type = 1,
                document_number = "1053854446",
                business_name = "Azure",
                id_providers = 2,
                sales_last_year = 8000000
            });

            await context.SaveChangesAsync();

            var context2 = BuildContext(nameBD);
            var controller = new customersController(context2);
            var response = await controller.Deletecustomers(1);

            var result = response as StatusCodeResult;

            Assert.AreEqual(204, result.StatusCode);

            var context3 = BuildContext(nameBD);
            var exist = await context3.customers.AnyAsync();
            Assert.IsFalse(exist);
        }
    }
}
