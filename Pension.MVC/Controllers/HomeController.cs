using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pension.Core.Interfaces;
using Pension.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pension.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _service;

        public HomeController(ILogger<HomeController> logger, IUserService service)
        {
            _logger = logger;
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetUsersAsync();
            return View(result);
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
