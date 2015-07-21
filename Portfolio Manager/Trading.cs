using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager
{
    class Trading
    {
        public int Id { get; set; }
        public int Instrumentid { get; set; }
        public Nullable<bool> IsBuy { get; set; }
        public double Quantity { get; set; }
        public string Ticker { get; set; }
        public string Typename { get; set; }
        public double TradePrice { get; set; }
        public double MarketPrice { get; set; }
        public Nullable<double> ClosingPrice { get; set; }
        public double PL { get; set; }
        public Nullable<double> Delta { get; set; }
        public Nullable<double> Gamma { get; set; }
        public Nullable<double> Vega { get; set; }
        public Nullable<double> Theta { get; set; }
        public Nullable<double> Rho { get; set; }
        public string Timestamp { get; set; }
    }
}
