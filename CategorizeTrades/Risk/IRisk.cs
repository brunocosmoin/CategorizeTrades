using CategorizeTrades.Trades;

namespace CategorizeTrades.Risk
{
    interface IRisk
    {
        string Type { get; }

        bool CalculateRisk(ITrade trade);
    }
}
