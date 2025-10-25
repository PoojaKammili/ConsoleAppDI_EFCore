using ConsoleApp_Dependency_Injection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Dependency_Injection.Services
{
    public class ProductService:IProductService
    {
        private readonly ProductDbContext _context;
      
        public ProductService(ProductDbContext context)
        {
            _context = context;
           
        }
        //create
        public void AddProduct()
        {
            Product product = new Product();

            Console.Write("Enter Product Name: ");
            product.Name = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            product.Price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Product Quantity: ");
            product.Quantity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product Category: ");
            product.Category = Console.ReadLine();

            Console.Write("Is the product available? (true/false): ");
            product.IsAvailable = Convert.ToBoolean(Console.ReadLine());

            product.CreatedDate = DateTime.Now;

            _context.Products.Add(product);
            _context.SaveChanges();

            Console.WriteLine($"\n✅ Product '{product.Name}' added successfully!");
        }

        //Read all
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        //Read by id
        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.productId == id);
        }
        //Read by Category
        public List<Product> GetProductsByCategory(string category)
        {
            return _context.Products.Where(p=>p.Category.Equals(category)).ToList();
        }
        //Update
        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\nChoose a field to update (1–6):");
                Console.WriteLine("1. Product Name");
                Console.WriteLine("2. Product Price");
                Console.WriteLine("3. Product Quantity");
                Console.WriteLine("4. Product Category");
                Console.WriteLine("5. Product Availability");
                Console.WriteLine("6. Save and Exit");
                Console.Write("Enter option: ");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Enter new Product Name: ");
                        product.Name = Console.ReadLine();
                        break;

                    case 2:
                        Console.Write("Enter new Product Price: ");
                        product.Price = Convert.ToDecimal(Console.ReadLine());
                        break;

                    case 3:
                        Console.Write("Enter new Product Quantity: ");
                        product.Quantity = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 4:
                        Console.Write("Enter new Product Category: ");
                        product.Category = Console.ReadLine();
                        break;

                    case 5:
                        Console.Write("Is the product available? (true/false): ");
                        product.IsAvailable = Convert.ToBoolean(Console.ReadLine());
                        break;

                    case 6:
                        _context.Products.Update(product);
                        _context.SaveChanges();
                        Console.WriteLine($"\n✅ Product '{product.Name}' updated successfully!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        //Delete
        public void DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.productId == id);
            if (product!=null)
            {
                _context.Products.Remove(product);
                Console.WriteLine("product removed successfully");
            }
            else
            {
                Console.WriteLine("No product found");
            }
        }
        //Display Message 
        public void Display(Product product)
        {
            Console.WriteLine($"ID           : {product.productId}");
            Console.WriteLine($"Name         : {product.Name}");
            Console.WriteLine($"Price        : ${product.Price}");          
            Console.WriteLine($"Quantity     : {product.Quantity}");
            Console.WriteLine($"Category     : {product.Category}");
            Console.WriteLine($"Available    : {(product.IsAvailable ? "Yes" : "No")}");
            Console.WriteLine($"Created Date : {product.CreatedDate:dd/MM/yyyy HH:mm}");
        }
    }
}
