using Microsoft.EntityFrameworkCore;
using Pension.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pension.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options){ }

        public DbSet<UserModel> UserModels { get; set; }
    }
}
