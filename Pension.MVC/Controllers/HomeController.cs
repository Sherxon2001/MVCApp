using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pension.Core.Interfaces;
using Pension.Domain.Models;
using Pension.MVC.Models;
using Persion.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pension.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _service;
        private readonly AppDb _config;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDb config, IUserService service, ILogger<HomeController> logger)
        {
            _service = service;
            _config = config;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetUsers()
        {
            IEnumerable<UserModel> model = await _service.GetUsersAsync();
            return Ok(model);
        }

        public async Task<IActionResult> GetUser()
        {
            UserModel model = await _service.GetUserAsync(2);
            return Ok(model);
        }
        public IActionResult UpdateUser()
        {
            return View();
        }
        public IActionResult DeleteUser()
        {
            return View();
        }

        public async Task<IActionResult> CreateUser(UserModel model)
        {
            var result = await _service.CreateUserAsync(model);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
