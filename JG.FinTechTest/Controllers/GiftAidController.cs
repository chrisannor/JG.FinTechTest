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

        [HttpGet("GetGiftAidAmount")]
        public ActionResult<GiftAidApiResponse> GetGiftAidAmount(decimal amount)
        {
            var giftAidAmount = _giftAidService.CalculateGiftAid(amount);

            return new GiftAidApiResponse(amount, giftAidAmount);
        }
    }
}