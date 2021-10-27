using Microsoft.EntityFrameworkCore;
using Pension.Domain.Models;
using System;

namespace Persion.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options){ }

        public DbSet<UserModel> UserModels { get; set; }
    }
}
