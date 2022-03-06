using DataAccess.Entities;
using PromotionEngine.CalculatorService;
using PromotionEngine.Data;
using PromotionEngine.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Calculator
{
    public class CalculateService : ICalculate
    {
        public CheckoutSummary CalcualteOrder(Order order, List<Promotion> promotions)
        {
            var checkoutSummary = new CheckoutSummary();
            CalculatorTypeService _calculatorTypeService = new CalculatorTypeService();

            foreach (var promotion in promotions)
            {
                checkoutSummary = _calculatorTypeService.GetCalculatorType(promotion).Calculate(checkoutSummary, order.Items);
            }

            checkoutSummary = _calculatorTypeService.GetDefaultCalculator(promotions).Calculate(checkoutSummary, order.Items);

            return checkoutSummary;
        }
    }
}
