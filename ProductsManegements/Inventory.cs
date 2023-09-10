using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;

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

        public void ViewAllProducts()
        {
            foreach(Product product in products)
            {
                
                Console.WriteLine(product.ShowProductDetails());
       
            }


        }

        public Product? SearchProduct()
        {
            Console.WriteLine("Enter the product name:");
            string ?name =Console.ReadLine();
            return products.Find(x => x.Name == name);

        }

        public void SearchDisplayProduct()
        {
            Product? product = SearchProduct();
         
            if (product != null)
            {
                Console.WriteLine(product.ShowProductDetails());
            }
            else
            {
                Console.WriteLine("No such product! Recheck the name and try again!");
            }
        }

        public void DeleteProduct()
        {
            Product? product = SearchProduct();

            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product deleted Sucessfully!");
            }
            else
            {
                Console.WriteLine("No such product! Recheck the name and try again!");
            }
        }

        public void UpdateProduct()
        {
            Product? product=SearchProduct();
            //string pattern = @"^(?![YyNn]$).*$";
            int input =0;
            if (product != null)
            {
               void menu()
                {
                    Console.WriteLine("************\n***CHOOSE***\n************");
                    int i = 1;
                    foreach (PropertyInfo p in product.GetType().GetProperties())
                    {
                        if (p.Name == "Id") continue;
                        Console.WriteLine($"{i}.Edit {p.Name}");
                        i++;
                    }
                }
                while (true)
                {
                    menu();
                    if (int.TryParse(Console.ReadLine(), out input))
                    {
                        switch (input)
                        {
                            case 1:
                                string name = Console.ReadLine() ?? string.Empty;
                                product.Name = name;

                                break;

                            case 2:
                                decimal price;
                                do
                                {
                                    Console.WriteLine("Enter valid price: ");

                                } while (!decimal.TryParse(Console.ReadLine(), out price));
                                product.Price = price;

                                break;

                            case 3:
                                int quantity;
                                do
                                {
                                    Console.WriteLine("Enter the quantity of the product: ");

                                } while (!int.TryParse(Console.ReadLine(), out quantity));
                                product.Quantity = quantity;

                                break;

                            default:

                                Console.WriteLine("Not Valid");
                                break;


                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("No such product! Recheck the name and try again!");
            }


        }


    }
}
