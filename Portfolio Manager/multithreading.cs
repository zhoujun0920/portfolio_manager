using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Portfolio_Manager
{
    class multithreading//this class is used for pass inputs and outputs in thread.
    {
        public Value underlyings { get; set; }
        public bool anti { get; set; }
        public string s { get; set; }
        public double[] price { get; set; }
        public double[] greeks { get; set; }
        public bool cv;
        public double[,] rand { get; set; }
        public double rebate { get; set; }
        public double barrier { get; set; }
        public string udio { get; set; }
        public string lookback { get; set; }
        public string type { get; set; }
        public multithreading(Value v,bool ant, string S,bool CV,string ty,double re,double B,string u,string lb)
        {
            underlyings = v;
            anti = ant;
            s = S;
            cv = CV;
            type = ty;
            barrier = B;
            udio = u;
            rebate = re;
            lookback = lb;
        }
    }



}
