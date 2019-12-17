using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JG.FinTechTest.Entities;
using JG.FinTechTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JG.FinTechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftAidController : ControllerBase
    {
        private readonly IGiftAidService _giftAidService;

        public GiftAidController(IGiftAidService giftAidService)
        {
            _giftAidService = giftAidService;
        }

        /// <summary>
        /// Get the amount of gift aid reclaimable for donation amount
        /// There are two validation rules:
        /// Minimum donation amount is £2.00.
        /// Maximum donation amount is £100,000.00.
        /// I could use an action filter for the validation so it's handled by the middleware but for simplicity I've included it in the controller
        /// </summary>
        /// <param name="amount">donation amount</param>
        /// <returns>Donation amount and gift aid amount</returns>
        [HttpGet("GetGiftAidAmount")]
        public ActionResult<GiftAidApiResponse> GetGiftAidAmount(decimal amount)
        {
            if (amount < 2 || amount > 100000) return BadRequest("Donation amount must be between £2 and £100,000");
            var giftAidAmount = _giftAidService.CalculateGiftAid(amount);

            return new GiftAidApiResponse(amount, giftAidAmount);
        }
    }
}