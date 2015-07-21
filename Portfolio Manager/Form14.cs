using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portfolio_Manager
{
    public partial class Form14 : Form
    {
        static Portfolio_ManagerEntities portfolio = new Portfolio_ManagerEntities();
        public Form14()
        {
            InitializeComponent();
            initial();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(id4.SelectedItem);
            Trade tra = portfolio.Trades.Single(i => i.InstrumentId == id);
            portfolio.Trades.Remove(tra);
        }

        private void initial()
        {
            var v = from i in portfolio.Trades
                    select i.Id;
            foreach (var i in v)
            {
                id4.Items.Add(i);
            }
            id4.Text = id4.Items[0].ToString();
            int id = Convert.ToInt16(id4.Items[0]);
            var v2 = (from i in portfolio.Trades
                      where i.Id == id
                      select i).First();
            price4.Text = v2.UnderlyingP.ToString();
            tradeprice4.Value = Convert.ToDecimal(v2.Price);
            quantity4.Value = Convert.ToDecimal(v2.Quantity);
            if (v2.IsBuy == true)
                buy4.Checked = true;
            else
                sale4.Checked = true;
            timestamp4.Text = v2.Timestamp;
            var v3 = (from i in portfolio.InstTypes
                      join j in portfolio.Instruments on i.Id equals j.InstTypeId
                      join k in portfolio.Trades on j.Id equals k.InstrumentId
                      where k.Id == id
                      select i.TypeName).First();
            var v4 = (from i in portfolio.Instruments
                      join j in portfolio.Trades on i.Id equals j.InstrumentId
                      where j.Id == id
                      select i.Ticker).First();
            instrument4.Text = v4;
            insttype4.Text = v3;
                   
        }

        private void id4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(id4.SelectedItem);
            var v2 = (from i in portfolio.Trades
                      where i.Id == id
                      select i).First();
            price4.Text = v2.UnderlyingP.ToString();
            tradeprice4.Value = Convert.ToDecimal(v2.Price);
            quantity4.Value = Convert.ToDecimal(v2.Quantity);
            if (v2.IsBuy == true)
                buy4.Checked = true;
            else
                sale4.Checked = true;
            timestamp4.Text = v2.Timestamp;
            var v3 = (from i in portfolio.InstTypes
                      join j in portfolio.Instruments on i.Id equals j.InstTypeId
                      join k in portfolio.Trades on j.Id equals k.InstrumentId
                      where k.Id == id
                      select i.TypeName).First();
            var v4 = (from i in portfolio.Instruments
                      join j in portfolio.Trades on i.Id equals j.InstrumentId
                      where j.Id == id
                      select i.Ticker).First();
            instrument4.Text = v4;
            insttype4.Text = v3;
        }
    }
}
