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
    
    public partial class Form10 : Form
    {
        static Portfolio_ManagerEntities portfolio = new Portfolio_ManagerEntities();
        public Form10()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testdata();
            testdata2();
            testdata3();
            testdata4();
            MessageBox.Show("Sample Data Inport Successed");
            this.Close();
        }
        private void testdata()
        {
            InstType eur = new InstType();
            eur.TypeName = "EuropeanOption";
            eur.Underlying = "MSFT";
            portfolio.InstTypes.Add(eur);
            portfolio.SaveChanges();
            InstType asi = new InstType();
            asi.TypeName = "AsianOption";
            asi.Underlying = "GOOG";
            portfolio.InstTypes.Add(asi);
            portfolio.SaveChanges();
            InstType bar = new InstType();
            bar.TypeName = "BarrierOption";
            bar.Underlying = "SINA";
            portfolio.InstTypes.Add(bar);
            portfolio.SaveChanges();
            var v1 = (from i in portfolio.InstTypes
                      where i.TypeName == "BarrierOption"
                      select i.Id).First();
            BarrierOption b = new BarrierOption();
            b.InstTypeId = v1;
            b.IsIn = true;
            b.IsUp = true;
            b.barrier = 60;
            portfolio.BarrierOptions.Add(b);
            portfolio.SaveChanges();
            InstType dig = new InstType();
            dig.TypeName = "DigitalOption";
            dig.Underlying = "WEBO";
            portfolio.InstTypes.Add(dig);
            portfolio.SaveChanges();
            var v2 = (from i in portfolio.InstTypes
                      where i.TypeName == "DigitalOption"
                      select i.Id).First();
            DigitalOption d = new DigitalOption();
            d.InstTypeId = v2;
            d.rebate = 50;
            portfolio.DigitalOptions.Add(d);
            portfolio.SaveChanges();
            InstType look = new InstType();
            look.TypeName = "LookBackOption";
            look.Underlying = "BAIDU";
            portfolio.InstTypes.Add(look);
            portfolio.SaveChanges();
            var v3 = (from i in portfolio.InstTypes
                      where i.TypeName == "LookBackOption"
                      select i.Id).First();
            LookBackOption l = new LookBackOption();
            l.InstTypeId = v3;
            l.IsFixed = true;
            portfolio.LookBackOptions.Add(l);
            portfolio.SaveChanges();
            InstType ran = new InstType();
            ran.TypeName = "RangeOption";
            ran.Underlying = "SOHU";
            portfolio.InstTypes.Add(ran);
            portfolio.SaveChanges();

            InstType sto = new InstType();
            sto.TypeName = "Stock";
            sto.Underlying = "MSFT";
            portfolio.InstTypes.Add(sto);
            portfolio.SaveChanges();
        }
        private void testdata2()
        {
            Instrument inst = new Instrument();
            inst.CompanyName = "MicroSoft";
            inst.Ticker = "MSFTC50Euro";
            inst.Underlying = "MSFT";
            inst.Strike = 50;
            inst.Tenor = 1;
            inst.IsCall = 0;
            var v = (from i in portfolio.InstTypes
                     where i.TypeName == "EuropeanOption"
                     select i.Id).First();
            inst.InstTypeId = v;
            portfolio.Instruments.Add(inst);
            portfolio.SaveChanges();

            Instrument inst2 = new Instrument();
            inst2.CompanyName = "Sina";
            inst2.Ticker = "SINAC50BARR";
            inst2.Underlying = "SINA";
            inst2.Strike = 50;
            inst2.Tenor = 1;
            inst2.IsCall = 0;
            var v2 = (from i in portfolio.InstTypes
                      where i.TypeName == "BarrierOption"
                      select i.Id).First();
            inst2.InstTypeId = v2;
            portfolio.Instruments.Add(inst2);
            portfolio.SaveChanges();

            Instrument inst3 = new Instrument();
            inst3.CompanyName = "MicroSoft";
            inst3.Ticker = "MSFT";
            inst3.Underlying = "MSFT";
            inst3.Strike = 50;
            inst3.Tenor = 1;
            inst3.IsCall = 0;
            var v3 = (from i in portfolio.InstTypes
                      where i.TypeName == "Stock"
                      select i.Id).First();
            inst3.InstTypeId = v3;
            portfolio.Instruments.Add(inst3);
            portfolio.SaveChanges();
        }
        private void testdata3()
        {
            Price p = new Price();
            p.ClosingPrice = 48;
            p.Timestamp = DateTime.Now.ToLongDateString();
            p.InstrumentId = (from i in portfolio.Instruments
                              where i.Ticker == "MSFTC50Euro"
                              select i.Id).First();
            portfolio.Prices.Add(p);
            portfolio.SaveChanges();

            Price p2 = new Price();
            p2.ClosingPrice = 49;
            p2.Timestamp = DateTime.Now.ToLongDateString();
            p2.InstrumentId = (from i in portfolio.Instruments
                               where i.Ticker == "SINAC50BARR"
                               select i.Id).First();
            portfolio.Prices.Add(p2);
            portfolio.SaveChanges();

            Price p3 = new Price();
            p3.ClosingPrice = 50;
            p3.Timestamp = DateTime.Now.ToLongDateString();
            p3.InstrumentId = (from i in portfolio.Instruments
                               join j in portfolio.InstTypes on i.InstTypeId equals j.Id
                               where j.TypeName == "Stock"
                               where i.Underlying == "MSFT"
                               select i.Id).First();
            portfolio.Prices.Add(p3);
            portfolio.SaveChanges();

        }

        private void testdata4()
        {
            InterestRate inte = new InterestRate();
            inte.Rate = 0.02;
            inte.Tenor = 0.25;
            portfolio.InterestRates.Add(inte);
            portfolio.SaveChanges();

            InterestRate inte2 = new InterestRate();
            inte2.Rate = 0.03;
            inte2.Tenor = 0.5;
            portfolio.InterestRates.Add(inte2);
            portfolio.SaveChanges();

            InterestRate inte3 = new InterestRate();
            inte3.Rate = 0.05;
            inte3.Tenor = 1;
            portfolio.InterestRates.Add(inte3);
            portfolio.SaveChanges();

            InterestRate inte4 = new InterestRate();
            inte4.Rate = 0.08;
            inte4.Tenor = 2;
            portfolio.InterestRates.Add(inte4);
            portfolio.SaveChanges();

            InterestRate inte5 = new InterestRate();
            inte5.Rate = 0.11;
            inte5.Tenor = 5;
            portfolio.InterestRates.Add(inte5);
            portfolio.SaveChanges();
        }
    }
}
