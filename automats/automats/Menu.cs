using System;
using System.Windows.Forms;
using CommonConstants;
using Dependencies;

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

            if (DependencyResolver.Instance.ChainModellingBL.IsChainModellingModeActive())
            {
                if (MessageBox.Show(StringIndicators.resumeTheWorkDialogue,
                MessageBoxTitles.chooseAction, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    == DialogResult.No)
                {
                    DependencyResolver.Instance.ChainModellingBL.EndAutomatChainModelling();

                    DependencyResolver.Instance.ChainModellingBL.StartAutomatChainModelling();
                }
            }

            new AutomatChainModellingForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ExperimentForm().Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            new AutomatCryptoStrengthTestForm().Show();
        }
    }
}
