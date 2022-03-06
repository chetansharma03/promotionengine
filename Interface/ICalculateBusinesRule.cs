using DataAccess.Entities;
using PromotionEngine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Interface
{
    public interface ICalculateBusinessRule
    {
        bool ValidateOrder(List<OrderItem> orderItems, Promotion promotion);
        AnalizeOrderItems ApplyBusinessRules(List<OrderItem> orderItems, Promotion promotion);
    }
}
