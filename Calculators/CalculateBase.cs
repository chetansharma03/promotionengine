using DataAccess.Entities;
using PromotionEngine.Data;
using System.Collections.Generic;

namespace PromotionEngine.Calculators
{
    public abstract class CalculateBase
    {
        public abstract CheckoutSummary Calculate(CheckoutSummary checkoutSummary, List<OrderItem> orderItems);
    }
}
