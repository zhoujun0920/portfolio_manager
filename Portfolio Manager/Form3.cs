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
    public partial class Form3 : Form
    {
        static Portfolio_ManagerEntities portfolio = new Portfolio_ManagerEntities();
        public Form3()
        {
            InitializeComponent();
            initial();
            call3.Checked = true;
        }

        private void cancel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add3_Click(object sender, EventArgs e)
        {
            try
            {
                if (companyname3.Text != "" && ticker3.Text != "" && exchange3.Text != "")
                {
                    Instrument inst = new Instrument();
                    string type; //mySave;
                    inst.CompanyName = companyname3.Text;
                    inst.Ticker = ticker3.Text;
                    inst.Exchange = exchange3.Text;
                    inst.Underlying = label.Text;
                    inst.Strike = Convert.ToDouble(strike3.Value);
                    inst.Tenor = Convert.ToDouble(tenor3.Value);
                    if (call3.Checked == true)
                        inst.IsCall = 0;
                    else if (put3.Checked == true)
                        inst.IsCall = 1;
                    else
                        inst.IsCall = 2;
                    type = insttype3.SelectedItem.ToString();
                    IQueryable<InstType> temp = from p in portfolio.InstTypes
                                                where p.TypeName == type
                                                select p;//find out the intrument type id for new instrument
                    foreach (InstType i in temp)
                    {
                        if (i.TypeName == type)
                            inst.InstTypeId = i.Id;
                    }
                    portfolio.Instruments.Add(inst);
                    portfolio.SaveChanges();
                    MessageBox.Show("Data added successfully", "Notice");
                    this.Close();
                }
                else
                    MessageBox.Show("Please input the CompanyName, Ticker, Exchange", "Notice");
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }
        private void initial()
        {

            foreach (InstType i in portfolio.InstTypes)//show the insttype already existed in database 
            {
                insttype3.Items.Add(i.TypeName);
                //combobox3.Items.Add(i.Underlying);
            }
            insttype3.Text = insttype3.Items[0].ToString();
            var v = (from i in portfolio.InstTypes
                     select i.Underlying).First();
            label.Text = v;//show the underlying for the insttype
           
        }

        private void insttype3_SelectedIndexChanged(object sender, EventArgs e)//when insttype changed, underlying will change currently
        {
            List<InstType> inst = new List<InstType>();
            foreach (InstType i in portfolio.InstTypes)
            {
                inst.Add(i);
            }
            int id = insttype3.SelectedIndex;
            label.Text = inst[id].Underlying;
        }

    }
}
