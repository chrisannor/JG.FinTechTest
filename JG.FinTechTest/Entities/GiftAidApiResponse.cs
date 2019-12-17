using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.Entities
{
    public class GiftAidApiResponse
    {
        public GiftAidApiResponse(decimal donationAmount, decimal giftAidAmount)
        {
            DonationAmount = donationAmount;
            GiftAidAmount = giftAidAmount;
        }

        public decimal DonationAmount { get; }
        public decimal GiftAidAmount { get; }
    }
}
