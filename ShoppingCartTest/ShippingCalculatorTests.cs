using ShoppingCartService.BusinessLogic;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCartTest
{
    public class ShippingCalculatorTests
    {
        [Fact]
        public void CalculateShipingCost_SameCountry_TwoItems_ExpeditedShipping()
        {
     
            var shippingCalculator = new ShippingCalculator();
            var address = SetAddress("East Lansing", "USA", "735 E Shaw Ln");
            var listItems = new List<Item>
            {
                SetItem(14, "p1", "", 4),
                SetItem(20, "p1", "", 1)
            };

            var cart = SetShoppingCart("costumer01", CustomerType.Premium, ShippingMethod.Expedited, address, listItems);
            
            double shippingCost = shippingCalculator.CalculateShippingCost(cart);

            Assert.Equal(10, shippingCost);
        }

        [Fact]
        public void CalculateShipingCost_SameCountry_NoItems()
        {

            var shippingCalculator = new ShippingCalculator();
            var address = SetAddress("East Lansing", "USA", "735 E Shaw Ln");
            var listItems = new List<Item>();

            var cart = SetShoppingCart("costumer01", CustomerType.Premium, ShippingMethod.Expedited, address, listItems);

            double shippingCost = shippingCalculator.CalculateShippingCost(cart);

            Assert.Equal(0, shippingCost);
        }


        public Address SetAddress(string city, string country, string street)
        {
            var address = new Address
            {
                City = city,
                Country = country,
                Street = street
            };

            return address;
        }

        public Item SetItem(double price, string productId, string productName, uint quantity)
        {
            var item = new Item
            {
                Price = price,
                ProductId = productId,
                ProductName = productName,
                Quantity = quantity
            };

            return item;
        }
        
        public Cart SetShoppingCart(string costumerId, CustomerType costumerType, ShippingMethod shippingMethod, Address address, List<Item> items)
        {
            var cart = new Cart
            {
                CustomerId = costumerId,
                CustomerType = costumerType,
                ShippingMethod = shippingMethod,
                ShippingAddress = address,
                Items = items
            };

            return cart;
        }
    }
}
