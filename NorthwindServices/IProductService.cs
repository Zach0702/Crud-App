using Dapper101.DAL;
using Dapper101.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper101.NorthwindServices
{
    public interface IProductService
    {
        ProductsViewModel GetAllProducts();
        ProductDetailsViewModel GetProductDetails(int id);
        Products GetProduct(int id);
        ProductsViewModel AddProduct(AddProductViewModel userEnteredModel);
        ProductsViewModel DeleteProduct(int ID);
        ProductDetailsViewModel ShowUpdatedProduct(int id, UpdateProductViewModel userModel);
    }

    public class ProductService : IProductService
    {
        private readonly IProductStore _productStore;

        public ProductService(IProductStore productStore)
        {
            _productStore = productStore;
        }

        public ProductsViewModel AddProduct(AddProductViewModel userEnteredModel)
        {
            var dalModel = new ProductsDALModel();
            dalModel.ProductName = userEnteredModel.ProductName;
             _productStore.InsertNewProduct(dalModel);
            var dalProducts = _productStore.SelectAllProducts();

            return MapProductViewModel(dalProducts);
        }

        public ProductsViewModel GetAllProducts()
        {
            var dalProducts = _productStore.SelectAllProducts();

            return MapProductViewModel(dalProducts);
            
        }

        public ProductDetailsViewModel GetProductDetails(int id)
        {
            var dalProduct = _productStore.SelectProductByID(id);

            var productDetails = new ProductDetailsViewModel();
            productDetails.ProductName = dalProduct.ProductName;
            productDetails.SupplierID = dalProduct.SupplierID;
            productDetails.CategoryID = dalProduct.CategoryID;
            productDetails.QuantityPerUnit = dalProduct.QuantityPerUnit;
            productDetails.UnitPrice = dalProduct.UnitPrice;
            productDetails.UnitsInStock = dalProduct.UnitsInStock;
            productDetails.UnitsOnOrder = dalProduct.UnitsOnOrder;
            productDetails.ReorderLevel = dalProduct.ReorderLevel;
            productDetails.Discontinued = dalProduct.Discontinued;

            return productDetails;
        }

        public ProductsViewModel DeleteProduct (int ID)
        {
            var dalProduct = _productStore.SelectProductByID(ID);
            var result = _productStore.DeleteProduct(dalProduct, ID);
            var dalProducts = _productStore.SelectAllProducts();

            return MapProductViewModel(dalProducts);
        }
        public ProductDetailsViewModel ShowUpdatedProduct(int id, UpdateProductViewModel userModel)
        {
            var dalModel = new ProductsDALModel();
            //dalModel.ProductID = userModel.ProductID;
            dalModel.ProductID = userModel.ProductID;
            dalModel.ProductName = userModel.ProductName;
            //dalModel.SupplierID = userModel.SupplierID;
            //dalModel.CategoryID = userModel.CategoryID;
            dalModel.QuantityPerUnit = userModel.QuantityPerUnit;
            dalModel.UnitPrice = userModel.UnitPrice;
            dalModel.UnitsInStock = userModel.UnitsInStock;
            dalModel.UnitsOnOrder = userModel.UnitsOnOrder;
            dalModel.ReorderLevel = userModel.ReorderLevel;
            dalModel.Discontinued = userModel.Discontinued;
            _productStore.UpdateProduct(dalModel, id);

            var productDetails = new ProductDetailsViewModel();
            productDetails.ProductName = dalModel.ProductName;
            productDetails.SupplierID = dalModel.SupplierID;
            productDetails.CategoryID = dalModel.CategoryID;
            productDetails.QuantityPerUnit = dalModel.QuantityPerUnit;
            productDetails.UnitPrice = dalModel.UnitPrice;
            productDetails.UnitsInStock = dalModel.UnitsInStock;
            productDetails.UnitsOnOrder = dalModel.UnitsOnOrder;
            productDetails.ReorderLevel = dalModel.ReorderLevel;
            productDetails.Discontinued = dalModel.Discontinued;

            return productDetails;
        }

        
        private ProductsViewModel MapProductViewModel (IEnumerable<ProductsDALModel> dalProducts)
        {
            var products = new List<Products>();

            foreach (var dalProduct in dalProducts)
            {
                var product = new Products();
                product.ProductName = dalProduct.ProductName;
                product.ProductID = dalProduct.ProductID;
                products.Add(product);
            }

            var productViewModel = new ProductsViewModel();
            productViewModel.ListOfProducts = products;
            return productViewModel;
        }

        public Products GetProduct(int id)
        {
            var dalProduct = _productStore.SelectProductByID(id);
            var productModel = new Products();
            productModel.ProductID = dalProduct.ProductID;
            productModel.ProductName = dalProduct.ProductName;
            productModel.CategoryID = dalProduct.CategoryID;
            productModel.QuantityPerUnit = dalProduct.QuantityPerUnit;
            productModel.UnitPrice = dalProduct.UnitPrice;
            productModel.UnitsOnOrder = dalProduct.UnitsOnOrder;
            productModel.ReorderLevel = dalProduct.ReorderLevel;
            productModel.Discontinued = dalProduct.Discontinued;

            return productModel;
        }
    }
}

/*public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }*/
