#pragma checksum "C:\Users\olivi\source\repos\Dapper101\Views\Northwind\ProductDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20260729ec72bfb13e2e000cd5fdaf4df99c4e6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Northwind_ProductDetails), @"mvc.1.0.view", @"/Views/Northwind/ProductDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Northwind/ProductDetails.cshtml", typeof(AspNetCore.Views_Northwind_ProductDetails))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\olivi\source\repos\Dapper101\Views\_ViewImports.cshtml"
using Dapper101;

#line default
#line hidden
#line 2 "C:\Users\olivi\source\repos\Dapper101\Views\_ViewImports.cshtml"
using Dapper101.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20260729ec72bfb13e2e000cd5fdaf4df99c4e6f", @"/Views/Northwind/ProductDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0ad1ae3ecd52292f3f562cabc186fb434d3753d", @"/Views/_ViewImports.cshtml")]
    public class Views_Northwind_ProductDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dapper101.Models.ProductDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\olivi\source\repos\Dapper101\Views\Northwind\ProductDetails.cshtml"
  
    ViewData["Title"] = "ProductDetails";

#line default
#line hidden
            BeginContext(99, 37, true);
            WriteLiteral("\r\n<h1>Product Details Page</h1>\r\n<h1>");
            EndContext();
            BeginContext(137, 17, false);
#line 7 "C:\Users\olivi\source\repos\Dapper101\Views\Northwind\ProductDetails.cshtml"
Write(Model.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(154, 474, true);
            WriteLiteral(@"</h1>

<div>
    <table>
        <thead>
            <tr>
                <th>Supplier ID</th>
                <th>Category ID</th>
                <th>Quantity Per Unit</th>
                <th>Unit Price</th>
                <th>Units In Stock</th>
                <th>Units On Order</th>
                <th>ReOrder Level</th>
                <th>Discontinued</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>");
            EndContext();
            BeginContext(629, 16, false);
#line 25 "C:\Users\olivi\source\repos\Dapper101\Views\Northwind\ProductDetails.cshtml"
               Write(Model.SupplierID);

#line default
#line hidden
            EndContext();
            BeginContext(645, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(673, 16, false);
#line 26 "C:\Users\olivi\source\repos\Dapper101\Views\Northwind\ProductDetails.cshtml"
               Write(Model.CategoryID);

#line default
#line hidden
            EndContext();
            BeginContext(689, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(717, 21, false);
#line 27 "C:\Users\olivi\source\repos\Dapper101\Views\Northwind\ProductDetails.cshtml"
               Write(Model.QuantityPerUnit);

#line default
#line hidden
            EndContext();
            BeginContext(738, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(766, 15, false);
#line 28 "C:\Users\olivi\source\repos\Dapper101\Views\Northwind\ProductDetails.cshtml"
               Write(Model.UnitPrice);

#line default
#line hidden
            EndContext();
            BeginContext(781, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(809, 18, false);
#line 29 "C:\Users\olivi\source\repos\Dapper101\Views\Northwind\ProductDetails.cshtml"
               Write(Model.UnitsInStock);

#line default
#line hidden
            EndContext();
            BeginContext(827, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(855, 18, false);
#line 30 "C:\Users\olivi\source\repos\Dapper101\Views\Northwind\ProductDetails.cshtml"
               Write(Model.UnitsOnOrder);

#line default
#line hidden
            EndContext();
            BeginContext(873, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(901, 18, false);
#line 31 "C:\Users\olivi\source\repos\Dapper101\Views\Northwind\ProductDetails.cshtml"
               Write(Model.ReorderLevel);

#line default
#line hidden
            EndContext();
            BeginContext(919, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(947, 18, false);
#line 32 "C:\Users\olivi\source\repos\Dapper101\Views\Northwind\ProductDetails.cshtml"
               Write(Model.Discontinued);

#line default
#line hidden
            EndContext();
            BeginContext(965, 74, true);
            WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dapper101.Models.ProductDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
