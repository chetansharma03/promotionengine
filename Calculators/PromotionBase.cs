using DataAccess.Entities;
using PromotionEngine.Interface;

namespace PromotionEngine.Calculators
{
    public abstract class PromotionBase : CalculateBase
    {
        private Promotion promotion;
        public PromotionBase(Promotion promotion, ICalculateBusinessRule calculationBusinessLogic, ICalculateDiscountRule discountServices)
        {
            this.promotion = promotion;
        }
    }
}
