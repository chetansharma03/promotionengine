using DataAccess.Entities;
using PromotionEngine.Calculators;
using System.Collections.Generic;

namespace PromotionEngine.Calculators
{
    public abstract class DefaultBase : CalculateBase
    {
        public List<Promotion> Promotions { get; set; }

        public DefaultBase(List<Promotion> promotions)
        {
            Promotions = promotions;
        }
    }
}
