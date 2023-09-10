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
            foreach(Product product in products)
            {
                if (product.Name.ToLower().Equals(name?.ToLower()))
                {
                    
                    return product;
                    
                }
             
            }
            return null;

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




    }
}
