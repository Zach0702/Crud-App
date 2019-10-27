using Dapper101.DAL;
using Dapper101.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper101.NorthwindServices
{
    public interface ICustomerService
    {
        CustomersViewModel GetCustomers();
        Customer GetCustomer(string firstName);
        //CustomersViewModel AddCustomer(AddCustomerViewModel model);
        
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerStore _customerStore;

        public CustomerService(ICustomerStore customerStore)
        {
            _customerStore = customerStore;
        }

        //public CustomersViewModel AddCustomer(AddCustomerViewModel model)
        //{
        //    var dalModel = MapToCustomerDalModel(model);
        //    var isInserted = _customerStore.InsertNewCustomer(dalModel);
        //    var customers = _customerStore.SelectAllCustomers();
        //}

        public Customer GetCustomer(string firstName)
        {
            var dalCustomer = _customerStore.SelectCustomerByFirstName(firstName);
            

            return new Customer();
        }

        public CustomersViewModel GetCustomers()
        {
            var dalCustomers = _customerStore.SelectAllCustomers();

            var customers = new List<Customer>();

            foreach (var dalCustomer in dalCustomers)
            {
                var customer = new Customer();
                customer.Address = dalCustomer.Address;
                customer.City = dalCustomer.City;
                customer.CompanyName = dalCustomer.CompanyName;
                customer.ContactName = dalCustomer.ContactName;
                customer.Country = dalCustomer.Country;
                customer.ID = dalCustomer.CustomerID;
                customer.Phone = dalCustomer.Phone;
                customer.PostalCode = dalCustomer.PostalCode;
                customer.Region = dalCustomer.Region;

                customers.Add(customer);
            }

            var customerViewModel = new CustomersViewModel();
            customerViewModel.Customers = customers;

            return customerViewModel;
        }

        public bool InsertNewCustomer(CustomerDALModel dalModel)
        {
            throw new NotImplementedException();
        }

        //private CustomersViewModel MappingCustomerModel()
        //{

        //}

        private CustomerDALModel MapToCustomerDalModel(AddCustomerViewModel src)
        {
            var dalCustomer = new CustomerDALModel();
            dalCustomer.ContactName = src.Name;
            dalCustomer.City = src.City;
            dalCustomer.ContactTitle = src.Title;
            dalCustomer.CustomerID = Guid.NewGuid().ToString().Substring(0,5);
            dalCustomer.ContactName = "Grand Circus";
            return dalCustomer;
        }
    }
}
