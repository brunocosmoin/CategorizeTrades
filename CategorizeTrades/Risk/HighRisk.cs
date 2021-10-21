using CategorizeTrades.Trades;

namespace CategorizeTrades.Risk
{
    class HIGHRISK : IRisk
    {
        public string Type { get; private set; }

        public bool CalculateRisk(ITrade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector.Equals(SectorRisk.Private.ToString()))
            {
                this.Type = TypeRisk.HIGHRISK.ToString().ToUpper();

                return true;
            }

            this.Type = NoneRisk.NONERISK.ToString();

            return false;
        }
    }
}
