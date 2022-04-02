using System;
using System.Windows.Forms;
using CommonConstants;
using Dependencies;
using BLInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace PresentationLayer
{
    public partial class Menu : Form
    {
        static IAutomatChainModellingLogic automatChainModellingLogicService;


        static Menu()
        {
            automatChainModellingLogicService = DependencyResolver.Instance.ServiceProvider.GetService<IAutomatChainModellingLogic>();
        }

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

            if (automatChainModellingLogicService.IsChainModellingModeActive())
            {
                if (MessageBox.Show(StringIndicators.resumeTheWorkDialogue,
                MessageBoxTitles.chooseAction, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    == DialogResult.No)
                {
                    automatChainModellingLogicService.EndAutomatChainModelling();

                    automatChainModellingLogicService.StartAutomatChainModelling();
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
