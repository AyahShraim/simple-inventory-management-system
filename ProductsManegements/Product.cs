using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem.ProductsManegements
{
    public class Product
    {
        private static int nextId = 1;
        private string name = "";
        private int quantity;
        private decimal price;


        public int Id { get; private set; }
        public string Name
        {

            get { return name; }
            set { name = value; }

        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value >= 0) quantity = value;
                else quantity = 0;
            }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }

        }

        //constructor 
        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Id = nextId++;

        }


       




    }



}
