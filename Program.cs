using ConsoleApp_Dependency_Injection;
using ConsoleApp_Dependency_Injection.Models;
using ConsoleApp_Dependency_Injection.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp_DI
{
    public class Program
    {   
        public static void Main(string[] args) 
        {
            IHost host = Host.CreateDefaultBuilder().ConfigureServices(
                (context, service) =>
                {
                    service.AddDbContext<ProductDbContext>(options =>
                    {
                        options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Product_DB;Trusted_Connection=True;");
                    });
                    service.AddScoped<IProductService, ProductService>();
                }
                ).Build();
            var _service = host.Services.GetRequiredService<IProductService>();

            while (true)
            {
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine("choose an option 1 - 6");
                Console.WriteLine("1 - add product");
                Console.WriteLine("2 - display all products");
                Console.WriteLine("3 - display by id");
                Console.WriteLine("4 - display by category");
                Console.WriteLine("5 - update");
                Console.WriteLine("6 - delete");
                Console.WriteLine("7 - Exit");
                Console.WriteLine("\n-----------------------------------------------------------------------------");
                if (int.TryParse(Console.ReadLine(),out int options))
                {
                    switch (options)
                    {
                        case 1:
                            //create
                            _service.AddProduct();
                            Console.WriteLine("product added successfully");
                            break;
                        case 2:
                            //Read all
                            var products = _service.GetAllProducts();
                            if (products.Count == 0)
                            {
                                Console.WriteLine("No product available in list");
                            }
                            else
                            {
                                foreach (var p in products)
                                {
                                    _service.Display(p);
                                }   
                            }
                            break;
                        case 3:
                            //Read by id
                            Console.WriteLine("Enter the id of the product you want to display");
                            int id = int.Parse(Console.ReadLine());
                            var get_product = _service.GetProductById(id);
                            _service.Display(get_product);
                            break;
                        case 4:
                            //Read by Category
                            Console.WriteLine("Enter the category of product");
                            string category = Console.ReadLine();
                            var category_list = _service.GetProductsByCategory(category);
                            foreach(var cat in category_list)
                            {
                                _service.Display(cat);
                            }
                            break;
                        case 5:
                            //Update
                            Console.WriteLine("Enter the id of the product you want to display");
                            int update_id = int.Parse(Console.ReadLine());
                            var product = _service.GetProductById(update_id);
                            _service.UpdateProduct(product);
                            break;
                        case 6:
                            //Delete
                            Console.WriteLine("Enter the id of the product you want to delete");
                            int delete_id = int.Parse(Console.ReadLine());
                            _service.DeleteProduct(delete_id);
                            break;
                        case 7:
                            Console.WriteLine("Exit from the options");
                            return;
                        default:
                            Console.WriteLine("choose from given options");
                            break;
                    }

                }
            }
        }

    }
}