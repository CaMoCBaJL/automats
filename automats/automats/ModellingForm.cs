﻿using System;
using CommonConstants;
using System.Linq;
using System.Windows.Forms;
using Entities;
using Dependencies;

namespace PresentationLayer
{
    public partial class ModellingForm : InputAutomat
    {
        string AutomatName { get; set; }


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
                new Form3().Show();
            else
                new Form2().Show();

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
                        int iterCounter = 0;

                        if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                            int.TryParse(textBox1.Text, out iterCounter);

                        var data = DependencyResolver.Instance.AutomatModellingBL.ModelTheAutomatWork(
                            DependencyResolver.Instance.AutomatModellingBL.GetDistinctStartConditionsSet(startConditionsTextBox.Text),
                            inputSignalsTextBox.Text.Split(SplitTemplates.spaceToSplit, StringSplitOptions.RemoveEmptyEntries).ToList(),
                            CurrentAutomat, iterCounter);

                        if (!DependencyResolver.Instance.BL.AddAutomatData(InputFileName,
                            DependencyResolver.Instance.AutomatModellingBL.CalculateInputSignals(inputSignalsTextBox.Text),
                            DependencyResolver.Instance.AutomatModellingBL.CalculateOutputSignals(data), AutomatName))
                            MessageBox.Show(OperationResultIndicators.savingError);

                        new Form4(data, ExecutionType.Modeling).Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            new Form2().Show();
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
    }
}