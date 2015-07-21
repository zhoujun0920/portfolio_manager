using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_Manager
{
    class BaseUnderlying
    {
        public double S { get; set; }//underlying price
        public double K { set; get; }//strike price
        public double r { set; get; }//risk free rate
        public double e { set; get; }//volatility
        public double T { set; get; }//tenor
        public double d { set; get; }//divident
        public BaseUnderlying(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d)//constructor
        {
            S = S_S;
            K = K_K;
            r = r_r;
            e = e_e;
            T = T_T;
            d = d_d;
        }
    }
}
