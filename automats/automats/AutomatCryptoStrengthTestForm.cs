using System;
using System.Windows.Forms;
using Dependencies;
using BLInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace PresentationLayer
{
    public partial class AutomatCryptoStrengthTestForm : InputAutomat
    {
        static ICryptoStrengthTestLogic cryptoStrengthTestLogicService;

        string AutomatStrengthTestInputString { get; set; }


        static AutomatCryptoStrengthTestForm()
        {
            cryptoStrengthTestLogicService = DependencyResolver.Instance.ServiceProvider.GetService<ICryptoStrengthTestLogic>();
        }
        
        public AutomatCryptoStrengthTestForm()
        {
            InitializeComponent();
        }

        private void inputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog k = new OpenFileDialog();

            if (k.ShowDialog() == DialogResult.OK)
            {
                AutomatStrengthTestInputString = k.FileName;

                strengthTestInputString.Text =  cryptoStrengthTestLogicService.ParseInputData(AutomatStrengthTestInputString);
            }
        }

        private void testSettings_Click(object sender, EventArgs e)
        {
            new TestSettingsForm().Show();
        }
        
        private void testStart_Click(object sender, EventArgs e)
        {
            cryptoStrengthTestLogicService.CheckTestDataStorageExistence();

            new StrengthTestResults(CurrentAutomat, cryptoStrengthTestLogicService.ParseInputData(AutomatStrengthTestInputString)).Show();
        }
    }
}
