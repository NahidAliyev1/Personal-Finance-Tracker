using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Personal_Finance_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker.Contexts
{
    public class PersonalFinanceTrackerDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transactionn> Transactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }



        private readonly string _connection = @"Server=WIN-JSOABLM4UBB;Database=PersonalFinanceDb;TrustServerCertificate=True;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
