using MathNet.Numerics;
using QLNet;
using QuantConnect;
using QuantConnect.Algorithm;
using QuantConnect.Data;
using QuantConnect.Data.Market;
using QuantConnect.Securities.Forex;
using System.Linq;

namespace QuantConnect.Algorithm.CSharp
{
    public class TestAlgo : QCAlgorithm
    {
        /// <summary>
        /// Initialize the data and resolution required, as well as the cash and start/end dates for your algorithm.
        /// All algorithms must be initialized.
        /// </summary>
        public override void Initialize()
        {
            // Set Start and End dates
            //SetStartDate(2014, 5, 1);  // Start date Oanda EURUSD ticks
            //SetEndDate(2014, 5, 10); // End date

            SetStartDate(2007, 1, 2);  // Start date
            SetEndDate(2007, 1, 3); // End date

            // Set initial cash amount
            SetCash(100000); // Starting cash in USD


            /* How Lean Maps Data Paths
                Lean uses a structured approach to locate data files based on several parameters:
                Asset Class: e.g., forex
                Market: e.g., fxcm or oanda
                Resolution: e.g., tick, second, minute
                Symbol: e.g., eurusd
                The general path format is:
                Lean\Data\< asset class>\<market>\<resolution>\<symbol>\
                By specifying the market, you guide Lean to the correct data folder.*/

            //AddEquity("SPY", Resolution.Daily);
            AddForex("EURUSD", Resolution.Hour, Market.Oanda);
        }

        /// <summary>
        /// Event handler for new data slices. This is where the main trading logic resides.
        /// </summary>
        /// <param name="data">Slice object keyed by symbol containing the stock data</param>
        public override void OnData(Slice data)
        {
            if (data.ContainsKey("EURUSD"))
            {
                //var count = data.Ticks.Count;
                //var tick = data.Ticks["EURUSD"].First();
                //var time = tick.Time;
                //var bid = tick.BidPrice;
                //var ask = tick.AskPrice;
                var quoteBar = data.QuoteBars["EURUSD"];
                var time = quoteBar.Time;
                var openBid = quoteBar.Bid.Open;
                var openAsk = quoteBar.Ask.Open;

                if (!Portfolio.Invested)
                {
                    // Open a buy market trade for 10 shares
                    var orders = MarketOrder("EURUSD", 10000);
                }

                foreach (var kvp in Portfolio)
                {
                    var symbol = kvp.Key;
                    var holding = kvp.Value;

                    if (holding.Invested) // Check if there's an open position
                    {
                        Debug($"Open Position - Symbol: {symbol}, Quantity: {holding.Quantity}, Average Price: {holding.AveragePrice}");
                    }
                }

                if (Portfolio["EURUSD"].Invested)
                {
                    var quantity = Portfolio["EURUSD"].Quantity;

                    // Close the Forex position
                    MarketOrder("EURUSD", -quantity);
                    Debug($"Closed Forex position in EURUSD with {quantity} units");
                }

                foreach (var closedTrade in TradeBuilder.ClosedTrades)
                {
                    Debug($"Closed Trade - Symbol: {closedTrade.Symbol}, " +
                          $"Entry Time: {closedTrade.EntryTime}, Entry Price: {closedTrade.EntryPrice}, " +
                          $"Exit Time: {closedTrade.ExitTime}, Exit Price: {closedTrade.ExitPrice}, " +
                          $"Profit: {closedTrade.ProfitLoss}");
                }
            }
        }

        /// <summary>
        /// Optional: This function is called at the end of each day to perform custom logic.
        /// </summary>
        public override void OnEndOfDay()
        {
            // Perform end-of-day tasks
        }

        /// <summary>
        /// Optional: This function is called at the end of the algorithm to perform custom cleanup.
        /// </summary>
        public override void OnEndOfAlgorithm()
        {
            // Perform any cleanup tasks
        }
    }
}
