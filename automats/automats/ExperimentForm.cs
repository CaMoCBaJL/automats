using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Entities;
using BLInterfaces;
using Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace PresentationLayer
{
    public partial class ExperimentForm : InputAutomat
    {
        static IAutomatExperimentLogic automatExperimentLogicService;


        static ExperimentForm()
        {
            automatExperimentLogicService = DependencyResolver.Instance.ServiceProvider.GetService<IAutomatExperimentLogic>();
        }

        public ExperimentForm()
        {
            InitializeComponent();

            Text = "Проведение экспериментов над автоматом";

            SetExperimentInterface();
        }

        public void retClick(object sender, EventArgs e)
        {
            new AutomatChainModellingForm().Show();

            this.Hide();
        }

        void SetExperimentInterface()
        {
            label2.Location = new Point(richTextBox3.Location.X + richTextBox3.Width + 30, richTextBox3.Location.Y);

            startConditionsTextBox.Location = new Point(label2.Location.X + 40, label2.Location.Y + label2.Height + 20);

            button1.Location = new Point(startConditionsTextBox.Location.X + 20, startConditionsTextBox.Location.Y + startConditionsTextBox.Height + 20);

            labelExperimentType.Location = new Point(label2.Location.X + label2.Width + 40, label2.Location.Y);

            radioButtonDiagnExp.Location = new Point(labelExperimentType.Location.X + 20, labelExperimentType.Location.Y + 30);

            radioButtonSetExp.Location = new Point(radioButtonDiagnExp.Location.X, radioButtonDiagnExp.Location.Y + 30);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputFileName))
                MessageBox.Show("Добавьте автомат.");

            else
            {
                if (!string.IsNullOrEmpty(startConditionsTextBox.Text.Trim()) && !string.IsNullOrEmpty(InputFileName))
                {
                    if (radioButtonSetExp.Checked ^ radioButtonDiagnExp.Checked)
                    {
                        ExperimentType experimentType;

                        if (radioButtonDiagnExp.Checked)
                            experimentType = ExperimentType.Diagnostic;
                        else
                            experimentType = ExperimentType.Setting;

                        List<int> initialConditionsSet = new List<int>();

                        foreach (var item in startConditionsTextBox.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                            initialConditionsSet.Add(int.Parse(item));

                        var data = automatExperimentLogicService.StartTheExperiment(
                           initialConditionsSet, CurrentAutomat.DeltaTable, CurrentAutomat.LambdaTable, experimentType);

                        new DataVisualization(data, ExecutionType.Experiment).Show();
                    }
                    else
                        MessageBox.Show("Выберите тип эксперимента!");
                }
                else
                    MessageBox.Show("Ошибка при вводе!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            new Menu().Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => Environment.Exit(0);

    }
}
