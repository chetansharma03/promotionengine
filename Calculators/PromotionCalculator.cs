using DataAccess.Entities;
using PromotionEngine.Data;
using PromotionEngine.Interface;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Calculators
{
    public class PromotionCalculator : PromotionBase
    {
        private readonly Promotion promotion;
        private readonly ICalculateDiscountRule _discountService;
        private readonly ICalculateBusinessRule _calcultationBusinessLogic;

        public PromotionCalculator(Promotion promotion, ICalculateBusinessRule calculationBusinessLogic, ICalculateDiscountRule discountServices) : base(promotion, calculationBusinessLogic, discountServices)
        {
            this.promotion = promotion;
            _calcultationBusinessLogic = calculationBusinessLogic;
            _discountService = discountServices;
        }

        public override CheckoutSummary Calculate(CheckoutSummary checkoutSummary, List<OrderItem> orderItems)
        {
            if (!_calcultationBusinessLogic.ValidateOrder(orderItems, promotion))
            {
                return checkoutSummary;
            }

            var rulesDTO = _calcultationBusinessLogic.ApplyBusinessRules(orderItems, promotion);

            if (rulesDTO.ItemForProccessing.Any())
            {
                checkoutSummary.BundleItems.Add(_discountService.CalculateDiscount(rulesDTO, promotion));
            }

            if (rulesDTO.SingleItems.Any())
            {
                checkoutSummary.SingleItems.AddRange(rulesDTO.SingleItems);
            }

            return checkoutSummary;
        }
    }
}
