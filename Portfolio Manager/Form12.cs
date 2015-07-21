using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Portfolio_Manager
{
    public partial class Form12 : Form
    {
        Portfolio_ManagerEntities portfolio = new Portfolio_ManagerEntities();
        public Form12()
        {
            InitializeComponent();
            initial();
        }

        private void ok12_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void initial()
        {
            List<string> inst = new List<string>();
            var tic = from i in portfolio.Instruments
                       select i.Ticker;
            foreach(var i in tic)
            {
                instrument12.Items.Add(i);
            }
            instrument12.Text = instrument12.Items[0].ToString();
        }

        private void refresh()
        {
            string instrument = instrument12.SelectedItem.ToString();
            int id = 0;
            List<Price> price = new List<Price>();
            var inst = (from i in portfolio.Instruments
                        where i.Ticker == instrument
                        select i.Id).First();
            id = inst;
            IQueryable<Price> p = (from i in portfolio.Prices
                                   where i.InstrumentId == id
                                   select i);
            foreach (Price i in p)
            {
                price.Add(i);
            }
            data12.DataSource = price;
            data12.Columns[4].Visible = false;
            data12.Columns[3].Visible = false;

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update12_Click(object sender, EventArgs e)
        {

        }

        private void instrument12_SelectedIndexChanged(object sender, EventArgs e)
        {
            string n=instrument12.SelectedItem.ToString();
            var v=from i in portfolio.Prices
                  join j in portfolio.Instruments on i.InstrumentId equals j.Id
                  where j.Ticker==n
                  select i;
            List<Price> p = new List<Price>();
            foreach (var i in v)
            {
                p.Add(i);
            }
            data12.DataSource = p;
            data12.Columns[4].Visible = false;
            data12.Columns[3].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p = from i in portfolio.Prices
                    select i;
            List<Price> price = new List<Price>();
            foreach(var i in p)
            {
                price.Add(i);
            }
            data12.DataSource = price;
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
}
