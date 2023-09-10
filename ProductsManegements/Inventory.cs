using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem.ProductsManegements
{
    internal class Inventory
    {
        private static List<Product> products =new();

        public void AddProduct()
        {
            string name = " ";
            decimal price = 0;
            int quantity = 0;
            Product? product=null;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the name of the product: ");
            name = Console.ReadLine() ?? string.Empty;
            do
            {
                Console.WriteLine("Enter the price of the product: ");

            } while (!decimal.TryParse(Console.ReadLine(), out price));
            do
            {
                Console.WriteLine("Enter the quantity of the product: ");

            } while (!int.TryParse(Console.ReadLine(), out quantity));

            product=new Product(name, price, quantity);
            products.Add(product);
            Console.WriteLine($"A new product {product.Name} is added successfully! ");

        }




    }
}
