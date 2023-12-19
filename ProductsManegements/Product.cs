using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SimpleInventoryManagementSystem.Utilities;
using System.ComponentModel.DataAnnotations;

namespace SimpleInventoryManagementSystem.ProductsManagement
{
    public class Product
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage = "The Product name is required!")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity can't be negative value!")]
        public int Quantity { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Price can't be negative value!")]
        [BsonRepresentation(BsonType.Decimal128)] 
        public decimal Price { get; set; }

        public CurrencyType Currency { get; set; } = CurrencyType.USD;

        public Product(string name, int quantity, decimal price, CurrencyType currency)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            Currency = currency;
        }
        public override string ToString()
        {
              return $"Product ID: {Id} \nName: {Name} \nPrice: {Price} {Currency} \nQuantity: {Quantity}";
        }
        public static List<ValidationResult> Validate(Product product)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(product, serviceProvider: null, items: null);
            Validator.TryValidateObject(product, context, validationResults, validateAllProperties: true);
            return validationResults;
        }
    }
}
