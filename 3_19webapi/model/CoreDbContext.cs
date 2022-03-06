using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace _3_19webapi.model
{
    public class CoreDbContext : DbContext
    {
        public DbSet<Person> person{get;set; } //创建实体类添加Context中
        public DbSet<User> user { get; set; }
        public CoreDbContext(DbContextOptions<CoreDbContext> options):base(options)
        {

        }
    }
}
