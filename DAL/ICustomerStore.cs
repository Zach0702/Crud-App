using Dapper;
using Dapper101.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper101.DAL
{
    public interface ICustomerStore
    {
        IEnumerable<CustomerDALModel> SelectAllCustomers();
        CustomerDALModel SelectCustomerByFirstName(string firstName);
        bool InsertNewCustomer(CustomerDALModel dalModel);
    }

    public class CustomerStore:ICustomerStore
    {
        private readonly DataBase _config;

        public CustomerStore(Dapper101Configuration config)
        {
            _config = config.DataBase;
        }

        public bool InsertNewCustomer(CustomerDALModel dalModel)  //Give parameters to sql query to stop sql injection
        {
            var sql = @"Insert INTO Customers (ContactName, City, ContactTitle, CustomerID, CompanyName)
            Values(@ContactName,@City,@ContactTitle, @CustomerID, @CompanyName)";
            using (var connection = new SqlConnection(_config.ConnectionString)) //Idisposable
            {
                var result = connection.Execute(sql, dalModel);
                return true;
            }
        }

        public IEnumerable<CustomerDALModel> SelectAllCustomers()
        {
            var sql = @"SELECT * FROM Customers";

            using (var connection = new SqlConnection(_config.ConnectionString)) //Idisposable
            {
                var result = connection.Query<CustomerDALModel>(sql)  ?? new List<CustomerDALModel>();
                return result;
            }
        }

        public CustomerDALModel SelectCustomerByFirstName(string firstName)
        {
            var sql = @"SELECT* FROM Customers WHERE ContactName LIKE @ContactName";
            using (var connection = new SqlConnection(_config.ConnectionString)) //You are using because sql connection implents Idisposable 
            {                                                                    //closes connection to sql database
                var result = connection.QueryFirstOrDefault<CustomerDALModel>(sql, new { ContactName = $"%{firstName}%" });
                return result;
            }
        }
    }
}
