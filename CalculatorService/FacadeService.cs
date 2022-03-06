using DataAccess.Entities;
using PromotionEngine.Data;
using PromotionEngine.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Calculator
{
    public class FacadeService : IFacadeService
    {
        public string CalculateOrder(Order order)
        {
            CalculateService _calculateService = new CalculateService();
            Promotion obj = new Promotion();

            var checkoutSummary = _calculateService.CalcualteOrder(order, obj.Promotions().ToList());

            var displayResult = string.Empty;

            Console.WriteLine(Environment.NewLine);

            var totalSum = checkoutSummary.SingleItems.Sum(x => x.TotalPrice) +
                checkoutSummary.BundleItems.Sum(x => x.Amount);

            var totaldiscount = checkoutSummary.BundleItems.Sum(x => x.PromotionDiscount);

            Console.WriteLine($"Promotion discount:{ totaldiscount }");
            Console.WriteLine($"Total Amount:{ totalSum }");

            return displayResult;
        }
    }
}
