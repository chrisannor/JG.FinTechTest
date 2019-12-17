namespace JG.FinTechTest.Exceptions
{
    public class InvalidTaxRateException : JGFinTechTestException
    {
        private const string TAX_RATE_EXCEPTION_MESSAGE = "Invalid tax rate entered, Please enter a tax rate between 0-99";
        public InvalidTaxRateException() : base(ErrorCode.InvalidTaxRate, TAX_RATE_EXCEPTION_MESSAGE)
        { }
    }

}
