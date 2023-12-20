﻿using SimpleInventoryManagementSystem.ProductsManagement;
using SimpleInventoryManagementSystem.Utilities;

namespace SimpleInventoryManagementSystem.UI
{
    public class InventoryUI
    {
        private InventoryRepository _inventory;
        private IWriter _writer;
        public InventoryUI(InventoryRepository inventory, IWriter writer)
        {
            _inventory = inventory;
            _writer = writer;
        }
        public void AddProduct()
        {
            string name = ReadProductName();
            int quantity = ReadProductQuantity();
            decimal price = ReadProductPrice();
            CurrencyType currency = ReadProductCurrency();
            try
            {
                Product newProduct = new Product(name, quantity, price, currency);
                if (IsValidProduct(newProduct))
                {
                    bool isSuccess = _inventory.AddProduct(newProduct);
                    if (isSuccess) _writer.Write($"Product {name} added successfully\n");
                    else _writer.Write("Product already exist!\n");
                }
                return;
            }
            catch(Exception ex)
            {
                _writer.Write($"Error creating product: {ex.Message}\n");
            }
        }
        private string ReadProductName()
        {
            _writer.Write("Enter product name:");
            return Console.ReadLine();
        }
        private int ReadProductQuantity()
        {
            _writer.Write("Enter product quantity:");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                _writer.Write("Invalid input. Quantity must be an integer.Try again:");
            }
            return quantity;
        }
        private decimal ReadProductPrice()
        {
            _writer.Write("Enter product price:");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                _writer.Write("Invalid input. Price must be decimal.Try again:");
            }
            return price;
        }
        private CurrencyType ReadProductCurrency()
        {
            _writer.Write("Enter product currency (USD, EUR, GBP): ");
            while (true)
            {
                string input = Console.ReadLine()?.Trim().ToUpper(); // Convert to uppercase for case-insensitivity
                if (TryParseCurrency(input, out var currency))
                {
                    return currency;
                }
                _writer.Write("Invalid input. Please enter a valid currency code.");
            }
        }
        private bool TryParseCurrency(string input, out CurrencyType currency)
        {
            return Enum.TryParse(input, true, out currency) && Enum.IsDefined(typeof(CurrencyType), currency);
        }
        private bool IsValidProduct(Product product)
        {
            var ValidationErrorsList = Product.Validate(product);
            if (ValidationErrorsList.Count != 0)
            {
                _writer.Write("Invalid product. Please check the following errors:\n");
                ValidationErrorsList.ForEach(error => _writer.Write(error.ToString()));
                return false;
            }
            return true;
        }
        public void ViewAllProducts()
        {
            List<Product> products = _inventory.GetAllProducts();
            if(products.Count > 0)
            {
                products.ForEach(product => _writer.Write($"\n{product}"));
                return;
            }
            _writer.Write("\nNo products in the inventory");   
        }
        public void ViewProduct()
        {
            string productName = ReadProductName();
            Product product = _inventory.SearchProduct(productName);
            if (product != null)
            {
                _writer.Write($"\n{product}");
            }
            else
            {
                _writer.Write($"\nCouldn't find product {productName} in the inventory! Please recheck the name.");
            }
        }
        public void DeleteProduct()
        {
            string productName = ReadProductName();
            bool isSuccess = _inventory.DeleteProduct(productName);
            if (isSuccess)
            {
                _writer.Write($"\nproduct {productName} deleted successfully!");
            }
            else
            {
                _writer.Write($"\nCouldn't find product {productName} in the inventory! Please recheck the name.");
            }
        }
        public void UpdateProduct()
        {
            string productToUpdateName= ReadProductName();
            if (!_inventory.IsExistProduct(productToUpdateName))
            {
                _writer.Write($"\nCouldn't find product {productToUpdateName} in the inventory! Please recheck the name.");
            }
            else
            {
                Product updatedProduct = ReadUpdatedProduct();
                if (IsValidProduct(updatedProduct))
                {
                    bool isSuccess = _inventory.UpdateProduct(productToUpdateName, updatedProduct);
                    if (isSuccess)
                    {
                        _writer.Write($"\nProduct {productToUpdateName} updated successfully!");
                    }
                    else
                    {
                        _writer.Write($"\nCheck the new product data (Note: you can't update name to already exist name)");
                    }
                }
            }      
        }
        private Product ReadUpdatedProduct()
        {
            string name = ReadProductName();
            int quantity = ReadProductQuantity();
            decimal price = ReadProductPrice();
            CurrencyType currency = ReadProductCurrency();
            return new Product(name, quantity, price, currency);
        } 
    }
}
