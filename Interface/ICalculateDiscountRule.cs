using DataAccess.Entities;
using PromotionEngine.Data;

namespace PromotionEngine.Interface
{
    public interface ICalculateDiscountRule
    {
        BundleItem CalculateDiscount(AnalizeOrderItems rules, Promotion promotion);
    }
}
