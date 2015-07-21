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


//I used two way to achieve the goal, one is SQLCommand, the other is LINQ.
//LINQ is more concise than SQLCommand, so I comment all the code for SQLCommand and made the code not very readable


namespace Portfolio_Manager
{
    public partial class Form1 : Form
    {
        static Portfolio_ManagerEntities portfolio = new Portfolio_ManagerEntities();
        public Form1()
        {
            InitializeComponent();
            volatility1.Value = Convert.ToDecimal( 0.05);             
        }

        private void instrumentTypeToolStripMenuItem_Click(object sender, EventArgs e)//new inst type
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void instrumentToolStripMenuItem_Click(object sender, EventArgs e)//new instrument
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void tradeToolStripMenuItem_Click(object sender, EventArgs e)//new trade
        {
            Form4 form4 = new Form4();
            form4.Show();          
        }

        private void interestRateToolStripMenuItem_Click(object sender, EventArgs e)//new interest rate
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void historicalPriceToolStripMenuItem_Click(object sender, EventArgs e)//new historical price
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void instTypeToolStripMenuItem_Click(object sender, EventArgs e)//delete inst type
        {
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void instrumentToolStripMenuItem1_Click(object sender, EventArgs e)//delete istrument
        {
            Form8 form8 = new Form8();
            form8.Show();
        }

        private void interestRateToolStripMenuItem1_Click(object sender, EventArgs e)//delete interest rate
        {
            Form9 form9 = new Form9();
            form9.Show();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)//exit the program
        {
            this.Close();
        }

        private void priceAnalysisToolStripMenuItem_Click(object sender, EventArgs e)//analysis and update the price
        {
            Form12 form12 = new Form12();
            form12.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                refreshdata2();
                refreshdata1();
            }
            catch 
            {
                MessageBox.Show("Something wrong, please check wheather the inputs are correct.");
            }
        }

        private void simulatePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
        }
        private void refreshdata1()
        {
            List<Totaltrade> total = new List<Totaltrade>();
            Totaltrade temp=new Totaltrade();
            Totaltrade result = new Totaltrade();
            var v = from i in portfolio.Trades
                    select i;
            foreach(var i in v)
            {
                temp.Tpl = Convert.ToDouble(i.PL);
                temp.Tdelta = Convert.ToDouble(i.Delta);
                temp.Tgamma = Convert.ToDouble(i.Gamma);
                temp.Tvega = Convert.ToDouble(i.Vega);
                temp.Ttheta = Convert.ToDouble(i.Theta);
                temp.Trho = Convert.ToDouble(i.Rho);
                total.Add(temp);
                temp = new Totaltrade();
            }
            for (int i = 0; i < total.Count; i++)
            {
                result.Tpl = result.Tpl + total[i].Tpl;
                result.Tdelta = result.Tdelta + total[i].Tdelta;
                result.Tgamma = result.Tgamma + total[i].Tgamma;
                result.Tvega = result.Tvega + total[i].Tvega;
                result.Ttheta = result.Ttheta + total[i].Ttheta;
                result.Trho = result.Trho + total[i].Trho;
            }
            List<Totaltrade> t=new List<Totaltrade>();
            t.Add(result);
            data1.DataSource = t;
        }

        private void refreshdata2()
        {
            List<Trading> trading = new List<Trading>();
            Trading temp=new Trading();
            var v = from i in portfolio.Trades
                    join j in portfolio.Instruments on i.InstrumentId equals j.Id
                    join k in portfolio.InstTypes on j.InstTypeId equals k.Id
                    
                    select new Trading
                    {
                        Id = i.Id,
                        IsBuy = i.IsBuy,
                        Quantity = i.Quantity,
                        Ticker = j.Ticker,
                        Typename = k.TypeName,
                        MarketPrice=(double)i.MarketPrice,
                        TradePrice = i.Price,
                        ClosingPrice=0,
                        PL = i.PL,
                        Delta = i.Delta,
                        Gamma = i.Gamma,
                        Vega = i.Vega,
                        Theta = i.Theta,
                        Rho = i.Rho,
                        Timestamp = i.Timestamp,
                        Instrumentid=i.InstrumentId
                    };
            
            foreach(Trading i in v)
            {
                int id = i.Instrumentid;
                var v2 = (from i2 in portfolio.Prices
                          where i2.InstrumentId == id
                          orderby i2.Id descending
                          select i2.ClosingPrice).First();
                i.ClosingPrice = v2;
                trading.Add(i);
            }
            
                   
            data2.DataSource = trading;
            data2.Columns[1].Visible = false;
        }



        private void sampleDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
        }

        private void version10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.Show();
        }

        private void tradeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();
            form14.Show();
        }
       
    }
}
