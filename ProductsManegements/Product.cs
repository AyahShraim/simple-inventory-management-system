using System.Text;

namespace SimpleInventoryManagementSystem.ProductsManagement
{
    public class Product
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Id = _nextId++;
        }
        public string ShowProductDetails()
        {
            StringBuilder stringBuilder= new StringBuilder();
            stringBuilder.AppendLine($"Product ID: {Id.ToString()}");
            stringBuilder.AppendLine($"Product Name: {Name}");
            stringBuilder.AppendLine($"Product Price: {Price.ToString()}");
            stringBuilder.AppendLine($"Product Quantity {Quantity.ToString()}");
            return stringBuilder.ToString();
        }
    }
}
