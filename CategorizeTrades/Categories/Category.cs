using System;
using System.Collections.Generic;
using CategorizeTrades.Risk;
using CategorizeTrades.Trades;

namespace CategorizeTrades.Categories
{
    class Category
    {
        private readonly List<ITrade> portfolio;

        public Category(List<ITrade> portfolio)
        {
            this.portfolio = portfolio;
        }

        public List<string> GetCategories()
        {
            IRisk risk = null;

            List<string> tradeCategories = new List<string>();

            List<IRisk> risks = new List<IRisk> {
                RiskFactory.Create(TypeRisk.EXPIRED),
                RiskFactory.Create(TypeRisk.MEDIUMRISK),
                RiskFactory.Create(TypeRisk.HIGHRISK)
            };

            foreach (Trade trade in portfolio)
            {
                foreach (IRisk r in risks)
                {
                    risk = r;
                    
                    if (trade.CalculateRisk(r))
                    {
                        break;
                    }
                }
                
                tradeCategories.Add(risk.Type);
            }

            return tradeCategories;
        }
    }
}
