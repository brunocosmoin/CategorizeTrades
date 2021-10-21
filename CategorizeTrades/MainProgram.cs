using System;
using System.Collections.Generic;
using CategorizeTrades.Trades;
using CategorizeTrades.Categories;
using CategorizeTrades.Helpers;

namespace CategorizeTrades
{
    class MainProgram
    {
        static void Main()
        {
            List<ITrade> portfolio = new List<ITrade> { };
            List<string> tradeCategories;

            // Output console
            Console.Title = "Categories of Trades";
            Message.CyanMessage("Categories of Trades\n");

            Console.WriteLine("Value: indicates the transaction amount in dollars");
            Console.WriteLine("ClientSector: indicates the client´s sector which can be \"Public\" or \"Private\"");
            Console.WriteLine("NextPaymentDate: indicates when the next payment from the client to the bank is expected");

            Message.GreenMessage("\nInputs:\n");

            try
            {
                Console.Write("Reference Date: ");
                DateTime referenceDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Number of Trades: ");
                int numberTrades = int.Parse(Console.ReadLine());

                Console.WriteLine("\nType trade using spaces, like: Value ClientSector NextPaymentDate");

                for (int i = 1; i <= numberTrades; i++)
                {
                    Console.Write($"Trade {i}: ");
                    var text = Console.ReadLine().Trim();
                    string[] split = text.Split(' ');

                    var value = double.Parse(split[0]);
                    var clientSector = split[1];
                    var nextPaymentDate = DateTime.Parse(split[2]);

                    portfolio.Add(new Trade { Value = value, ClientSector = clientSector, NextPaymentDate = nextPaymentDate, ReferenceDate = referenceDate });                    
                }

                Console.WriteLine("\nPortfolio:\n");

                foreach (var trade in portfolio)
                {
                    Console.WriteLine($"{(Trade)trade} = {{ Value = {trade.Value}, ClientSector = \"{trade.ClientSector}\", NextPaymentDate = {trade.NextPaymentDate}}} ");
                }

                tradeCategories = new Category(portfolio).GetCategories();

                Message.BlueMessage("\nOutput:\n");
                Console.WriteLine("TradeCategories:\n");

                int index = 1;
                foreach (var categorie in tradeCategories)
                {
                    Console.WriteLine($"Trade{index} = {categorie}");
                    index++;
                }

            }
            catch (Exception e)
            {
                Message.RedMessage($"Error: {e.Message}");
            }
            finally
            {
                Message.RedMessage("\n\nPress any key to continue...");
                Console.ReadKey();
            }

        }
    }
}
