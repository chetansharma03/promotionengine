using DataAccess.Entities;
using System.Collections.Generic;

namespace PromotionEngine.Data
{
    public class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
        }
        public List<OrderItem> Items { get; set; }
    }
}