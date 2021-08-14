using System;
using System.Windows.Forms;
using Dependencies;

namespace PresentationLayer
{
    public partial class AutomatCryptoStrengthTestForm : InputAutomat
    {
        string AutomatStrengthTestInputString { get; set; }

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

                strengthTestInputString.Text =  DependencyResolver.Instance.BinaryCryptoStrengthTest.ParseInputData(AutomatStrengthTestInputString);
            }
        }

        private void testSettings_Click(object sender, EventArgs e)
        {
            new TestSettingsForm().Show();
        }
        
        private void testStart_Click(object sender, EventArgs e)
        {
            new StrengthTestResults(CurrentAutomat, DependencyResolver.Instance.BinaryCryptoStrengthTest.ParseInputData(AutomatStrengthTestInputString)).Show();
        }
    }
}
