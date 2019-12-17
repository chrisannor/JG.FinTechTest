using System.Threading.Tasks;
using JG.FinTechTest.Controllers;
using JG.FinTechTest.Exceptions;
using JG.FinTechTest.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace JG.FinTechTest.Tests
{
    public class GiftAidControllerMust
    {
        private readonly IGiftAidService _giftAidService;
        private readonly GiftAidController _giftAidController;
        private const decimal TAX_RATE = 20M;

        public GiftAidControllerMust()
        {
            _giftAidService = new GiftAidService(TAX_RATE);
            _giftAidController = new GiftAidController(_giftAidService);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(5)]
        [InlineData(5000)]
        [InlineData(13.57)]
        public async Task Return_donation_in_response(decimal donationAmount)
        {
            var controllerResponse = _giftAidController.GetGiftAidAmount(donationAmount).Value;

            Assert.Equal(donationAmount, controllerResponse.DonationAmount);
        }

        [Theory]
        [InlineData(20.00)]
        [InlineData(10000.00)]
        [InlineData(23.75)]
        [InlineData(100)]
        [InlineData(4321.50)]
        public void Return_the_same_gift_aid_amount_as_service(decimal donationAmount)
        {
            var controllerResponse = _giftAidController.GetGiftAidAmount(donationAmount).Value;

            Assert.Equal(_giftAidService.CalculateGiftAid(donationAmount), controllerResponse.GiftAidAmount);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(1.50)]
        public void Return_bad_request_and_error_message_for_donations_less_than_two_pound_or_more_than_one_hundred_thousand(decimal donationAmount)
        {

            var controllerResponse = _giftAidController.GetGiftAidAmount(donationAmount);

            // Assert
            Assert.IsType<BadRequestObjectResult>(controllerResponse.Result);
        }
    }


}
