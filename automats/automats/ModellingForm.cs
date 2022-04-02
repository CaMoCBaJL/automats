using System;
using CommonConstants;
using System.Linq;
using System.Windows.Forms;
using Entities;
using Dependencies;
using BLInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace PresentationLayer
{
    public partial class ModellingForm : InputAutomat
    {
        string AutomatName { get; set; }

        static IAutomatModellingLogic modellingLogicService;

        static IDataProviderLogic dataProviderLogicService;

        static IAutomatChainModellingLogic automatChainModellingService;


        static ModellingForm()
        {
            modellingLogicService = DependencyResolver.Instance.ServiceProvider.GetService<IAutomatModellingLogic>();

            dataProviderLogicService = DependencyResolver.Instance.ServiceProvider.GetService<IDataProviderLogic>();

            automatChainModellingService = DependencyResolver.Instance.ServiceProvider.GetService<IAutomatChainModellingLogic>();
        }

        public ModellingForm()
        {
            InitializeComponent();

            AutomatName = string.Empty;

            Text = "Моделирование работы автомата";
        }

        public ModellingForm(string automatName)
        {
            InitializeComponent();

            AutomatName = automatName;

            Text = "Моделирование работы автомата";
        }

        public void retClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AutomatName))
                new AutomatChainModellingForm().Show();
            else
                new Menu().Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputSignalsTextBox.Multiline = true;

            if (string.IsNullOrEmpty(InputFileName))
                MessageBox.Show("Добавьте автомат.");

            else
            {
                if (!string.IsNullOrEmpty(inputSignalsTextBox.Text) && !string.IsNullOrEmpty(startConditionsTextBox.Text))
                {
                    try
                    {
                        int iterCounter = 1;

                        if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                            int.TryParse(textBox1.Text, out iterCounter);

                        var data = modellingLogicService.ModelTheAutomatWork(
                            modellingLogicService.GetDistinctStartConditionsSet(startConditionsTextBox.Text),
                            inputSignalsTextBox.Text.Split(SplitTemplates.spaceToSplit, StringSplitOptions.RemoveEmptyEntries).ToList(),
                            CurrentAutomat, iterCounter);

                        if (!dataProviderLogicService.AddAutomatData(InputFileName,
                            modellingLogicService.CalculateInputSignals(inputSignalsTextBox.Text),
                            modellingLogicService.CalculateOutputSignals(data), AutomatName,
                            modellingLogicService.CalculateStartConditions(data)))
                            MessageBox.Show(StringIndicators.savingError);

                        new DataVisualization(data, ExecutionType.Modeling).Show();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка при вводе!");
                    }
                }
                else
                    MessageBox.Show("Ошибка при вводе!");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => Environment.Exit(0);

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int result))
            {
                textBox1.Text = string.Empty;

                MessageBox.Show("Неверно введно число итераций");
            }
        }

        private void ModellingForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AutomatName))
            {
                if (automatChainModellingService.DidAutomatWork(AutomatName))
                {
                    var data = dataProviderLogicService.LoadAutomatSettings(AutomatName);

                    inputSignalsTextBox.Text = data.InputSignalString;

                    startConditionsTextBox.Text = data.StartConditionSet;

                    CurrentAutomat = dataProviderLogicService.ParseAutomatDataTables(data.AutomatDataFile);

                    UpdateUserInterface(CurrentAutomat);
                }

                if (automatChainModellingService.GetAutomatGroup(AutomatName) > 1)
                    inputSignalsTextBox.Text = automatChainModellingService.CalculateAutomatInputSignals(AutomatName);
            }
        }
    }
}
