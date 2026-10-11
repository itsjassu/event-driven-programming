using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueueSystem
{
    public partial class CustomerView : Form
    {
        Timer timer = new Timer();
        public CustomerView()
        {
            InitializeComponent();

            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer1_tick);
            timer.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelDisplay_Click(object sender, EventArgs e)
        {

        }

        private void timer1_tick(object sender, EventArgs e)
        {
            if (CashierClass.CashierQueue != null)
            {
                if (CashierClass.CashierQueue.Contains(labelDisplay.Text))
                {
                    labelDisplay.Text = CashierClass.CashierQueue.Peek();
                }
                else
                {
                    if (CashierClass.CashierQueue.Count > 0)
                    {
                        labelDisplay.Text = CashierClass.CashierQueue.Peek();
                    }
                    else
                    {
                        labelDisplay.Text = "P - 00000";
                    }
                }
            }
        }
    }
}
