using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper101.DAL;
using Dapper101.Models;
using Dapper101.NorthwindServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Dapper101.Controllers
{
    public class NorthwindController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public NorthwindController(ICustomerService customerService, IProductService productService)
        {
            _customerService = customerService;
            _productService = productService;
        }

        public IActionResult Customers()
        {
            var result = _customerService.GetCustomers();
            return View(result);
        }

        public IActionResult Home()
        {

            return View();

        }

        public IActionResult GetCustomer()
        {
            return View();
        }

        public IActionResult Customer(string firstName)
        {
           var result =  _customerService.GetCustomer(firstName);
            return View();
        }

        //public IActionResult AddCustomer()
        //{
        //    return View();
        //}

        //public IActionResult AddCustomerResult(AddCustomerViewModel model)
        //{
        //    var cusomer = _customerService.AddCustomer(model);
        //    return View();
        //}

        public IActionResult Products()
        {
            var productResults = _productService.GetAllProducts();
            return View(productResults);
        }

        public IActionResult ProductDetails(int ID)
        {
            var productDetails = _productService.GetProductDetails(ID);
           
            return View(productDetails);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult AddProductResult(AddProductViewModel userModel)
        {
            var productViewModel = _productService.AddProduct(userModel);

            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            else
            {
                return View("Products", productViewModel);
            }
        }

        public IActionResult SelectDeleteProduct()
        {
            var productList = _productService.GetAllProducts();
            return View(productList);
        }

        public IActionResult DeletionResult(int ID)
        {
            var productViewModel = _productService.DeleteProduct(ID);
            return View("Products", productViewModel);
        }

        public IActionResult SelectUpdateProduct()
        {
            var productList = _productService.GetAllProducts();

            return View(productList);
        }

        public IActionResult UpdateProductInfo(int ID)
        {
            var oldProduct = _productService.GetProduct(ID);
            var updateProduct = new UpdateProductViewModel();
            updateProduct.ProductID = ID;
            updateProduct.ProductName = oldProduct.ProductName;
            //updateProduct.CategoryID = oldProduct.CategoryID;
            updateProduct.QuantityPerUnit = oldProduct.QuantityPerUnit;
            updateProduct.UnitPrice = oldProduct.UnitPrice;
            updateProduct.UnitsOnOrder = oldProduct.UnitsOnOrder;
            updateProduct.ReorderLevel = oldProduct.ReorderLevel;
            updateProduct.Discontinued = oldProduct.Discontinued;
            return View(updateProduct);

        }

        public IActionResult UpdateResults(UpdateProductViewModel userUpdates)
        {
            var results = _productService.ShowUpdatedProduct(userUpdates.ProductID, userUpdates);
            return View("ProductDetails", results);
        }
    }
}