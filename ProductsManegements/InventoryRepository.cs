using MongoDB.Driver;

namespace SimpleInventoryManagementSystem.ProductsManagement
{
    public class InventoryRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<Product> _productCollection;

        public InventoryRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
            _productCollection = _mongoDatabase.GetCollection<Product>("product");
        }
        public bool AddProduct(Product product)
        {
            if (!IsExistProduct(product.Name))
            {
                _productCollection.InsertOne(product);
                return true;
            }
            return false;
        }
        public bool IsExistProduct(string name)
        {
            var filter = Builders<Product>.Filter.Eq(product=> product.Name, name);   
            var count = _productCollection.CountDocuments(filter);
            return count > 0; ;
        }
        public bool DeleteProduct(string name)
        {
            var filter = Builders<Product>.Filter.Eq(product => product.Name, name);
            var result = _productCollection.DeleteOne(filter);
            return result.DeletedCount > 0;          
        }
        public bool UpdateProduct(string oldName, Product updatedProduct)
        {
            var filter = Builders<Product>.Filter.Eq(product => product.Name, oldName);
            if (CouldUpdateProduct(updatedProduct, oldName))
            {
                var update = Builders<Product>.Update
                    .Set("Name", updatedProduct.Name)
                    .Set("Quantity", updatedProduct.Quantity)
                    .Set("Price", updatedProduct.Price)
                    .Set("Currency", updatedProduct.Currency.ToString());
                     
                var result = _productCollection.UpdateOne(filter, update);
                return result.MatchedCount > 0;
            }
            return false;
        }
        private bool CouldUpdateProduct(Product updatedProduct, string oldName)
        {
            return !IsExistProduct(updatedProduct.Name) || updatedProduct.Name.Equals(oldName);
        }
        public Product? SearchProduct(string name)
        {
            var filter = Builders<Product>.Filter.Eq(product => product.Name, name);
            var product = _productCollection.Find(filter).FirstOrDefault();
            return product;
        }
    }
}
