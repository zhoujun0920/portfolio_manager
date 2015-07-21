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
    public partial class Form8 : Form
    {
        static Portfolio_ManagerEntities portfolio = new Portfolio_ManagerEntities();
        public Form8()
        {
            InitializeComponent();
            initial();
        }

        private void cancel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delete3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(id3.SelectedItem);

                foreach (Trade t in portfolio.Trades)//if you want to delete the instrument, you should first delete the trade first
                {
                    Trade tra = portfolio.Trades.Single(i => i.InstrumentId == id);
                    portfolio.Trades.Remove(tra);
                }
                foreach (Price p in portfolio.Prices)// you should delete the price secondly
                {
                    Price pri = portfolio.Prices.Single(i => i.InstrumentId == id);
                    portfolio.Prices.Remove(pri);
                }
                Instrument delete = portfolio.Instruments.Single(i => i.Id == id);
                portfolio.Instruments.Remove(delete);//finally delete the instrument
                portfolio.SaveChanges();
                MessageBox.Show("Delete data Successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }

        private void initial()
        {
            IQueryable<Instrument> var = from i in portfolio.Instruments
                                         select i;
            Instrument inst = var.First();
            foreach(Instrument i in var)//show the instrument you can delete or update
            {
                id3.Items.Add(i.Id);
            }
            id3.Text = id3.Items[0].ToString();
            companyname3.Text = inst.CompanyName;
            ticker3.Text = inst.Ticker;
            exchange3.Text = inst.Exchange;
            underlying3.Text = inst.Underlying;
            strike3.Text = inst.Strike.ToString();
            tenor3.Text = inst.Tenor.ToString();
            if (inst.IsCall == 0)
                call3.Checked = true;
            else if (inst.IsCall == 1)
                put3.Checked = true;
            else
                neither3.Checked = true;
            var v = (from i in portfolio.InstTypes
                     where i.Id == inst.InstTypeId
                     select i).First();
            insttype3.Text = v.TypeName;
        }

        private void update3_Click(object sender, EventArgs e)//update
        {
            try
            {
                string ticker = ticker3.Text, companyname = companyname3.Text, exchange = exchange3.Text, underlying = underlying3.Text, insttype = insttype3.Text;
                double strike = Convert.ToDouble(strike3.Text), tenor = Convert.ToDouble(tenor3.Text);
                int iscall = 0;
                if (call3.Checked == true)
                    iscall = 0;
                else if (put3.Checked == true)
                    iscall = 1;
                else
                    iscall = 2;
                int id = Convert.ToInt16(id3.SelectedItem);
                var inst = (from i in portfolio.Instruments
                            where i.Id == id
                            select i).First();
                inst.CompanyName = companyname;
                inst.Ticker = ticker;
                inst.Exchange = exchange;
                inst.Underlying = underlying;
                inst.Strike = strike;
                inst.Tenor = tenor;
                inst.IsCall = Convert.ToInt16(iscall);
                portfolio.SaveChanges();
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }

        private void id3_SelectedIndexChanged(object sender, EventArgs e)//change the inputs when you choose different instrument
        {
            try
            {
                int id = Convert.ToInt16(id3.SelectedItem);
                var inst = (from i in portfolio.Instruments
                            where i.Id == id
                            select i).First();
                companyname3.Text = inst.CompanyName;
                ticker3.Text = inst.Ticker;
                exchange3.Text = inst.Exchange;
                underlying3.Text = inst.Underlying;
                strike3.Text = inst.Strike.ToString();
                tenor3.Text = inst.Tenor.ToString();
                if (inst.IsCall == 0)
                    call3.Checked = true;
                else if (inst.IsCall == 1)
                    put3.Checked = true;
                else
                    neither3.Checked = true;
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }
    }
}
