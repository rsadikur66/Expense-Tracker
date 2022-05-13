﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expense_Tracker.Models;

namespace Expense_Tracker.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Expence> Expenses { get; set; }
        public DbSet<ExpenceCategory> Categories { get; set; }
        
    }
}
