using Microsoft.AspNetCore.Mvc;
using Pension.Api.Event;
using Pension.Core.Interfaces;
using Pension.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pension.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserService _config;

        public HomeController(IUserService config)
        {
            _config = config;
        }

        // GET: api/<HomeController>
        [HttpGet]
        public async Task<IActionResult> GetUser(string str)
        {
            if(str.Length > 0)
            {
                try
                {
                    var item = await _config.GetUserAsync(int.Parse(str));
                    if (item is null)
                    {
                        return BadRequest(new ResTemplate
                        {
                            Response = nameof(ResponseType.NotFound),
                            Date = null
                        });
                    }

                    return BadRequest(new ResTemplate
                    {
                        Response = nameof(ResponseType.Successfully),
                        Date = item
                    });
                }
                catch
                {
                    var item = await _config.GetUserAsync(str);
                    if (item is null)
                    {
                        return BadRequest(new ResTemplate
                        {
                            Response = nameof(ResponseType.NotFound),
                            Date = null
                        });
                    }

                    return BadRequest(new ResTemplate
                    {
                        Response = nameof(ResponseType.Successfully),
                        Date = item
                    });
                }
            }
            return BadRequest(new ResTemplate
            {
                Response = nameof(ResponseType.Error),
                Date = null
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _config.GetUsersAsync();
            if (result is null)
            {
                return BadRequest(new ResTemplate 
                {
                    Response = nameof(ResponseType.NotFound),
                    Date = null
                });
            }
            
            return BadRequest(new ResTemplate
            {
                Response = nameof(ResponseType.Successfully),
                Date = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel model)
        {
            var result = await _config.CreateUserAsync(model);
            return BadRequest(new ResTemplate
            {
                Response = nameof(ResponseType.Successfully),
                Date = result
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id, UserModel model)
        {
            var result = await _config.UpdateUserAsync(id, model);
            if (result is null)
            {
                return BadRequest(new ResTemplate
                {
                    Response = nameof(ResponseType.NotFound),
                    Date = null
                });
            }

            return BadRequest(new ResTemplate
            {
                Response = nameof(ResponseType.Successfully),
                Date = result
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var result = await _config.DeleteUserAsync(id);
            if (result is false)
            {
                return BadRequest(new ResTemplate
                {
                    Response = nameof(ResponseType.NotFound),
                    Date = null
                });
            }

            return BadRequest(new ResTemplate
            {
                Response = nameof(ResponseType.Successfully),
                Date = nameof(ResponseType.Delete)
            });
        }
    }
}
