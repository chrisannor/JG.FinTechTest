using System;
using JG.FinTechTest.Exceptions;
using JG.FinTechTest.Services;
using Xunit;

namespace JG.FinTechTest.Tests
{
    public class GiftAidMust
    {
        private readonly IGiftAidService _giftAidService;
        private const decimal TAX_RATE = 20M;

        public GiftAidMust()
        {
            _giftAidService = new GiftAidService(TAX_RATE);
        }

        [Fact]
        public void Return_zero_when_zero_donation_is_given()
        {
            Assert.Equal(0.00M, _giftAidService.CalculateGiftAid(0M));
        }

        [Theory]
        [InlineData(5.00,20.00)]
        [InlineData(25.00, 100.00)]
        [InlineData(5.94, 23.75)]
        [InlineData(25, 100)]
        [InlineData(1080.38, 4321.50)]
        public void Return_expected_gift_aid_amount_from_donation(decimal expectedGiftAidResult, decimal donationAmount)
        {
            Assert.Equal(expectedGiftAidResult, _giftAidService.CalculateGiftAid(donationAmount));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(5.26, 5)]
        [InlineData(11.11, 10)]
        [InlineData(14.29, 12.5)]
        [InlineData(25, 20)]
        [InlineData(33.33, 25)]
        [InlineData(100, 50)]
        [InlineData(9900, 99)]

        public void Calculate_correct_gift_aid_using_different_tax_rates(decimal expectedGiftAidResult, decimal taxRate)
        {
            var variableGiftAidService = new GiftAidService(taxRate);

            Assert.Equal(expectedGiftAidResult, variableGiftAidService.CalculateGiftAid(100.00M));

        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-50)]
        [InlineData(-100)]
        [InlineData(-1000)]
        [InlineData(-150)]
        [InlineData(-200)]
        [InlineData(-250)]


        public void Throw_Invalid_tax_rate_exception_when_tax_rate_is_less_than_one_or_greater_than_ninety_nine(decimal taxRate)
        {
            Assert.Throws<InvalidTaxRateException>(() => new GiftAidService(taxRate));
        }
    }

}
