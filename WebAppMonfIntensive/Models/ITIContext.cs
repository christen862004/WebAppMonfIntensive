﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppMonfIntensive.Models
{
    public class ITIContext:IdentityDbContext<ApplicationUser>
    {
        //Class ==>Table
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ITIContext():base()
        {
            //call OnConfiguring
        }
        //option ==>appsetting
        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=.;Initial Catalog=M3M;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
        //DBContextOptions
        //open DBMS
        //Servre name
        //auth.
        //Database name
    }
}
