using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pension.Core.Interfaces;
using Pension.Domain.Models;
using Persion.Data;

namespace Pension.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDb _config;
        private readonly IUserService _service;

        public UserController(AppDb context, IUserService service)
        {
            _config = context;
            this._service = service;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetUsersAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _config.UserModels.FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Gender,Brithday,MaritalStatus,PINFLNumber,Region,District,Mahalla,PostalAddress,PhysicalAddress,PhoneContact,EmailAddress,ForTwoYears,ForFourteenYears,Support,Signature,Date,OfficialName,OfficialDisignation,OfficialSignatrue,OfficialDate")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateUserAsync(userModel);
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _config.UserModels.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Gender,Brithday,MaritalStatus,PINFLNumber,Region,District,Mahalla,PostalAddress,PhysicalAddress,PhoneContact,EmailAddress,ForTwoYears,ForFourteenYears,Support,Signature,Date,OfficialName,OfficialDisignation,OfficialSignatrue,OfficialDate")] UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateUserAsync(id, userModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _config.UserModels.FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _service.DeleteUserAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(int id)
        {
            return _config.UserModels.Any(e => e.Id == id);
        }
    }
}
