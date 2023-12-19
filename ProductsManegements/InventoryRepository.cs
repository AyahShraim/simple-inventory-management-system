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
    }
}
