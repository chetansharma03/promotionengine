using PromotionEngine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Interface
{
    public interface IFacadeService
    {
        string CalculateOrder(Order order);
    }
}
