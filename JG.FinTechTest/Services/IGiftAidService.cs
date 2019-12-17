using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.Services
{
    public interface IGiftAidService
    {
        decimal CalculateGiftAid(decimal donationAmount);
    }
}
