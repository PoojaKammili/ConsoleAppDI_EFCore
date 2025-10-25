using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Dependency_Injection.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string Name{ get; set; }
        public decimal Price {  get; set; }
        public int Quantity {  get; set; }
        public string Category {  get; set; }
        public bool IsAvailable {  get; set; }
        public DateTime CreatedDate {  get; set; }
    }
}


