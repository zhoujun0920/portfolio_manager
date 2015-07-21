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

namespace Portfolio_Manager
{
    public partial class Form4 : Form
    {

        Portfolio_ManagerEntities portfolio = new Portfolio_ManagerEntities();
        public Form4()
        {
            InitializeComponent();
            buy4.Checked = true;
            try
            {
                initial();
            }
            catch
            {
                MessageBox.Show("Please add new historical price for the instruments first");
                this.Close();
            }
            timestamp4.Text = DateTime.Now.ToLongDateString();
        }

        private void cancel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add4_Click(object sender, EventArgs e)
        {
            try
            {
                Trade tra = new Trade();
                List<string> inst = new List<string>();
                List<int> instid = new List<int>();
                string inst2 = instrument4.SelectedItem.ToString();
                var n = (from i in portfolio.Instruments
                         where i.Ticker == inst2
                         select i.Id).First();//find out the instrument id for trade 

                var v = (from i in portfolio.Prices//find out the price for instrument
                         where i.InstrumentId == n
                         orderby i.Id descending
                         select i.ClosingPrice).First();

                price4.Text = v.ToString();
                foreach (Instrument i in portfolio.Instruments)
                {
                    inst.Add(i.Ticker);
                    instid.Add(i.InstTypeId);
                }
                tra.MarketPrice = 0;
                tra.IsBuy = buy4.Checked;
                tra.Quantity = Convert.ToDouble(quantity4.Value);
                tra.UnderlyingP = v;//Convert.ToDouble(underlyingprice.Value);
                tra.Price = Convert.ToDouble(tradeprice4.Value);
                tra.Timestamp = DateTime.Now.ToLongDateString();
                tra.PL = 0;

                tra.InstrumentId = Convert.ToInt16(n);
                Price p = new Price();
                p.ClosingPrice = tra.UnderlyingP;
                p.Timestamp = tra.Timestamp;
                p.InstrumentId = tra.InstrumentId;
                portfolio.Prices.Add(p);
                portfolio.SaveChanges();
                if (insttype4.Text == "Stock")//if the trade is stock, make the market price as underlying price ,delta=1 or -1
                {
                    tra.MarketPrice = tra.UnderlyingP;

                    if (tra.IsBuy == true)
                    {
                        tra.Delta = 1;
                        tra.PL = (tra.Price - (double)tra.MarketPrice)*tra.Quantity;
                    }
                    else
                    {
                        tra.Delta = -1;
                        tra.PL = ((double)tra.MarketPrice - tra.Price) * tra.Quantity;
                    }
                    tra.Gamma = 0;
                    tra.Theta = 0;
                    tra.Vega = 0;
                    tra.Rho = 0;
                }
                portfolio.Trades.Add(tra);
                portfolio.SaveChanges();
                MessageBox.Show("Data added successfully", "Notice");
                this.Close();
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }

        private void initial()
        {
            List<int> id = new List<int>();
            List<string> inst = new List<string>();
            List<int> instid = new List<int>();
            foreach(Instrument i in portfolio.Instruments)
            {
                id.Add(i.Id);
                inst.Add(i.Ticker);
                instid.Add(i.InstTypeId);
                instrument4.Items.Add(i.Ticker);
            }
            instrument4.DataSource = inst;
            int m = id[0];
            instrument4.Text = instrument4.Items[0].ToString();//show the instrument you can trade

            var v = (from i in portfolio.Prices
                     where i.InstrumentId == m
                     orderby i.Id descending
                     select i.ClosingPrice).First();
            price4.Text = v.ToString();//show the price for chosen instrument

            string inst2 = instrument4.SelectedItem.ToString();
            var n = (from i in portfolio.Instruments
                     where i.Ticker == inst2
                     select i.InstTypeId).First();
            IQueryable<InstType> var = from i in portfolio.InstTypes
                                     where i.Id == n
                                     select i;
            insttype4.Text = var.First().TypeName;//show the insttype for chosen instrument
        }

        private void instrument4_Click(object sender, EventArgs e)
        {
        }

        private void instrument4_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void instrument4_SelectedIndexChanged(object sender, EventArgs e)//when instrument changed, the price and insttype will change currently
        {
            try
            {
                string inst2 = instrument4.SelectedItem.ToString();
                var v = (from i in portfolio.Instruments
                         join j in portfolio.InstTypes on i.InstTypeId equals j.Id
                         where i.Ticker == inst2
                         select j.TypeName).First();
                insttype4.Text = v;
                var n = (from i in portfolio.Instruments
                         where i.Ticker == inst2
                         select i.Id).First();
                var v1 = (from i in portfolio.Prices
                          where i.InstrumentId == n
                          orderby i.Id descending
                          select i.ClosingPrice).First();
                price4.Text = v1.ToString();
            }
            catch { MessageBox.Show("Please add the historical price for option or stock"); }
        }




 
    }
}
