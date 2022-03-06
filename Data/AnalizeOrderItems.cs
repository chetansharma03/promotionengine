using DataAccess.Entities;
using System.Collections.Generic;

namespace PromotionEngine.Data
{
    public class AnalizeOrderItems
    {
        public AnalizeOrderItems()
        {
            ItemForProccessing = new List<OrderItem>();
            SingleItems = new List<SingleItem>();
        }
        public int BundleCount { get; set; }
        public int BundleItemModulus { get; set; }
        public int BundleItemCount { get; set; }
        public List<OrderItem> ItemForProccessing { get; set; }
        public List<SingleItem> SingleItems { get; set; }
    }
}
