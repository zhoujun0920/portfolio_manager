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
    public partial class Form6 : Form
    {
        Portfolio_ManagerEntities portfolio = new Portfolio_ManagerEntities();
        public Form6()
        {
            InitializeComponent();
            initial();
            timestamp6.Text = DateTime.Now.ToLongDateString();
        }

        private void cancel6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add6_Click(object sender, EventArgs e)
        {
            try
            {
                int n = 0;
                Price pri = new Price();
                List<string> inst = new List<string>();
                List<int> id = new List<int>();
                foreach (Instrument i in portfolio.Instruments)//find the id and ticker the instrument you chose
                {
                    inst.Add(i.Ticker);
                    id.Add(i.Id);
                }
                while (instrument6.SelectedItem.ToString() != inst[n])
                    n++;
                pri.ClosingPrice = Convert.ToDouble(price6.Value);
                pri.Timestamp = DateTime.Now.ToLongDateString();
                pri.InstrumentId = Convert.ToInt16(id[n]);
                portfolio.Prices.Add(pri);
                portfolio.SaveChanges();
                MessageBox.Show("Data added successfully", "Notice");
                this.Close();
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }

        private void initial()
        {
            foreach(Instrument i in portfolio.Instruments)//show the instrument you can add price for
            {
                instrument6.Items.Add(i.Ticker);
            }
            instrument6.Text = instrument6.Items[0].ToString();
        }
    }
}
