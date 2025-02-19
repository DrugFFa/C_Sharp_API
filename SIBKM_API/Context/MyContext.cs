﻿using Microsoft.EntityFrameworkCore;
using SIBKM_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKM_API.Context
{
    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions<MyContext>dbContext) : base(dbContext)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
