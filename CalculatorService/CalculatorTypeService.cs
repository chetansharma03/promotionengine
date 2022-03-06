using DataAccess.Entities;
using PromotionEngine.Calculator;
using PromotionEngine.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.CalculatorService
{
   public class CalculatorTypeService
    {
        public CalculateBase GetCalculatorType(Promotion promotion)
        {
            if (promotion.BundleType == DataAccess.Enums.BundleType.Bundle)
            {
                return new PromotionCalculator(promotion, new BundleBusinessRules(), new BundleDiscount());
            }
            else
            {
                return new PromotionCalculator(promotion, new MultipleBusinessRules(), new MultipleDiscount());
            }
        }

        public DefaultBase GetDefaultCalculator(List<Promotion> promotions)
        {
            return new DefaultCalculator(promotions);
        }
    }
}
