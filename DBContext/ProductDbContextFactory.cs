using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Dependency_Injection
{
    public class ProductDbContextFactory : IDesignTimeDbContextFactory<ProductDbContext>
    {
        public ProductDbContext CreateDbContext(string[] args)
        {
            var optionsbuilder = new DbContextOptionsBuilder<ProductDbContext>();
            optionsbuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Product_DB;Trusted_Connection=True;");
            return new ProductDbContext(optionsbuilder.Options);
        }
    }
    
}
