using System;

namespace CategorizeTrades.Risk
{
    static class RiskFactory
    {
        public static IRisk Create(TypeRisk risk)
        {
            return Create(risk.ToString());
        }

        public static IRisk Create(string risk)
        {
            switch (risk)
            {
                case "EXPIRED":
                    return new EXPIRED();
                case "MEDIUMRISK":
                    return new MEDIUMRISK();
                case "HIGHRISK":
                    return new HIGHRISK();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
