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
    public class BundleDiscount : ICalculateDiscountRule
    {
        public BundleItem CalculateDiscount(AnalizeOrderItems rulesDTO, Promotion promotion)
        {
            double priceBeforeDiscount = 0.0;
            double priceAfterDiscount = 0.0;

            if (promotion.DiscountType == DiscountType.FixedPrice)
            {
                priceBeforeDiscount = rulesDTO.ItemForProccessing.Sum(item => item.Price * item.Quantity);
                priceAfterDiscount = promotion.FixedPriceDiscount * rulesDTO.BundleCount;
            }
            else
            {
                priceBeforeDiscount = rulesDTO.ItemForProccessing.Sum(item => item.Price * item.Quantity);
                priceAfterDiscount = priceBeforeDiscount - priceBeforeDiscount * promotion.PercentageDiscount / 100;
            }

            return new CombinationBundleItem()
            {
                DiscountType = promotion.DiscountType,
                BundleCount = rulesDTO.ItemForProccessing.Sum(x => x.Quantity),
                SKUs = rulesDTO.ItemForProccessing.Select(x => x.SKU).ToList(),
                PromotionDiscount = priceBeforeDiscount - priceAfterDiscount,
                Amount = priceAfterDiscount
            };
        }
    }
}
