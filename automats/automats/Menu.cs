using System;
using System.Windows.Forms;
using Entities;

namespace PresentationLayer
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ModellingForm().Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AutomatChainModellingForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ExperimentForm().Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
