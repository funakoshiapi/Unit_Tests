using AutoMapper;
using ShoppingCartService.BusinessLogic;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.Mapping;
using ShoppingCartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCartTest
{
    public class CheckOutEngineTest
    {
        private readonly IMapper _mapper;

        public CheckOutEngineTest()
        {
            var config = new MapperConfiguration(configuration => configuration.AddProfile(new MappingProfile()));

            _mapper = config.CreateMapper();
        }

        [Fact]
        public void CalculateTotal_CostumerDiscount()
        {
            var address = new Address { Country = "USA", City = "Lansing", Street = "735 E Shaw Ln" };
            var checkOut = new CheckOutEngine(new ShippingCalculator(address), _mapper);

            var cart = new Cart
            {
                CustomerType = CustomerType.Premium,
                Items = new() { new Item { Price = 33, ProductId = "P001", ProductName = "", Quantity = 10 } },
                ShippingAddress = address
            };

            var total = checkOut.CalculateTotals(cart);

            Assert.Equal(10, total.CustomerDiscount);
        }

 

    }
}
