using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirectory directory = new ProductDirectory();
            var builder = new CustomerProductBuilder();

            directory.GenerateProduct(builder);

            var model = builder.GetModel();

            Console.WriteLine(model.ID);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.DiscountedPrice);

            Console.ReadLine();
        }
    }
    class ProductModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string CategoryName { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductModel GetModel();
    }

    class CustomerProductBuilder : ProductBuilder
    {
        ProductModel model = new ProductModel();

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.80;
        }

        public override ProductModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.ID = 1;
            model.CategoryName = "Burger";
            model.ProductName = "Tavuk Burger";
            model.UnitPrice = 18;
        }
    }
    class ProductDirectory
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
