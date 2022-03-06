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
    public class BundleBusinessRules : ICalculateBusinessRule
    {
        public bool ValidateOrder(List<OrderItem> orderItems, Promotion promotion)
        {
            return orderItems.Any(x => promotion.SKUs.Contains(x.SKU));
        }
        public AnalizeOrderItems ApplyBusinessRules(List<OrderItem> orderItems, Promotion promotion)
        {
            var x = new AnalizeOrderItems();

            //Get promotion orders
            var items = orderItems.Where(x1 => promotion.SKUs.Contains(x1.SKU)).ToList();

            //calculate bundles; if 1 item found minimum is forced to 0 
            x.BundleCount = items.Count > 1 ? items.Min(x1 => x1.Quantity) : 0;

            //if bundles => calculate
            if (x.BundleCount > 0)
            {
                foreach (var item in items)
                {
                    var bundleItemModulus = item.Quantity - x.BundleCount;
                    var bundleItemCount = item.Quantity - bundleItemModulus;

                    //if there are modulus items we insert it for SingleItem (non promotion list)
                    if (bundleItemModulus != 0)
                    {
                        x.SingleItems.Add(new SingleItem
                        {
                            PricePerItem = item.Price,
                            SKU = item.SKU,
                            ItemCount = bundleItemModulus,
                            TotalPrice = item.Price * bundleItemModulus
                        });
                    }

                    //inserting items for calculation discount
                    x.ItemForProccessing.Add(new OrderItem { Price = item.Price, SKU = item.SKU, Quantity = bundleItemCount });
                }

                return x;
            }

            //if there is no bundle we check for individual item
            var modulusItem = items.FirstOrDefault();

            if (modulusItem.Quantity > 0)
            {
                x.SingleItems.Add(new SingleItem
                {
                    PricePerItem = modulusItem.Price,
                    SKU = modulusItem.SKU,
                    ItemCount = modulusItem.Quantity,
                    TotalPrice = modulusItem.Price * modulusItem.Quantity
                });
            }

            return x;
        }
    }
}
