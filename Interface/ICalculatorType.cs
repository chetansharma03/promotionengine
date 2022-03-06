using DataAccess.Entities;
using PromotionEngine.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Interface
{
    public interface ICalculatorType
    {
        CalculateBase GetCalculatorType(Promotion promotion);
        DefaultBase GetDefaultCalculator(List<Promotion> promotions);
    }
}
