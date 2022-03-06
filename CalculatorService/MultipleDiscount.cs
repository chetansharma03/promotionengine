using DataAccess.Entities;
using DataAccess.Enums;
using PromotionEngine.Data;
using PromotionEngine.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.CalculatorService
{
    class MultipleDiscount : ICalculateDiscountRule
    {
        public BundleItem CalculateDiscount(AnalizeOrderItems rulesDTO, Promotion promotion)
        {
            double priceBeforeDiscount = 0.0;
            double priceAfterDiscount = 0.0;

            if (promotion.DiscountType == DiscountType.FixedPrice)
            {
                priceBeforeDiscount = promotion.Quantity * rulesDTO.BundleCount * rulesDTO.ItemForProccessing.First().Price;
                priceAfterDiscount = promotion.FixedPriceDiscount * rulesDTO.BundleCount;
            }
            else
            {
                priceBeforeDiscount = rulesDTO.ItemForProccessing.Sum(item => item.Price * item.Quantity);
                priceAfterDiscount = priceBeforeDiscount - priceBeforeDiscount * promotion.PercentageDiscount / 100;
            }

            return new MultipleBundleItem()
            {
                DiscountType = promotion.DiscountType,
                BundleCount = rulesDTO.BundleCount,
                SKU = rulesDTO.ItemForProccessing.FirstOrDefault().SKU,
                PromotionDiscount = priceBeforeDiscount - priceAfterDiscount,
                Amount = priceAfterDiscount
            };
        }
    }
}
