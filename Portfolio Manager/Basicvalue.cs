using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager
{
    class Basicvalue
    {
        public double S { get; set; }
        public double K { get; set; }
        public double r { get; set; }
        public double T { get; set; }
        public double barrier { get; set; }
        public double rebate { get; set; }
        public double pl { get; set; }
        public double mprice { get; set; }
        public double underlyingprice { get; set; }
        public double tradeprice { get; set; }
        public double quantity { get; set; }
        public double[] greek { get; set; }
        public bool isin { get; set; }
        public bool isup { get; set; }
        public bool isfix { get; set; }
        public int iscall { get; set; }
        public int instrumentid { get; set; }
        public int insttypeid { get; set; }
        public string underlying { get; set; }
        public string insttype { get; set; }
        public string timestamp { get; set; }

    }
}
