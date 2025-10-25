using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp_Dependency_Injection.Models;

namespace ConsoleApp_Dependency_Injection.Services
{
    public interface IProductService
    {
        //create
        void AddProduct();
        //Read all
        List<Product> GetAllProducts();
        //Read by id
        Product GetProductById(int id);
        //Read by Category
        List<Product> GetProductsByCategory(string category);
        //Update
        void UpdateProduct(Product product);
        //Delete
        void DeleteProduct(int id);

        //display
        void Display(Product product);
    }
}

