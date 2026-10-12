using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicThread
{
    public partial class FrmBasicThread : Form
    {
        
        public FrmBasicThread()
        {
            InitializeComponent();
        }

        private void FrmBasicThread_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("-Before starting thread-");

            Thread threadA = new Thread(MyThreadClass.Thread1);
            Thread threadB = new Thread(MyThreadClass.Thread1);

            threadA.Name = "Thread A Process";
            threadB.Name = "Thread B Process";

            threadA.Start();
            threadB.Start();

            threadA.Join();
            threadB.Join();

            Console.WriteLine("-End of Thread-");
            label1.Text = "-End of Thread-";
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
