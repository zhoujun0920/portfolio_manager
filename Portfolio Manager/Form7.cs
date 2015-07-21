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
    public partial class Form7 : Form
    {
        static Portfolio_ManagerEntities portfolio = new Portfolio_ManagerEntities();
        public Form7()
        {
            InitializeComponent();
            initial();
        }

        private void dcancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delete2_Click(object sender, EventArgs e)//delete the insttype you choose
        {
            try
            {
                InstType inst = new InstType();
                inst.Id = Convert.ToInt16(id2.SelectedItem);
                inst.TypeName = insttype2.Text;
                inst.Underlying = underlying2.Text;
                var v = from i in portfolio.Instruments
                        where i.InstTypeId == inst.Id
                        select i;
                foreach (Instrument i in v)//if you want to delete a insttype, need delete all the instrumets, price and trade relate to the insttype
                {
                    var v2 = from j in portfolio.Trades
                             where j.InstrumentId == i.Id
                             select j;//first delete the trade
                    foreach (Trade j in v2)
                    {
                        Trade dele = portfolio.Trades.Single(k => k.Id == j.Id);
                        portfolio.Trades.Remove(dele);
                    }
                    var v3 = from l in portfolio.Prices
                             where l.InstrumentId == i.Id
                             select l;//second delte the price
                    foreach (Price m in v3)
                    {
                        Price dele2 = portfolio.Prices.Single(n => n.Id == m.Id);
                        portfolio.Prices.Remove(dele2);
                    }
                    Instrument dele3 = portfolio.Instruments.Single(p => p.Id == i.Id);
                    portfolio.Instruments.Remove(dele3);//then delete the instrument
                }
                InstType delete = portfolio.InstTypes.Single(i => i.Id == inst.Id);
                portfolio.InstTypes.Remove(delete);//finally delete the insttype
                portfolio.SaveChanges();

                if (inst.TypeName.ToUpper() == "BARRIEROPTION")//if you want to delete barrieroption, need to delte in barrieroption taple
                {
                    var v1 = from i in portfolio.BarrierOptions
                             where i.InstTypeId == inst.Id
                             select i;
                    int id = v1.First().Id;
                    BarrierOption delete1 = portfolio.BarrierOptions.Single(i => i.Id == id);
                    portfolio.BarrierOptions.Remove(delete1);
                    portfolio.SaveChanges();
                }
                else if (inst.TypeName.ToUpper() == "DIGITALOPTION")//if you want to delete digitaloption, need to delte in digitaloption taple
                {
                    var v2 = from i in portfolio.DigitalOptions
                             where i.InstTypeId == inst.Id
                             select i;
                    int id = v2.First().Id;
                    DigitalOption delete2 = portfolio.DigitalOptions.Single(i => i.Id == id);
                    portfolio.DigitalOptions.Remove(delete2);
                    portfolio.SaveChanges();
                }
                else if (inst.TypeName.ToUpper() == "LOOKBACKOPTION")//if you want to delete lookbackoption, need to delte in lookbackoption taple
                {
                    var v3 = from i in portfolio.LookBackOptions
                             where i.InstTypeId == inst.Id
                             select i;
                    int id = v3.First().Id;
                    LookBackOption delete3 = portfolio.LookBackOptions.Single(i => i.Id == id);
                    portfolio.LookBackOptions.Remove(delete3);
                    portfolio.SaveChanges();
                }

                MessageBox.Show("Delete data successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }
        private void initial()
        {
            try
            {
                foreach (InstType i in portfolio.InstTypes)//show the insttype you can delete or update
                {
                    id2.Items.Add(i.Id);
                }
                id2.Text = id2.Items[0].ToString();
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }

        private void back()
        {
            barrier2.ReadOnly = true;
            typeb.ReadOnly = true;
            rebate2.ReadOnly = true;
            typel.ReadOnly = true;
        }

        private void id2_SelectedIndexChanged(object sender, EventArgs e)//change the underlying and other inputs when you choose different insttype
        {
            try
            {
                int temp = Convert.ToInt16(id2.SelectedItem);
                string inst = null;
                string underlying = null;
                back();
                IQueryable<InstType> var = from i in portfolio.InstTypes
                                           where i.Id == temp
                                           select i;
                foreach (InstType i in var)
                {
                    inst = i.TypeName;
                    underlying = i.Underlying;
                }
                insttype2.Text = inst;
                underlying2.Text = underlying;
                if (inst.ToUpper() == "BARRIEROPTION")
                {
                    barrier2.ReadOnly = false;
                    typeb.ReadOnly = false;
                    double barrier = 0;
                    bool isup = true;
                    bool isin = true;
                    string type = null;
                    IQueryable<BarrierOption> var1 = from i in portfolio.BarrierOptions
                                                     where i.InstTypeId == temp
                                                     select i;
                    foreach (BarrierOption b in var1)
                    {
                        isup = Convert.ToBoolean(b.IsUp);
                        isin = Convert.ToBoolean(b.IsIn);
                        barrier = Convert.ToDouble(b.barrier);
                    }
                    insttype2.Text = inst;
                    underlying2.Text = underlying;
                    barrier2.Text = barrier.ToString();
                    if (isup == true && isin == true)
                        type = "up_in";
                    else if (isup == true && isin == false)
                        type = "up_out";
                    else if (isup == false && isin == true)
                        type = "down_in";
                    else
                        type = "down_out";
                    typeb.Text = type;
                }
                else if (inst.ToUpper() == "DIGITALOPTION")
                {
                    rebate2.ReadOnly = false;
                    double rebate = 0;
                    IQueryable<DigitalOption> var2 = from i in portfolio.DigitalOptions
                                                     where i.InstTypeId == temp
                                                     select i;
                    foreach (DigitalOption d in var2)
                    {
                        rebate = Convert.ToDouble(d.rebate);
                    }
                    rebate2.Text = rebate.ToString();
                    //myConnection.Close();
                }
                else if (inst.ToUpper() == "LOOKBACKOPTION")
                {
                    typel.ReadOnly = false;
                    bool isfix = true;
                    string type = null;
                    IQueryable<LookBackOption> var3 = from i in portfolio.LookBackOptions
                                                      where i.InstTypeId == temp
                                                      select i;
                    foreach (LookBackOption i in var3)
                    {
                        isfix = Convert.ToBoolean(i.IsFixed);
                    }
                    if (isfix == true)
                        type = "Fixed";
                    else
                        type = "Floating";
                    rebate2.Text = type;
                }
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }

        private void update2_Click(object sender, EventArgs e)//update the insttype you chose
        {
            try
            {
                string insttype = null, underlying = null, barriertype = null;
                insttype = insttype2.Text;
                underlying = underlying2.Text;
                int id = Convert.ToInt32(id2.SelectedItem.ToString());
                var inst = (from i in portfolio.InstTypes
                            where i.Id == id
                            select i).First();
                inst.TypeName = insttype;
                inst.Underlying = underlying;
                portfolio.SaveChanges();
                if (insttype2.Text.ToUpper() == "BARRIEROPTION")
                {
                    double barrier = Convert.ToDouble(barrier2.Text);
                    bool isup = true, isin = true;
                    if (typeb.Text == "up_in")
                    {
                        isup = true;
                        isin = true;
                    }
                    else if (typeb.Text == "up_out")
                    {
                        isup = true;
                        isin = false;
                    }
                    else if (typeb.Text == "down_in")
                    {
                        isup = false;
                        isin = true;
                    }
                    else if (typeb.Text == "down_out")
                    {
                        isup = false;
                        isin = false;
                    }
                    var inst2 = (from i in portfolio.BarrierOptions
                                 where i.InstTypeId == id
                                 select i).First();
                    inst2.IsUp = isup;
                    inst2.IsIn = isin;
                    inst2.barrier = barrier;
                    portfolio.SaveChanges();
                }
                else if (insttype2.Text.ToUpper() == "DIGITALOPTION")
                {
                    double rebate = Convert.ToDouble(rebate2.Text);
                    var inst3 = (from i in portfolio.DigitalOptions
                                 where i.InstTypeId == id
                                 select i).First();
                    inst3.rebate = rebate;
                    portfolio.SaveChanges();
                }
                else if (insttype2.Text.ToUpper() == "LOOKBACKOPTION")
                {
                    bool isfix = true;
                    barriertype = typeb.Text;
                    if (typel.Text == "Fixed")
                        isfix = true;
                    else
                        isfix = false;
                    var inst4 = (from i in portfolio.LookBackOptions
                                 where i.InstTypeId == id
                                 select i).First();
                    inst4.IsFixed = isfix;
                    portfolio.SaveChanges();
                }
            }
            catch { MessageBox.Show("Something wrong, please check wheather the inputs are correct."); }
        }
    }
}
