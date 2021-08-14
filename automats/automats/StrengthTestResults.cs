using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dependencies;
using Entities;
using CommonConstants;
using System.Linq;
using CommonLogic;

namespace PresentationLayer
{
    public partial class StrengthTestResults : Form
    {
        Automat CurrentAutomat { get; }

        string InputString { get; }

        Dictionary<ModellingStepData, ModellingStepData> cryptoStrengthTestData;

        public StrengthTestResults(Automat automat, string inputString)
        {
            CurrentAutomat = automat;

            InputString = inputString;

            InitializeComponent();
        }

        void StrengthTestResults_Load(object sender, EventArgs e)
        {
            fileSystemWatcher.Path = PathConstants.stengthTestDataFolder;

            DependencyResolver.Instance.BinaryCryptoStrengthTest.StartTest(CurrentAutomat, InputString, new List<string>(new string[] { "0", "1" }));
        }

        void fileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            testProgressBar.Value = DependencyResolver.Instance.BinaryCryptoStrengthTest.GetExecutionStep() / InputString.Length;

            foreach (var pair in DependencyResolver.Instance.BinaryCryptoStrengthTest.LoadExecutionData())
            {
                if (!cryptoStrengthTestData.Contains(pair))
                {
                    ShowCycle(pair);

                    cryptoStrengthTestData.Add(pair.Key, pair.Value);
                }
            }
        }

        void ShowCycle(KeyValuePair<ModellingStepData, ModellingStepData> pair)
        {
            string labelText;

            if (pair.Value.StepNumber - pair.Key.StepNumber < IntegerConstants.outputStringMaxLength)
                labelText = InputString.Substring(pair.Key.StepNumber, pair.Value.StepNumber - pair.Key.StepNumber);
            else
                labelText = InputString.Substring(pair.Key.StepNumber, IntegerConstants.outputStringMaxLength) + StringConstants.threeDots;

            Controls.Add(new Label()
            {
                Location = DrawingLogic.CycleInfoLocation(cryptoStrengthTestData.Count + 1),

                Text = StringConstants.threeDots + labelText
            }); 
        }
    }
}
