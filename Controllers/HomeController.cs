using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper101.Models;

namespace Dapper101.Controllers
{
    public class HomeController : Controller
    {
        private readonly Dapper101Configuration _config;
        public HomeController(Dapper101Configuration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            var connectionString = _config.DataBase.ConnectionString;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
