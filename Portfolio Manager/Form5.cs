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
    public partial class Form5 : Form
    {
        static Portfolio_ManagerEntities portfolio = new Portfolio_ManagerEntities();
        public Form5()
        {
            InitializeComponent();
        }

        private void cancel5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok5_Click(object sender, EventArgs e)
        {
            InterestRate inte = new InterestRate();
            inte.Tenor = Convert.ToDouble(tenor5.Value);
            inte.Rate = Convert.ToDouble(rate5.Value);
            portfolio.InterestRates.Add(inte);
            portfolio.SaveChanges();
            MessageBox.Show("Data added successfully", "Notice");
            this.Close();
        }
    }
}
