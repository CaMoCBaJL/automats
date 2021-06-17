using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automats
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            StreamWriter contentRefresh = new StreamWriter("ABT.txt", false);
            contentRefresh.Write(string.Empty);
            contentRefresh.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1(true, string.Empty, ExecutionType.Modeling).Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form3(this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1(true, string.Empty, ExecutionType.Experiment).Show();

        }
    }
}
