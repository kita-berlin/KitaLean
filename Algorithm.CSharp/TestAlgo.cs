using MathNet.Numerics;
using QLNet;
using QuantConnect;
using QuantConnect.Algorithm;
using QuantConnect.Data;
using QuantConnect.Data.Market;
using QuantConnect.Securities.Forex;
using System;
using System.Linq;
using static QuantConnect.Messages;

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
            var start = new DateTime(2014, 5, 1);
            var end = DateTime.Now;
            SetStartDate(start);  // Start date
            SetEndDate(end); // End date
            SetCash(10_000); // Starting cash in USD

            var forex = AddForex("EUR_USD", Resolution.Tick, Market.Dukascopy);
            var history = History<Tick>(forex.Symbol, start, end);
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
