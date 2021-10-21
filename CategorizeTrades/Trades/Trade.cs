using CategorizeTrades.Risk;
using System;

namespace CategorizeTrades.Trades
{
    class Trade : ITrade
    {
        private static int tradeID = 1;

        private readonly string name;

        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public DateTime ReferenceDate { get; set; }

        public Trade()
        {
            this.name = "Trade" + tradeID++;
        }

        public bool CalculateRisk(IRisk risk)
        {
            return risk.CalculateRisk(this);
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
