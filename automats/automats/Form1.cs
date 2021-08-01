using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entities;
using CommonLogic;
using Dependencies;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        Automat currentAutomat;
        string fileName;
        List<string> inputSignalSet;
        List<int> inputCondSet;
        List<AutOptions> autG = new List<AutOptions>();
        bool isAutFirst;
        int automatNum = 0;
        ExecutionType execType;


        public Form1(bool autLevel, string file, ExecutionType executionType)
        {
            InitializeComponent();
            fileName = file;
            isAutFirst = autLevel;
            execType = executionType;

            if (executionType == ExecutionType.Experiment)
            {
                Text = "Проведение экспериментов над автоматом";

                richTextBox1.Hide();
                label1.Hide();
                label4.Hide();
                textBox1.Hide();
            }
            else
            {
                Text = "Моделирование работы автомата";

                labelExperimentType.Hide();
                radioButtonDiagnExp.Hide();
                radioButtonSetExp.Hide();
            }

            DataShow();
        }

        public Form1(bool autLevel, string file, List<AutOptions> auts, int autNum, StringBuilder outputs)
        {
            InitializeComponent();

            fileName = file;
            isAutFirst = autLevel;
            autG = auts;
            automatNum = autNum;

            button3.Hide();

            DataShow();
            Button ret = new Button();
            ret.Location = new Point(richTextBox3.Location.X + 5,
                richTextBox3.Location.Y + richTextBox3.Height + 20);
            ret.Size = new Size(richTextBox3.Location.X, 50);
            ret.Click += retClick;
            ret.Text = "Назад";
            Controls.Add(ret);

            if (autLevel)
            {
                AutOptions a = autG[automatNum];
                textBox2.Text = a.StartCondition.ToString();
                richTextBox1.Text = a.OutputSignals.ToString();
            }

            if (!autLevel)
            {
                textBox2.ReadOnly = true;
                richTextBox1.Text = outputs.ToString();
                richTextBox1.ReadOnly = true;
                button1.Hide();
                if (!string.IsNullOrEmpty(fileName))
                    button1_Click(currentAutomat.DeltaTable.GetLength(1), EventArgs.Empty);
            }
            if (!string.IsNullOrEmpty(richTextBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) &&
                !string.IsNullOrEmpty(fileName))
                button1_Click(fileName, EventArgs.Empty);
        }

        public void retClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text)
                && !string.IsNullOrEmpty(textBox2.Text))//По окончании работы автомата, добавляем выходные сигналы в файл,
                                                        //если авт-т не в 1 группе.
            {
                AutOptions a = autG[automatNum];
                if (isAutFirst)//Если автомат в 1ой группе, то сохраняем X & S0
                {
                    a.StartCondition = new StringBuilder(textBox2.Text);
                    a.InputSignals = new StringBuilder(richTextBox1.Text);
                }

                autG[automatNum] = a;
            }

            new Form3(autG).Show();

            this.Hide();
        }

        public void DataShow()
        {
            if (!string.IsNullOrEmpty(fileName))
                UpdateUserInterface(currentAutomat);
        }

        void SetExperimentInterface()
        {
            label2.Location = new Point(richTextBox3.Location.X + richTextBox3.Width + 30, richTextBox3.Location.Y);

            textBox2.Location = new Point(label2.Location.X + 40, label2.Location.Y + label2.Height + 20);

            button1.Location = new Point(textBox2.Location.X + 20, textBox2.Location.Y + textBox2.Height + 20);

            labelExperimentType.Location = new Point(label2.Location.X + label2.Width + 40, label2.Location.Y);

            radioButtonDiagnExp.Location = new Point(labelExperimentType.Location.X + 20, labelExperimentType.Location.Y + 30);

            radioButtonSetExp.Location = new Point(radioButtonDiagnExp.Location.X, radioButtonDiagnExp.Location.Y + 30);

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            DataShow();

            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Multiline = true;

            if (string.IsNullOrEmpty(fileName))
                MessageBox.Show("Добавьте автомат.");

            else
            {
                if (execType == ExecutionType.Modeling)
                {
                    if (!string.IsNullOrEmpty(richTextBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
                    {
                        inputCondSet = GetDistinctStartConditionsSet();

                        inputSignalSet = new List<string>();

                        try
                        {
                            int iterCounter = 0;

                            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                                int.TryParse(textBox1.Text, out iterCounter);

                            var data = DependencyResolver.Instance.AutomatModellingBL.ModelTheAutomatWork(GetDistinctStartConditionsSet(),
                                richTextBox1.Text.Split(FontLogic.spaceToSplit, StringSplitOptions.RemoveEmptyEntries).ToList(),
                                currentAutomat, iterCounter);

                            new Form4(data, execType).Show();

                            Refresh();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка при вводе!");
                        }
                    }
                    else
                        MessageBox.Show("Ошибка при вводе!");
                }
                else
                {
                    if (!string.IsNullOrEmpty(textBox2.Text.Trim()) && !string.IsNullOrEmpty(fileName))
                    {
                        if (radioButtonSetExp.Checked ^ radioButtonDiagnExp.Checked)
                        {
                            ExperimentType experimentType;

                            if (radioButtonDiagnExp.Checked)
                                experimentType = ExperimentType.Diagnostic;
                            else
                                experimentType = ExperimentType.Setting;

                            List<int> initialConditionsSet = new List<int>();

                            foreach (var item in textBox2.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                                initialConditionsSet.Add(int.Parse(item));

                            var data = DependencyResolver.Instance.AutomatExperimentLogic.StartTheExperiment(
                               initialConditionsSet, currentAutomat.DeltaTable, currentAutomat.LambdaTable, experimentType);

                            new Form4(data, execType).Show();
                        }
                        else
                            MessageBox.Show("Выберите тип эксперимента!");
                    }
                    else
                        MessageBox.Show("Ошибка при вводе!");
                }
            }
        }

        List<int> GetDistinctStartConditionsSet()
        {
            SortedSet<int> result = new SortedSet<int>();

            foreach (var item in textBox2.Text.Split(FontLogic.spaceToSplit, StringSplitOptions.RemoveEmptyEntries))
            {
                result.Add(int.Parse(item));
            }

            return result.ToList();
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
