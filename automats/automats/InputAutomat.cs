using CommonLogic;
using Entities;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dependencies;
using BLInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace PresentationLayer
{
    public partial class InputAutomat : Form
    {
        static IDataProviderLogic dataProviderService;

        protected Automat CurrentAutomat { get; set; }

        protected string InputFileName { get; set; }


        static InputAutomat()
        {
            dataProviderService = DependencyResolver.Instance.ServiceProvider.GetService<IDataProviderLogic>();
        }

        public InputAutomat()
        {
            InitializeComponent();
        }

        private void insertAut_Click(object sender, EventArgs e)
        {
            OpenFileDialog k = new OpenFileDialog();

            k.Filter = "Text Files(*.txt)|*.txt";

            if (k.ShowDialog() == DialogResult.OK)
            {
                InputFileName = k.FileName;

                CurrentAutomat = dataProviderService.ParseAutomatDataTables(InputFileName);

                UpdateUserInterface(CurrentAutomat);
            }
        }

        protected void UpdateUserInterface(Automat automat)
        {
            int condNum = automat.DeltaTable.GetLength(0);

            int inputNum = automat.DeltaTable.GetLength(1);

            int outputNum = automat.LambdaTable.GetLength(1);

            CalculateElementsSizes(condNum, inputNum, outputNum);

            UpdateRichTextBox3(condNum, inputNum, outputNum);

            UpdateRichTextBox4(inputNum, outputNum);
        }

        void CalculateElementsSizes(int condNum, int inputNum, int outputNum)
        {
            if (FontLogic.columnWidth * (inputNum + outputNum + 1) > 235)
                richTextBox3.Width = 240;
            else
                richTextBox3.Width = FontLogic.columnWidth * (inputNum + outputNum + 1);

            if ((condNum + 1) * 48 > 280)
                richTextBox3.Height = 280;
            else
                richTextBox3.Height = (condNum + 1) * 48;
        }

        void UpdateRichTextBox3(int condNum, int inputNum, int outputNum)
        {
            StringBuilder richTextBox3Content = new StringBuilder();

            for (int i = 0; i < condNum; i++)
            {
                if (i > 0)
                    richTextBox3Content.Append(Environment.NewLine);

                richTextBox3Content.Append(i + 1);

                for (int j = 0; j < inputNum; j++)
                    richTextBox3Content.Append("\t" + CurrentAutomat.DeltaTable[i, j]);

                for (int j = 0; j < outputNum; j++)
                    richTextBox3Content.Append("\t" + CurrentAutomat.LambdaTable[i, j]);
            }

            richTextBox3.Text = richTextBox3Content.ToString();
        }

        void UpdateRichTextBox4(int inputNum, int outputNum)
        {
            richTextBox4.Width = richTextBox3.Location.X + richTextBox3.Width - richTextBox4.Location.X;

            StringBuilder richTextBox4Content = new StringBuilder();

            richTextBox4Content.Append(AddSignalIndication(inputNum));

            richTextBox4Content.Append(AddSignalIndication(outputNum));

            richTextBox4.Text = richTextBox4Content.ToString();
        }

        string AddSignalIndication(int number)
        {
            StringBuilder str = new StringBuilder();

            foreach (var item in Enumerable.Range(0, number))
            {
                str.Append(item);

                str.Append("\t");
            }

            return str.ToString();
        }
    }
}
