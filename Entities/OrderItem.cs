using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string SKU { get; set; }
        public int Price { get; set; }

        /// <summary>
        /// we have harded items for now, it should be pulled from persistent db
        /// </summary>
        /// <returns></returns>
        public List<OrderItem> getAllProducts()
        {
            List<OrderItem> lstOrderItem = new List<OrderItem>();
            lstOrderItem.Add(new OrderItem { Id = 1, SKU = "A", Price = 50 });
            lstOrderItem.Add(new OrderItem { Id = 2, SKU = "B", Price = 30 });
            lstOrderItem.Add(new OrderItem { Id = 3, SKU = "C", Price = 20 });
            lstOrderItem.Add(new OrderItem { Id = 4, SKU = "D", Price = 15 });
            return lstOrderItem;
        }
    }
}
