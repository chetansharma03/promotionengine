using DataAccess.Entities;
using PromotionEngine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderItem obj = new OrderItem();
            var products = obj.getAllProducts().ToList();

            //displaying Products and Promotions
            Console.WriteLine(Program.viewProducts(products));
            Console.WriteLine(Program.ViewPromotions());

            //lets choose Products and quantity
            var order = new Order();
            foreach (var product in products)
            {
                bool repeat = true;
                while (repeat)
                {
                    Console.Write($"Enter units of product {product.SKU}: ");
                    string input = Console.ReadLine();

                    int quantity;
                    if (int.TryParse(input, out quantity))
                    {
                        repeat = false;
                        order.Items.Add(new OrderItem() { SKU = product.SKU, Quantity = quantity, Price = product.Price });
                    }
                }
            }


            Console.ReadLine();
        }

        public static string ViewPromotions()
        {
            Promotion obj = new Promotion();
            var promotions = obj.Promotions().ToList();
            string promotionStr = promotions.Any() ? "All Promotions:" + Environment.NewLine : string.Empty;

            foreach (var promotion in promotions)
            {
                promotionStr += promotion.Title + Environment.NewLine;
            }

            return promotionStr;
        }

        public static string viewProducts(List<OrderItem> products)
        {
            string productsStr = products.Any() ? "All Products:" + Environment.NewLine : string.Empty;

            foreach (var product in products)
            {
                productsStr += product.SKU + "- Price:" + product.Price  + Environment.NewLine;
            }

            return productsStr;
        }
    }
}
