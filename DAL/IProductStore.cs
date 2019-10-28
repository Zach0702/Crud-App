using Dapper;
using Dapper101.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper101.DAL
{
    public interface IProductStore
    {
        IEnumerable<ProductsDALModel> SelectAllProducts();
        ProductsDALModel SelectProductByID(int productID);
        bool InsertNewProduct(ProductsDALModel dalModel);
        bool DeleteProduct(ProductsDALModel modelToDelete, int ID);
        bool UpdateProduct(ProductsDALModel modelToUpdate, int ID);
    }

    public class ProductStore : IProductStore
    {
        private readonly DataBase _config;
        public ProductStore(Dapper101Configuration config)
        {
            _config = config.DataBase;
        }

        public bool DeleteProduct(ProductsDALModel modelToDelete, int ID)
        {
            var sql = $@"DELETE FROM Products where ProductID = @ProductID";
            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var result = connection.Execute(sql, modelToDelete);

                //return true;
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool InsertNewProduct(ProductsDALModel dalModel)
        {
            var sql = $@"INSERT INTO Products (ProductName) Values(@{nameof(dalModel.ProductName)})";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var result = connection.Execute(sql, dalModel);

                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IEnumerable<ProductsDALModel> SelectAllProducts()
        {
            var sql = @"SELECT * FROM Products";

            using (var connection = new SqlConnection(_config.ConnectionString)) //Idisposable
            {
                var result = connection.Query<ProductsDALModel>(sql) ?? new List<ProductsDALModel>();
                return result;
            }
        }

        public ProductsDALModel SelectProductByID(int productID)
        {
            var sql = @"Select * From Products Where ProductID = @ProductID";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var result = connection.QueryFirstOrDefault<ProductsDALModel>(sql, new { ProductID = productID });

                return result;
            }
        }

        public bool UpdateProduct(ProductsDALModel modelToUpdate, int ID)
        {
            var sql = @"UPDATE Products SET ProductName = @ProductName,  
            QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock,
            UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @ReorderLevel, Discontinued = @Discontinued
            WHERE ProductID = @ProductID";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var result = connection.Execute(sql, modelToUpdate);

                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
/*, SupplierID = @SupplierID, CategoryID = @CategoryID,  
    QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock,
    UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @ReorderLevel, Discontinued = @Discontinued*/
