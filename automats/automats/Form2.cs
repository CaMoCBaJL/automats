using System;
using System.Windows.Forms;
using Entities;

namespace PresentationLayer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ModellingForm(true, string.Empty, ExecutionType.Modeling).Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form3(this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ExperimentForm(true, string.Empty, ExecutionType.Experiment).Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
