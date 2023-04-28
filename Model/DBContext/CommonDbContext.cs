using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DBContext
{
    public class CommonDbContext : DbContext
    {
        public CommonDbContext(DbContextOptions<CommonDbContext> options): base(options)
        {
            
        }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Property> Property { get; set; }
    }
}
