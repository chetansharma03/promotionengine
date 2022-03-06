using System.Collections.Generic;

namespace PromotionEngine.Data
{
    public class CheckoutSummary
    {
        public List<BundleItem> BundleItems { get; set; }
        public List<SingleItem> SingleItems { get; set; }
        public CheckoutSummary()
        {
            BundleItems = new List<BundleItem>();
            SingleItems = new List<SingleItem>();
        }
    }
}
