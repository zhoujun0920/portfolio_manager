using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using System.Threading;

namespace Portfolio_Manager
{
    public partial class Form11 : Form
    {
        static Portfolio_ManagerEntities portfolio = new Portfolio_ManagerEntities();
        public Form11()
        {
            InitializeComponent();
            label2.Text = System.Environment.ProcessorCount.ToString();
            step11.Value = 12;
            trail11.Value = 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (multi.Checked == true)
            {
                multithread2();
            }
            else
            {
                montecarlo();
            }
            this.Close();
        }

        private void montecarlo()//Monte Carlo Simulation
        {
            try
            {
                Form1 form1 = new Form1();
                double e = Convert.ToDouble(form1.volatility1.Value), d = Convert.ToDouble(form1.dividend1.Value);
                List<int> row = new List<int>();
                var inst = from i in portfolio.Trades
                           select i.Id;
                foreach (var i in inst)
                {
                    row.Add(i);
                }
                List<Basicvalue> basicvalue = new List<Basicvalue>();
                Basicvalue basic = new Basicvalue();
                for (int i = 0; i < row.Count; i++)//first find all the inputs I need from different table
                {
                    int oo = row[i];
                    var type = (from q in portfolio.InstTypes
                                join j in portfolio.Instruments on q.Id equals j.InstTypeId
                                join k in portfolio.Trades on j.Id equals k.InstrumentId
                                where k.Id == oo
                                select q.TypeName).First();//find the insttype
                    if (type.ToUpper() == "STOCK")//stock do not need to do simulation
                        break;
                    int n = row[i];
                    var inst2 = (from i2 in portfolio.Trades
                                 where i2.Id == n
                                 select i2).First();//find the historical price for this trade
                    basic.tradeprice = inst2.Price;
                    basic.S = Convert.ToDouble(inst2.UnderlyingP);
                    basic.instrumentid = inst2.InstrumentId;
                    basic.timestamp = inst2.Timestamp.ToString();
                    basic.quantity = Convert.ToDouble(inst2.Quantity);
                    var inst3 = (from i3 in portfolio.Instruments
                                 where i3.Id == basic.instrumentid
                                 select i3).First();//find the strike tenor call or put for the trade
                    basic.K = Convert.ToDouble(inst3.Strike);
                    basic.T = Convert.ToDouble(inst3.Tenor);
                    basic.iscall = Convert.ToInt16(inst3.IsCall);
                    basic.insttypeid = Convert.ToInt16(inst3.InstTypeId);

                    double ratetemp = new double();//store the risk free rate
                    List<double> rate = new List<double>();
                    var inst4 = from i4 in portfolio.InterestRates
                                orderby i4.Tenor ascending
                                select i4;
                    List<InterestRate> ir = new List<InterestRate>();
                    foreach (var g in inst4)
                    {
                        ir.Add(g);
                    }
                    int h = 0;
                    while (basic.T < ir[h].Tenor)//find out the interval of the T, and compute the rate
                        h++;
                    if (h == 0)
                    {
                        double r = Convert.ToDouble(ir[h].Rate);
                        double t = Convert.ToDouble(ir[h].Tenor);
                        ratetemp = basic.T / t * Convert.ToDouble(r);
                    }
                    else
                    {
                        double r1 = Convert.ToDouble(ir[h - 1].Rate), r2 = Convert.ToDouble(ir[h].Rate); ;
                        double t1 = Convert.ToDouble(ir[h - 1].Tenor), t2 = Convert.ToDouble(ir[h].Tenor);
                        ratetemp = r2 + (r2 - r1) / (t2 - t1) * (basic.T - t1);
                    }

                    basic.r = Convert.ToDouble(ratetemp);

                    var inst5 = (from i5 in portfolio.InstTypes
                                 where i5.Id == basic.insttypeid
                                 select i5).First();
                    basic.insttype = inst5.TypeName;
                    basic.underlying = inst5.Underlying;

                    if (basic.insttype == "BarrierOption")
                    {
                        var inst6 = (from i6 in portfolio.BarrierOptions
                                     where i6.InstTypeId == basic.insttypeid
                                     select i6).First();
                        basic.isup = Convert.ToBoolean(inst6.IsUp);
                        basic.isin = Convert.ToBoolean(inst6.IsIn);
                        basic.barrier = Convert.ToDouble(inst6.barrier);
                    }
                    else if (basic.insttype == "DigitalOption")
                    {
                        var inst7 = (from i7 in portfolio.DigitalOptions
                                     where i7.InstTypeId == basic.insttypeid
                                     select i7).First();
                        basic.rebate = Convert.ToDouble(inst7.rebate);
                    }
                    else if (basic.insttype == "LookBackOption")
                    {
                        var inst8 = (from i8 in portfolio.LookBackOptions
                                     where i8.InstTypeId == basic.insttypeid
                                     select i8).First();
                        basic.isfix = Convert.ToBoolean(inst8.IsFixed);
                    }

                    Value temp = new Value(basic.S, basic.K, basic.r, e, basic.T, d, Convert.ToInt64(step11.Value), Convert.ToInt64(trail11.Value));
                    Simulator sim = new Simulator(temp.S, temp.K, temp.r, temp.e, temp.T, temp.d, temp.step, temp.trial);
                    Option opt = new Option(temp.S, temp.K, temp.r, temp.e, temp.T, temp.d, temp.step, temp.trial);
                    Greeks gre = new Greeks(temp.S, temp.K, temp.r, temp.e, temp.T, temp.d, temp.step, temp.trial);
                    bool isant = true;
                    string s = null; ;//store the choice call or put option

                    string s3 = null;//up,down,in,out
                    string s4 = null;//fixed, floating

                    double[,] randmatrix = new double[temp.trial, temp.step];// store the random matrix
                    double[] origin_price = new double[2];//store the price and standard deviation
                    double[] greeks;//store the greeks

                    if (antithetic.Checked == true)
                        isant = true;
                    else
                        isant = false;

                    randmatrix = sim.generateregular();//generate the random matrix          

                    if (basic.iscall == 0)
                        s = "call";
                    else if (basic.iscall == 1)
                        s = "put";
                    else
                        s = "neither";

                    if (basic.isup == true && basic.isin == true)
                        s3 = "up_in";
                    else if (basic.isup == false && basic.isin == false)
                        s3 = "up_out";
                    else if (basic.isin == true && basic.isup == false)
                        s3 = "down_in";
                    else if (basic.isup == false && basic.isin == false)
                        s3 = "down_out";

                    if (basic.isfix == true)
                        s4 = "fix";
                    else
                        s4 = "floating";

                    switch (basic.insttype)
                    {
                        case "EuropeanOption":
                            European eur = new European(temp.S, temp.K, temp.r, temp.e, temp.T, temp.d, temp.step, temp.trial, dcv.Checked);
                            origin_price = eur.Payoff(temp, randmatrix, isant, s);//calculate the option price     
                            greeks = gre.calculate(temp, randmatrix, s, isant, eur.Payoff);//calculate the greeks
                            basic.mprice = origin_price[0];
                            basic.greek = greeks;
                            break;
                        case "AsianOption":
                            Asian asi = new Asian(temp.S, temp.K, temp.r, temp.e, temp.T, temp.d, temp.step, temp.trial, dcv.Checked);
                            origin_price = asi.Payoff(temp, randmatrix, isant, s);//calculate the option price     
                            greeks = gre.calculate(temp, randmatrix, s, isant, asi.Payoff);//calculate the greeks
                            basic.mprice = origin_price[0];
                            basic.greek = greeks;
                            break;
                        case "BarrierOption":
                            Barrier bar = new Barrier(temp.S, temp.K, temp.r, temp.e, temp.T, temp.d, temp.step, temp.trial, basic.barrier, s3, dcv.Checked);
                            origin_price = bar.Payoff(temp, randmatrix, isant, s);
                            greeks = gre.calculate(temp, randmatrix, s, isant, bar.Payoff);
                            basic.mprice = origin_price[0];
                            basic.greek = greeks;                      
                            break;
                        case "DigitalOption":
                            Digital dig = new Digital(temp.S, temp.K, temp.r, temp.e, temp.T, temp.d, temp.step, temp.trial, basic.rebate, dcv.Checked);
                            origin_price = dig.Payoff(temp, randmatrix, isant, s);
                            greeks = gre.calculate(temp, randmatrix, s, isant, dig.Payoff);
                            basic.mprice = origin_price[0];
                            basic.greek = greeks;
                            break;
                        case "LookbackOption":
                            LookBack look = new LookBack(temp.S, temp.K, temp.r, temp.e, temp.T, temp.d, temp.step, temp.trial, s4, dcv.Checked);
                            origin_price = look.Payoff(temp, randmatrix, isant, s);
                            greeks = gre.calculate(temp, randmatrix, s, isant, look.Payoff);
                            basic.mprice = origin_price[0];
                            basic.greek = greeks;
                            break;
                        case "RangeOption":
                            Range rang = new Range(temp.S, temp.K, temp.r, temp.e, temp.T, temp.d, temp.step, temp.trial);
                            origin_price = rang.Payoff(temp, randmatrix, isant, s);
                            greeks = gre.calculate(temp, randmatrix, s, isant, rang.Payoff);
                            basic.mprice = origin_price[0];
                            basic.greek = greeks;
                            break;
                    }
                    basic.pl = (basic.tradeprice - basic.mprice) * basic.quantity;
                    var update = (from u in portfolio.Trades
                                  where u.Id == n
                                  select u).First();//update the price and greeks in trade
                    update.MarketPrice = basic.mprice;
                    update.PL = basic.pl;
                    update.Delta = basic.greek[0];
                    update.Gamma = basic.greek[1];
                    update.Vega = basic.greek[2];
                    update.Theta = basic.greek[3];
                    update.Rho = basic.greek[4];

                    portfolio.SaveChanges();

                    basic = new Basicvalue();
                }
                this.Close();
                MessageBox.Show("Done! Please refresh the database again", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }

        private void multithread2()//multithreading for monte carlo simulation, method 2
        {
            int n = System.Environment.ProcessorCount;//the number of cores for CUP 
            Form1 form1 = new Form1();
            double e = Convert.ToDouble(form1.volatility1.Value), d = Convert.ToDouble(form1.dividend1.Value);
            List<int> row = new List<int>();
            var inst = from i in portfolio.Trades
                       select i.Id;
            foreach (var i in inst)
            {
                row.Add(i);
            }
            List<Basicvalue> basicvalue = new List<Basicvalue>();
            Basicvalue basic = new Basicvalue();
            for (int i = 0; i < row.Count; i++)
            {
                int m = row[i];
                var inst2 = (from i2 in portfolio.Trades
                             where i2.Id == m
                             select i2).First();
                basic.tradeprice = inst2.Price;
                basic.S = Convert.ToDouble(inst2.UnderlyingP);
                basic.instrumentid = inst2.InstrumentId;
                basic.timestamp = inst2.Timestamp.ToString();
                basic.quantity = Convert.ToDouble(inst2.Quantity);

                var inst3 = (from i3 in portfolio.Instruments
                             where i3.Id == basic.instrumentid
                             select i3).First();
                basic.K = Convert.ToDouble(inst3.Strike);
                basic.T = Convert.ToDouble(inst3.Tenor);
                basic.iscall = Convert.ToInt16(inst3.IsCall);
                basic.insttypeid = Convert.ToInt16(inst3.InstTypeId);

                double ratetemp = new double();
                List<double> rate = new List<double>();
                var inst4 = from i4 in portfolio.InterestRates
                            select i4;
                List<InterestRate> ir = new List<InterestRate>();
                foreach (var g in inst4)
                {
                    ir.Add(g);
                }
                int h = 0;
                while (basic.T < ir[h].Tenor)
                    h++;
                if (h == 0)
                {
                    double r = Convert.ToDouble(ir[h].Rate);
                    double t = Convert.ToDouble(ir[h].Tenor);
                    ratetemp = basic.T / t * Convert.ToDouble(r);
                }
                else
                {
                    double r1 = Convert.ToDouble(ir[h - 1].Rate), r2 = Convert.ToDouble(ir[h].Rate); ;
                    double t1 = Convert.ToDouble(ir[h - 1].Tenor), t2 = Convert.ToDouble(ir[h].Tenor);
                    ratetemp = r2 + (r2 - r1) / (t2 - t1) * (basic.T - t1);
                }

                basic.r = Convert.ToDouble(ratetemp);

                var inst5 = (from i5 in portfolio.InstTypes
                             where i5.Id == basic.insttypeid
                             select i5).First();
                basic.insttype = inst5.TypeName;
                basic.underlying = inst5.Underlying;

                if (basic.insttype == "BarrierOption")
                {
                    var inst6 = (from i6 in portfolio.BarrierOptions
                                 where i6.InstTypeId == basic.insttypeid
                                 select i6).First();
                    basic.isup = Convert.ToBoolean(inst6.IsUp);
                    basic.isin = Convert.ToBoolean(inst6.IsIn);
                    basic.barrier = Convert.ToDouble(inst6.barrier);
                }
                else if (basic.insttype == "DigitalOption")
                {
                    var inst7 = (from i7 in portfolio.DigitalOptions
                                 where i7.InstTypeId == basic.insttypeid
                                 select i7).First();
                    basic.rebate = Convert.ToDouble(inst7.rebate);
                }
                else if (basic.insttype == "LookBackOption")
                {
                    var inst8 = (from i8 in portfolio.LookBackOptions
                                 where i8.InstTypeId == basic.insttypeid
                                 select i8).First();
                    basic.isfix = Convert.ToBoolean(inst8.IsFixed);
                }
                if (n != 1)//If the number of core is not 2,4,8, change it to appropriate number
                {
                    if (n % 2 != 0 && n < 4 && n > 1)
                    {
                        n = 2;
                    }
                    else if (n % 4 != 0 && n < 8 && n > 3)
                    {
                        n = 4;
                    }
                    else if (n % 8 != 0 && n > 8)
                    {
                        n = 8;
                    }
                }
                string s, udio = null, lo;
                if (basic.iscall == 0)
                    s = "call";
                else if (basic.iscall == 1)
                    s = "put";
                else
                    s = "call";
                if (basic.isup == true && basic.isin == true)
                    udio = "up_in";
                else if (basic.isup == false && basic.isin == false)
                    udio = "up_out";
                else if (basic.isin == true && basic.isup == false)
                    udio = "down_in";
                else if (basic.isup == false && basic.isin == false)
                    udio = "down_out";

                if (basic.isfix == true)
                    lo = "fix";
                else
                    lo = "floating";
                if (n == 1)//no need to use multithread
                {
                    MessageBox.Show("CPU only have one core", "Information");
                }
                else
                {
                    double[] greeks = new double[5];
                    if (n == 2)//two cores
                    {
                        Value temp = new Value(basic.S, basic.K, basic.r, e, basic.T, d, Convert.ToInt64(step11.Value), Convert.ToInt64(trail11.Value));
                        multithreading mul = new multithreading(temp, antithetic.Checked, s, dcv.Checked, basic.insttype, basic.rebate, basic.barrier, udio, lo);
                        Simulator sim = new Simulator(temp.S, temp.K, temp.r, temp.e, temp.T, temp.d, temp.step, temp.trial);
                        Thread t1 = new Thread(new ParameterizedThreadStart(calc2));//This thread is to calculate the path and price
                        Thread t2 = new Thread(new ParameterizedThreadStart(sim.multiregualr));//This thread is to generate random numbers
                        t1.Name = "Thread_1";
                        t2.Name = "Thread_2";
                        t1.Start(mul);
                        t2.Start(mul);
                        t1.Join();
                        t2.Join();
                        for (int ii = 0; ii < 5; ii++)
                            greeks[ii] = (mul.greeks[ii]);
                        basic.mprice = mul.price[0];
                        basic.greek = greeks;
                    }
                    else if (n == 4)
                    {
                        Value temp = new Value(basic.S, basic.K, basic.r, e, basic.T, d, Convert.ToInt64(step11.Value), Convert.ToInt64(trail11.Value));
                        multithreading mul1 = new multithreading(temp, antithetic.Checked, s, dcv.Checked, basic.insttype, basic.rebate, basic.barrier, udio, lo);
                        multithreading mul2 = new multithreading(temp, antithetic.Checked, s, dcv.Checked, basic.insttype, basic.rebate, basic.barrier, udio, lo);
                        Simulator sim = new Simulator(temp.S, temp.K, temp.r, temp.e, temp.T, temp.d, temp.step, temp.trial);

                        Thread t21 = new Thread(new ParameterizedThreadStart(sim.multiregualr));//Generate random numbers
                        Thread t22 = new Thread(new ParameterizedThreadStart(sim.multiregualr));
                        Thread t11 = new Thread(new ParameterizedThreadStart(calc2));//Calculate the path and price
                        Thread t12 = new Thread(new ParameterizedThreadStart(calc2));

                        t11.Name = "Thread_11";
                        t12.Name = "Thread_12";
                        t21.Name = "Thread_21";
                        t22.Name = "Thread_22";
                        t21.Start(mul1);
                        t11.Start(mul1);
                        t21.Join();
                        t11.Join();
                        t22.Start(mul2);
                        t12.Start(mul2);
                        t22.Join();
                        t12.Join();

                        for (int ii = 0; ii < 5; ii++)
                            greeks[ii] = (mul1.greeks[ii] + mul2.greeks[ii]) * 0.5;
                        basic.mprice = mul1.price[0] + mul2.price[1];
                        basic.greek = greeks;
                    }
                    else if (n == 8)
                    {
                        Value temp = new Value(basic.S, basic.K, basic.r, e, basic.T, d, Convert.ToInt64(step11.Value), Convert.ToInt64(trail11.Value));
                        multithreading mul1 = new multithreading(temp, antithetic.Checked, s, dcv.Checked, basic.insttype, basic.rebate, basic.barrier, udio, lo);
                        multithreading mul2 = new multithreading(temp, antithetic.Checked, s, dcv.Checked, basic.insttype, basic.rebate, basic.barrier, udio, lo);
                        multithreading mul3 = new multithreading(temp, antithetic.Checked, s, dcv.Checked, basic.insttype, basic.rebate, basic.barrier, udio, lo);
                        multithreading mul4 = new multithreading(temp, antithetic.Checked, s, dcv.Checked, basic.insttype, basic.rebate, basic.barrier, udio, lo);
                        Simulator sim = new Simulator(temp.S, temp.K, temp.r, temp.e, temp.T, temp.d, temp.step, temp.trial);
                        Thread t51 = new Thread(new ParameterizedThreadStart(sim.multiregualr));//Generate random numbers
                        Thread t52 = new Thread(new ParameterizedThreadStart(sim.multiregualr));
                        Thread t31 = new Thread(new ParameterizedThreadStart(sim.multiregualr));
                        Thread t32 = new Thread(new ParameterizedThreadStart(sim.multiregualr));
                        Thread t21 = new Thread(new ParameterizedThreadStart(sim.multiregualr));
                        Thread t22 = new Thread(new ParameterizedThreadStart(sim.multiregualr));
                        Thread t11 = new Thread(new ParameterizedThreadStart(calc2));//Calculate path and price
                        Thread t12 = new Thread(new ParameterizedThreadStart(calc2));
                        Thread t41 = new Thread(new ParameterizedThreadStart(calc2));
                        Thread t42 = new Thread(new ParameterizedThreadStart(calc2));
                        Thread t61 = new Thread(new ParameterizedThreadStart(calc2));
                        Thread t62 = new Thread(new ParameterizedThreadStart(calc2));

                        t21.Start(mul1);
                        t11.Start(mul1);
                        t21.Join();
                        t11.Join();

                        t22.Start(mul2);
                        t12.Start(mul2);
                        t22.Join();
                        t12.Join();

                        t31.Start(mul3);
                        t41.Start(mul3);
                        t31.Join();
                        t41.Join();

                        t51.Start(mul4);
                        t61.Start(mul4);
                        t51.Join();
                        t61.Join();

                        for (int ii = 0; ii < 5; ii++)
                            greeks[ii] = (mul1.greeks[ii] + mul2.greeks[ii] + mul3.greeks[ii] + mul4.greeks[ii]) * 0.25;
                        basic.mprice = (mul1.price[0] + mul2.price[0] + mul3.price[0] + mul4.price[0]) * 0.25;
                        basic.greek = greeks;
                    }
                }
                basic.pl = (basic.tradeprice - basic.mprice) * basic.quantity;
                var update = (from u in portfolio.Trades
                              where u.Id == n
                              select u).First();
                update.PL = basic.pl;
                update.MarketPrice = basic.mprice;
                update.Delta = basic.greek[0];
                update.Gamma = basic.greek[1];
                update.Vega = basic.greek[2];
                update.Theta = basic.greek[3];
                update.Rho = basic.greek[4];
                portfolio.SaveChanges();
                basic = new Basicvalue();
            }
            MessageBox.Show("Done!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void calc2(object o)//use the object o as inputs and outputs, for method 1
        {
            multithreading m = (multithreading)o;
            Greeks gre = new Greeks(m.underlyings.S, m.underlyings.K, m.underlyings.r, m.underlyings.e, m.underlyings.T, m.underlyings.d, m.underlyings.step, m.underlyings.trial);          
            Monitor.Enter(m);//Ensure random number will generate before path.
            Thread.Sleep(5);//wait the random number start generate first

            if (m.type == "European")
            {
                European eur = new European(m.underlyings.S, m.underlyings.K, m.underlyings.r, m.underlyings.e, m.underlyings.T, m.underlyings.d, m.underlyings.step, m.underlyings.trial, m.cv);              
                m.price = eur.Payoff(m.underlyings, m.rand, m.anti, m.s);//calculate the option price     
                m.greeks = gre.calculate(m.underlyings, m.rand, m.s, m.anti, eur.Payoff);//calculate the greeks 
            }
            else if (m.type == "Asian")
            {
                Asian asi = new Asian(m.underlyings.S, m.underlyings.K, m.underlyings.r, m.underlyings.e, m.underlyings.T, m.underlyings.d, m.underlyings.step, m.underlyings.trial, m.cv);
                m.price = asi.Payoff(m.underlyings, m.rand, m.anti, m.s);//calculate the option price     
                m.greeks = gre.calculate(m.underlyings, m.rand, m.s, m.anti, asi.Payoff);//calculate the greeks
            }
            else if (m.type == "Barrier")
            {
                    Barrier bar = new Barrier(m.underlyings.S, m.underlyings.K, m.underlyings.r, m.underlyings.e, m.underlyings.T, m.underlyings.d, m.underlyings.step, m.underlyings.trial, m.barrier, m.udio, m.cv);
                    m.price = bar.Payoff(m.underlyings, m.rand, m.anti, m.s);//calculate the option price     
                    m.greeks = gre.calculate(m.underlyings, m.rand, m.s, m.anti, bar.Payoff);//calculate the greeks 
                
            }
            else if (m.type == "Digital")
            {
                Digital dig = new Digital(m.underlyings.S, m.underlyings.K, m.underlyings.r, m.underlyings.e, m.underlyings.T, m.underlyings.d, m.underlyings.step, m.underlyings.trial, m.rebate, m.cv);
                m.price = dig.Payoff(m.underlyings, m.rand, m.anti, m.s);//calculate the option price     
                m.greeks = gre.calculate(m.underlyings, m.rand, m.s, m.anti, dig.Payoff);//calculate the greeks 
            }
            else if (m.type == "Lookback")
            {
                LookBack look = new LookBack(m.underlyings.S, m.underlyings.K, m.underlyings.r, m.underlyings.e, m.underlyings.T, m.underlyings.d, m.underlyings.step, m.underlyings.trial, m.lookback, m.cv);
                m.price = look.Payoff(m.underlyings, m.rand, m.anti, m.s);//calculate the option price     
                m.greeks = gre.calculate(m.underlyings, m.rand, m.s, m.anti, look.Payoff);//calculate the greeks 
            }
            else if (m.type == "Range")
            {
                Range ran = new Range(m.underlyings.S, m.underlyings.K, m.underlyings.r, m.underlyings.e, m.underlyings.T, m.underlyings.d, m.underlyings.step, m.underlyings.trial);
                m.price = ran.Payoff(m.underlyings, m.rand, m.anti, m.s);//calculate the option price     
                m.greeks = gre.calculate(m.underlyings, m.rand, m.s, m.anti, ran.Payoff);//calculate the greeks 
            }
            Monitor.Exit(m);
        }       

    }
}
