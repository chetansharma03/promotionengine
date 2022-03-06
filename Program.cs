using DataAccess.Entities;
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
            Console.WriteLine(Program.viewProducts());
            Console.WriteLine(Program.ViewPromotions());
            

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

        public static string viewProducts()
        {
            OrderItem obj = new OrderItem();
            var products = obj.getAllProducts().ToList();
            string productsStr = products.Any() ? "All Products:" + Environment.NewLine : string.Empty;

            foreach (var product in products)
            {
                productsStr += product.SKU + "- Price:" + product.Price  + Environment.NewLine;
            }

            return productsStr;
        }
    }
}
