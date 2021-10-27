using Microsoft.EntityFrameworkCore;
using Pension.Core.Interfaces;
using Pension.Domain.Models;
using Persion.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pension.Core.Services
{
    public class UserService : IUserService
    {
        private readonly AppDb _config;

        public UserService(AppDb config)
        {
            _config = config;
        }
        public async Task<UserModel> CreateUserAsync(UserModel model)
        {
            await _config.AddAsync(model);
            await _config.SaveChangesAsync();
            return model;
        }
         
        public async Task<bool> DeleteUserAsync(int id)
        {
            var model = await _config.UserModels.FirstOrDefaultAsync(p => p.Id == id);
            if(model is null)
            {
                return false;
            }

            _config.Remove(model);
            await _config.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UserModel>> GetUserAsync(string str)
        {
            var result = await _config.UserModels.Where(p => p.FullName.Contains($"{str}")).ToListAsync();
            if (result is null)
            {
                return null;
            }
            return result;
        }

        public async Task<UserModel> GetUserAsync(int id)
        {
            var result = await _config.UserModels.FirstOrDefaultAsync(p => p.Id == id);
            if (result is null)
            {
                return null;
            }
            return result;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var result = await _config.UserModels.ToListAsync(); 
            return result;
        }

        public async Task<UserModel> UpdateUserAsync(int id, UserModel model)
        {
            var result = await _config.UserModels.FirstOrDefaultAsync(p => p.Id == id);
            if (result is null)
            {
                return null;
            }

            result.FullName = model.FullName;
            result.Gender = model.Gender;
            result.Brithday = model.Brithday;
            result.MaritalStatus = model.MaritalStatus;
            result.PINFLNumber = model.PINFLNumber;
            result.Region = model.Region;
            result.District = model.District;
            result.Mahalla = model.Mahalla;
            result.PostalAddress = model.Gender;
            result.PhysicalAddress = model.PhysicalAddress;
            result.PhoneContact = model.PhoneContact;
            result.EmailAddress = model.EmailAddress;
            result.ForTwoYears = model.ForTwoYears;
            result.ForFourteenYears = model.ForFourteenYears;
            result.Support = model.Support;
            result.Signature = model.Signature;
            result.Date = model.Date;
            result.OfficialName = model.OfficialName;
            result.OfficialDisignation = model.OfficialDisignation;
            result.OfficialSignatrue = model.OfficialSignatrue;
            result.OfficialDate = model.OfficialDate;
            
            await _config.SaveChangesAsync();
            return result;
        }
    }
}
