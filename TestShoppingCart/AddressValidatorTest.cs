
using ShoppingCartService.BusinessLogic.Validation;
using ShoppingCartService.Models;
using System;
using Xunit;


namespace ShoppingCartTest
{
    public class AddressValidatorTest
    {

        [Fact]
        public void ValidAddressTest()
        {

            // Arrange
            var validator = new AddressValidator();
            var address = new Address
            {
                City = "Ann Arbor",
                Country = "United States",
                Street = " W Ellsworth Rd"
            };

            // Act
            bool result = validator.IsValid(address);

            // Assert
            Assert.True(result);


        }
    }
}
