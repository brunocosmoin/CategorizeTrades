using CategorizeTrades.Trades;

namespace CategorizeTrades.Risk
{
    class EXPIRED : IRisk
    {
        public string Type { get; private set; }

        public bool CalculateRisk(ITrade trade)
        {
            var diffTotalDays = (trade.ReferenceDate - trade.NextPaymentDate).TotalDays;            

            if (diffTotalDays > 30)
            {
                this.Type = TypeRisk.EXPIRED.ToString().ToUpper();

                return true;
            }

            this.Type = NoneRisk.NONERISK.ToString();

            return false;
        }
    }
}
