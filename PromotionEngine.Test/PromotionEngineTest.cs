using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Calculator;
using PromotionEngine.CalculatorService;
using PromotionEngine.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Test
{
    [TestClass]
    public class PromotionEngineTest
    {
        [TestMethod]
        public void Scenario1()
        {
            //Arrange
            var order = new Order
            {
                Items = new List<OrderItem>
                {
                    new OrderItem { Quantity = 1, SKU = "A", Price = 50 },
                    new OrderItem { Quantity = 1, SKU = "B", Price = 30 },
                    new OrderItem { Quantity = 1, SKU = "C", Price = 20 }
                }
            };

            var promotions = new List<Promotion> {
                new Promotion { BundleType = BundleType.Multiple, SKU = "A", Quantity = 3, DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 130},
                new Promotion { BundleType = BundleType.Multiple, SKU = "B", Quantity = 2 , DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 45},
                new Promotion { BundleType = BundleType.Bundle, SKUs = new List<string> { "C", "D" }, DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 30 }
            };


            var calculatorTypeService = new CalculatorTypeService();
            var calculateService = new CalculateService();

            //Act
            var orderResults = calculateService.CalcualteOrder(order, promotions);

            var totalSum = orderResults.SingleItems.Sum(x => x.TotalPrice) +
                orderResults.BundleItems.Sum(x => x.Amount);

            //Assert
            Assert.AreEqual(3, orderResults.SingleItems.Sum(x => x.ItemCount));
            Assert.AreEqual(0, orderResults.BundleItems.Sum(x => x.Amount));
            Assert.AreEqual(100, totalSum);
        }

        [TestMethod]
        public void Scenario2()
        {
            //Arrange
            var order = new Order
            {
                Items = new List<OrderItem>
                {
                    new OrderItem { Quantity = 5, SKU = "A", Price = 50 },// 130 + 100
                    new OrderItem { Quantity = 5, SKU = "B", Price = 30 },// 45 + 45 + 30
                    new OrderItem { Quantity = 1, SKU = "C", Price = 20 },  // 28
                                                                         
                }
            };

            var promotions = new List<Promotion>() {
                new Promotion { BundleType = BundleType.Multiple, SKU = "A", Quantity = 3, DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 130},
                new Promotion { BundleType = BundleType.Multiple, SKU = "B", Quantity = 2 , DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 45},
                new Promotion { BundleType = BundleType.Bundle, SKUs = new List<string> { "C", "D" }, DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 30 }
            };


            var calculatorTypeService = new CalculatorTypeService();
            var calculateService = new CalculateService();

            //Act
            var orderResults = calculateService.CalcualteOrder(order, promotions);

            //Assert
            var totalSum = orderResults.SingleItems.Sum(x => x.TotalPrice) +
                orderResults.BundleItems.Sum(x => x.Amount);

            Assert.AreEqual(4, orderResults.SingleItems.Sum(x => x.ItemCount));
            Assert.AreEqual(220, orderResults.BundleItems.Sum(x => x.Amount));
            Assert.AreEqual(150, orderResults.SingleItems.Sum(x => x.TotalPrice));
            Assert.AreEqual(370, totalSum);
        }

        [TestMethod]
        public void Scenario3()
        {
            //Arrange
            var order = new Order
            {
                Items = new List<OrderItem>
                {
                    new OrderItem { Quantity = 3, SKU = "A", Price = 50 },// 130
                    new OrderItem { Quantity = 5, SKU = "B", Price = 30 },// 45 + 45 + 30
                    new OrderItem { Quantity = 1, SKU = "C", Price = 20 },
                    new OrderItem { Quantity = 1, SKU = "D", Price = 15 } // 30
                                                                          
                }
            };

            var promotions = new List<Promotion>() {
                new Promotion { BundleType = BundleType.Multiple, SKU = "A", Quantity = 3, DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 130},
                new Promotion { BundleType = BundleType.Multiple, SKU = "B", Quantity = 2 , DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 45},
                new Promotion { BundleType = BundleType.Bundle, SKUs = new List<string> { "C", "D" }, DiscountType = DiscountType.FixedPrice, FixedPriceDiscount = 30 }
            };


            var calculatorTypeService = new CalculatorTypeService();
            var calculateService = new CalculateService();

            //Act
            var orderResults = calculateService.CalcualteOrder(order, promotions);

            //Assert
            var totalSum = orderResults.SingleItems.Sum(x => x.TotalPrice) +
                orderResults.BundleItems.Sum(x => x.Amount);

            Assert.AreEqual(1, orderResults.SingleItems.Sum(x => x.ItemCount));
            Assert.AreEqual(250, orderResults.BundleItems.Sum(x => x.Amount));
            Assert.AreEqual(30, orderResults.SingleItems.Sum(x => x.TotalPrice));
            Assert.AreEqual(280, totalSum);
        }
    }
}

