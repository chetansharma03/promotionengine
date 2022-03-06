using DataAccess.Enums;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public BundleType BundleType { get; set; }
        public string SKU { get; set; }
        public IEnumerable<string> SKUs { get; set; }
        public int Quantity { get; set; }
        public DiscountType DiscountType { get; set; }
        public double FixedPriceDiscount { get; set; }

        public double PercentageDiscount { get; set; }

        /// <summary>
        /// for now data is hard coded, which should be from inmemory db or from persistent db
        /// </summary>
        /// <returns></returns>
        public List<Promotion> Promotions()
        {
            List<Promotion> lstPromotion = new List<Promotion>();

            lstPromotion.Add(new Promotion { BundleType = BundleType.Multiple, DiscountType= DiscountType.FixedPrice
                             , FixedPriceDiscount=130, Id=1, Quantity=3, SKU="A", Title="3 A's for 130"});

            lstPromotion.Add(new Promotion
            {
                BundleType = BundleType.Multiple,
                DiscountType = DiscountType.Percentage
                                 ,
                PercentageDiscount = 20,
                Id = 2,
                Quantity = 2,
                SKU = "B",
                Title = "2 B's for 48"
            });

            lstPromotion.Add(new Promotion
            {
                BundleType = BundleType.Bundle,
                DiscountType = DiscountType.FixedPrice
                             ,
                FixedPriceDiscount = 30,
                Id = 3,
                SKUs = new List<string> { "C","D" },
                Title = "C and D for 30"
            }) ;

            return lstPromotion;
        }
    }
}