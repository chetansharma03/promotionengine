using DataAccess.Enums;

namespace PromotionEngine.Data
{
    public class BundleItem
    {
        public int BundleCount { get; set; }
        public double PromotionDiscount { get; set; }
        public DiscountType DiscountType { get; set; }
        public double Amount { get; set; }
    }
}