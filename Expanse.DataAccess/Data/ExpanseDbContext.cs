using Expanse.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.DataAccess.Data
{
    public class ExpanseDbContext : DbContext
    {
        public ExpanseDbContext(DbContextOptions<ExpanseDbContext> options) : base(options)
        {
            
        }

        public DbSet<CryptoCurrency> CryptoCurrencies { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);


        }
    }
}
