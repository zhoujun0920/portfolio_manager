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
    public partial class Form2 : Form
    {
        static Portfolio_ManagerEntities portfolio = new Portfolio_ManagerEntities();
        public Form2()
        {
            InitializeComponent();
        }

        private void cancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add2_Click(object sender, EventArgs e)
        {
            try
            {
                InstType inst = new InstType();
                if (insttype2.Text != "" && underlying2.Text != "")
                {
                    inst.TypeName = insttype2.Text.ToString();
                    inst.Underlying = underlying2.Text.ToString();
                    portfolio.InstTypes.Add(inst);
                    portfolio.SaveChanges();
                    IQueryable<InstType> var = from p in portfolio.InstTypes
                                               orderby p.Id descending
                                               select p;
                    inst.Id = var.First().Id;//find the latest insttype you add
                    if (inst.TypeName.ToUpper() == "BARRIEROPION")//if you add barrieroption, you should also add wheather it is in out up down and its barrierprice
                    {
                        barrier2.ReadOnly = false;
                        up_in2.Enabled = true;
                        up_out2.Enabled = true;
                        down_in2.Enabled = true;
                        down_out2.Enabled = true;
                        BarrierOption bar = new BarrierOption();
                        bar.barrier = Convert.ToDouble(barrier2.Value);
                        bar.InstTypeId = inst.Id;
                        if (up_in2.Checked == true)
                        {
                            bar.IsIn = true;
                            bar.IsUp = true;
                        }
                        else if (down_in2.Checked == true)
                        {
                            bar.IsIn = true;
                            bar.IsUp = false;
                        }
                        else if (up_out2.Checked == true)
                        {
                            bar.IsIn = false;
                            bar.IsUp = true;
                        }
                        else if (down_out2.Checked == true)
                        {
                            bar.IsIn = false;
                            bar.IsUp = false;
                        }
                        portfolio.BarrierOptions.Add(bar);
                        portfolio.SaveChanges();
                    }
                    else if (insttype2.Text.ToUpper() == "DIGITALOPTION")//if you add digitaloption, you should also add its rebate price
                    {
                        rebate2.ReadOnly = false;
                        DigitalOption dig = new DigitalOption();
                        dig.rebate = Convert.ToDouble(rebate2.Value);
                        dig.InstTypeId = inst.Id;
                        portfolio.DigitalOptions.Add(dig);
                        portfolio.SaveChanges();
                    }
                    else if (insttype2.Text.ToUpper() == "LOOKBACKOPTION")//if you add lookbackoption, you should choose fixing or floating for payoff function
                    {
                        fix2.Enabled = true;
                        floating2.Enabled = true;
                        LookBackOption look = new LookBackOption();
                        if (fix2.Checked == true)
                            look.IsFixed = true;
                        else
                            look.IsFixed = false;
                        look.InstTypeId = inst.Id;
                        portfolio.LookBackOptions.Add(look);
                        portfolio.SaveChanges();
                    }
                    MessageBox.Show("Data added successfully", "Notice");
                    this.Close();

                }
                else
                    MessageBox.Show("Please input the TypeName and Underlying", "Notice");
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }

        private void insttype2_TextChanged(object sender, EventArgs e)//when the typename changed, make sure the toolbox is enable for exotic option
        {
            if (insttype2.Text.ToUpper() == "BARRIEROPTION")
            {
                barrier2.ReadOnly = false;
                up_in2.Enabled = true;
                up_out2.Enabled = true;
                down_in2.Enabled = true;
                down_out2.Enabled = true;

                rebate2.ReadOnly = true;

                fix2.Enabled = false;
                floating2.Enabled = false;
            }
            else if (insttype2.Text.ToUpper() == "DIGITALOPTION")
            {
                barrier2.ReadOnly = true;
                up_in2.Enabled = false;
                up_out2.Enabled = false;
                down_in2.Enabled = false;
                down_out2.Enabled = false;

                rebate2.ReadOnly = false;

                fix2.Enabled = false;
                floating2.Enabled = false;
            }
            else if (insttype2.Text.ToUpper() == "LOOKBACKOPTION")
            {
                fix2.Enabled = true;
                floating2.Enabled = true;

                barrier2.ReadOnly = true;
                up_in2.Enabled = false;
                up_out2.Enabled = false;
                down_in2.Enabled = false;
                down_out2.Enabled = false;

                rebate2.ReadOnly = true;
            }
            else
            {
                fix2.Enabled = false;
                floating2.Enabled = false;

                barrier2.ReadOnly = true;
                up_in2.Enabled = false;
                up_out2.Enabled = false;
                down_in2.Enabled = false;
                down_out2.Enabled = false;

                rebate2.ReadOnly = true;
            }
        }
    }
}
