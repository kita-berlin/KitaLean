using MathNet.Numerics;
using QLNet;
using QuantConnect;
using QuantConnect.Algorithm;
using QuantConnect.Data;
using QuantConnect.Data.Market;
using QuantConnect.Securities.Forex;
using System;
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
            SetStartDate(2014, 5, 1);  // Start date
            SetEndDate(2014, 5, 14); // End date
            SetCash(100000); // Starting cash in USD

            var forex = AddForex("EURUSD", Resolution.Tick, Market.Oanda);
            //var history = History<QuoteBar>(forex.Symbol, TimeSpan.FromDays(30));
        }

        /// <summary>
        /// Event handler for new data slices. This is where the main trading logic resides.
        /// </summary>
        /// <param name="data">Slice object keyed by symbol containing the stock data</param>
        public override void OnData(Slice data)
        {
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
