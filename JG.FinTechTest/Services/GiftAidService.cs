using System;
using JG.FinTechTest.Exceptions;

namespace JG.FinTechTest.Services
{
    public class GiftAidService : IGiftAidService
    {
        private readonly decimal _taxRate;

        public GiftAidService(decimal taxRate)
        {
            _taxRate = taxRate >= 0 && taxRate < 100 ? taxRate : throw new InvalidTaxRateException();
        }

        /// <summary>
        /// Calculates the gift aid amount due based on a donation amount
        /// </summary>
        /// <param name="donationAmount">Donation amount used to calculate gift aid</param>
        /// <returns>Gift Aid amount based on the following formula:
        ///                     [Donation Amount] * ( [TaxRate] / (100 - [TaxRate]) ).
        /// </returns>
        public decimal CalculateGiftAid(decimal donationAmount) => Math.Round(donationAmount * (_taxRate / (100 - _taxRate)), 2);
    }
}