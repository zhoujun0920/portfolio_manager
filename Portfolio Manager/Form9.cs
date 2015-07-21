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
    public partial class Form9 : Form
    {
        static Portfolio_ManagerEntities portfolio = new Portfolio_ManagerEntities();
        public Form9()
        {
            InitializeComponent();
            initial();
        }

        private void cancel5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(id5.SelectedItem);
                Price pri = portfolio.Prices.Single(i => i.Id == id);
                portfolio.Prices.Remove(pri);
                portfolio.SaveChanges();
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }
        private void initial()
        {
            var inst = from i in portfolio.InterestRates
                       select i;
            InterestRate r = inst.First();
            foreach(var i in inst)
            {
                id5.Items.Add(i.Id);
            }
            id5.Text = id5.Items[0].ToString();
            tenor5.Text = r.Tenor.ToString();
            rate5.Text = r.Rate.ToString();
        }

        private void update5_Click(object sender, EventArgs e)
        {
            try
            {
                double tenor = Convert.ToDouble(tenor5.Text), rate = Convert.ToDouble(rate5.Text);
                int id = Convert.ToInt16(id5.SelectedItem);
                var inst = (from i in portfolio.InterestRates
                            where i.Id == id
                            select i).First();
                inst.Rate = rate;
                inst.Id = id;
                portfolio.SaveChanges();
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }

        private void id5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(id5.SelectedItem);
                var r = (from i in portfolio.InterestRates
                         where i.Id == id
                         select i).First();
                tenor5.Text = r.Tenor.ToString();
                rate5.Text = r.Rate.ToString();
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }
    }
}
