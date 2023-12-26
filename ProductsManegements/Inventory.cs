namespace SimpleInventoryManagementSystem.ProductsManagement
{
    public class Inventory
    {
        private readonly List<Product> products = new List<Product>();
        public bool AddProduct(Product product)
        {
            if (!IsExistProduct(product.Name))
            {
                products.Add(product);
                return true;
            }
            return false;
        }
        private bool IsExistProduct(string name)
        {
            return products.Any(product => product.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        public bool DeleteProduct(string name)
        {
            Product existingProduct = SearchProduct(name);
            if (existingProduct != null)
            {
                products.Remove(existingProduct);
                return true;
            }  
                return false;     
        }
        public bool UpdateProduct(Product existingProduct, Product updatedProduct)
        {
            if (existingProduct != null)
            {
                int productIndex = products.IndexOf(existingProduct);
                products[productIndex] = updatedProduct;
                return true;
            }
            return false;          
        }
        public Product? SearchProduct(string name)
        {
            return products.FirstOrDefault(product => product.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        public List<Product> GetAllProducts()
        {
            return products;
        }
    }
}
      


