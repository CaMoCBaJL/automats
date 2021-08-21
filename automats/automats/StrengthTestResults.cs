﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dependencies;
using Entities;
using CommonConstants;
using CommonLogic;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public partial class StrengthTestResults : Form
    {
        int labelCounter;

        Automat CurrentAutomat { get; }

        string InputString { get; }


        public StrengthTestResults(Automat automat, string inputString)
        {
            labelCounter = 0;

            CurrentAutomat = automat;

            InputString = inputString;

            InitializeComponent();
        }

        void StrengthTestResults_Load(object sender, EventArgs e)
        {
            fileSystemWatcher.Path = PathConstants.stengthTestDataFolder;

            DependencyResolver.Instance.BinaryCryptoStrengthTest.StartTest(CurrentAutomat, InputString,
                new List<string>(new string[] { "0", "1" }));
        }

        async void fileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            await Task.Run(() =>
            {
                testProgressBar.Value = (DependencyResolver.Instance.BinaryCryptoStrengthTest.GetExecutionStep()
                    / InputString.Length) * 100;

                labelCounter++;

                ShowCycle(DependencyResolver.Instance.BinaryCryptoStrengthTest.LoadNewCycleData(e.FullPath),
                    labelCounter);
            });
        }

        void ShowCycle(KeyValuePair<ModellingStepData, ModellingStepData> pair, int cycleNum)
        {
            string labelText;

            if (pair.Value.StepNumber - pair.Key.StepNumber < IntegerConstants.outputStringMaxLength)
                labelText = InputString.Substring(pair.Key.StepNumber, pair.Value.StepNumber - pair.Key.StepNumber);
            else
                labelText = InputString.Substring(pair.Key.StepNumber, IntegerConstants.outputStringMaxLength)
                    + StringConstants.threeDots;

            messagePanel.Invoke(new Action(() =>
            {
                messagePanel.Controls.Add(new Label()
                {
                    Location = DrawingLogic.CycleInfoLocation(cycleNum),

                    Text = ConstructLabelText(StringConstants.threeDots + labelText, pair.Key.StepNumber,
                    pair.Value.StepNumber),

                    AutoSize = true
                });

                messagePanel.Update();
            }));
        }

        string ConstructLabelText(string labelText, int firstStep, int secondStep)
            => new StringBuilder(StringConstants.cycleInfoFirstPart + firstStep +
                StringConstants.cycleInfoSecondPart +
                secondStep + StringConstants.cycleInfoThirdPart + Environment.NewLine +
                StringConstants.cycleInfoForthPart + labelText).ToString();

        private void StrengthTestResults_FormClosed(object sender, FormClosedEventArgs e)
        {
            DependencyResolver.Instance.BinaryCryptoStrengthTest.EndTest();
        }
    }
}
