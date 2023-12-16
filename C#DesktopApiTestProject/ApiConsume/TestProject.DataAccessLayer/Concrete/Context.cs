using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.EntityLayer.Concrete;

namespace TestProject.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-1P8OKHA;initial catalog = TestApidb; integrated security=true");
           
        }
        public DbSet<Staff> Staffs { get; set; }
    }
}
