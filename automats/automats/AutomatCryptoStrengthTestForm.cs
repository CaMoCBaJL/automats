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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog k = new OpenFileDialog();

            k.Filter = "Text Files(*.txt)|*.txt";

            if (k.ShowDialog() == DialogResult.OK)
            {
                AutomatStrengthTestInputString = k.FileName;

                CurrentAutomat = DependencyResolver.Instance.BL.ParseAutomatDataTables(InputFileName);

                UpdateUserInterface(CurrentAutomat);
            }
        }
    }
}
