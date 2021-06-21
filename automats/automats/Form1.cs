using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutomatExperiments;

namespace automats
{
    public partial class Form1 : Form
    {
        const int columnWidth = 60;
        char[] spaceToSplit = new char[] { ' ' };

        string fileName;
        int condNum;
        int inputNum;
        int outputNum;
        int[,] condTable;
        string[,] outputTable;
        int[,] deltaRes; //результат работы для автомата(состояния).
        string[,] lambdaRes; //результат работы для автомата(выходы).
        List<string> inputSignalSet;
        List<string> inputCondSet;
        List<AutOptions> autG = new List<AutOptions>();
        bool isAutFirst;
        int automatNum = 0;
        PictureBox pictureBox1;
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
                richTextBox2.Hide();
                label3.Hide();
                label1.Hide();
                label4.Hide();
                textBox1.Hide();
                panel1.Hide();
                UpdateUi();
            }
            else
            {
                Text = "Моделирование работы автомата";

                labelExperimentType.Hide();
                radioButtonDiagnExp.Hide();
                radioButtonSetExp.Hide();
            }

            pictureBox1 = new PictureBox();
            pictureBox1.Paint += pictureBox1_Paint;
            panel1.Controls.Add(pictureBox1);
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
            pictureBox1 = new PictureBox();
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            panel1.Controls.Add(pictureBox1);
            
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
                AutOptions a =  autG[automatNum];
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
                    button1_Click(inputNum, EventArgs.Empty);
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
                for (int i = 0; i < inputCondSet.Count; i++)
                {
                    for (int j = 0; j < inputSignalSet.Count; j++)
                    {
                        a.OutputSignals.Append(lambdaRes[i, j] + " ");
                    }
                }
                autG[automatNum] = a;
            }

            new Form3(autG).Show();

            this.Hide();
        }

        public void DataShow()
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                AutParser parser = new AutParser(fileName);

                var data = parser.ParseData();

                condTable = data.conditions;

                outputTable = data.outputSignals;

                condNum = condTable.GetLength(0);

                inputNum = condTable.GetLength(1);

                outputNum = outputTable.GetLength(1);

                UpdateUi();
            }
        }

        void UpdateUi()
        {
            if (columnWidth * (inputNum + outputNum + 1) > 235)
                richTextBox3.Width = 240;
            else
                richTextBox3.Width = columnWidth * (inputNum + outputNum + 1);

            if ((condNum+1) * 48 > 280)
                richTextBox3.Height = 280;
            else
                richTextBox3.Height = (condNum + 1) * 48;

            StringBuilder richTextBox3Content = new StringBuilder();

            for (int i = 0; i < condNum; i++)
            {
                if (i > 0)
                    richTextBox3Content.Append(Environment.NewLine);

                richTextBox3Content.Append(i + 1);

                for (int j = 0; j < inputNum; j++)
                    richTextBox3Content.Append("\t" + condTable[i, j]);

                for (int j = 0; j < outputNum; j++)
                    richTextBox3Content.Append("\t" + outputTable[i, j]);
            }

            richTextBox3.Text = richTextBox3Content.ToString();

            UpdateRichTextBox4();

            if (execType == ExecutionType.Experiment)
            {
                label2.Location = new Point(richTextBox3.Location.X + richTextBox3.Width + 30, richTextBox3.Location.Y);

                textBox2.Location = new Point(label2.Location.X + 40, label2.Location.Y + label2.Height + 20);

                button1.Location = new Point(textBox2.Location.X + 20, textBox2.Location.Y + textBox2.Height + 20);

                labelExperimentType.Location = new Point(label2.Location.X + label2.Width + 40, label2.Location.Y);

                radioButtonDiagnExp.Location = new Point(labelExperimentType.Location.X + 20, labelExperimentType.Location.Y + 30);

                radioButtonSetExp.Location = new Point(radioButtonDiagnExp.Location.X, radioButtonDiagnExp.Location.Y + 30);

            }
        }

        void UpdateRichTextBox4()
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

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (pictureBox1 != null)
            {
                pictureBox1.Size = new Size((ClientRectangle.Width / 10) * 6,
                        (ClientRectangle.Height / 10) * 6);
            }

            UpdateUi();

            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Multiline = true;

            if (string.IsNullOrEmpty(fileName))
                Operations.ShowMessage("Добавьте автомат.");

            else
            {
                if (execType == ExecutionType.Modeling)
                {
                    if (!string.IsNullOrEmpty(richTextBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
                    {
                        inputCondSet = new List<string>(textBox2.Text.Split(spaceToSplit, StringSplitOptions.RemoveEmptyEntries));
                        inputSignalSet = new List<string>(richTextBox1.Text.Split(spaceToSplit, StringSplitOptions.RemoveEmptyEntries));

                        int f = 0;
                        while (f < condNum - 1 && f < inputCondSet.Count)
                        {
                            string s = inputCondSet[f];
                            inputCondSet.RemoveAll(str => str == s);
                            inputCondSet.Add(s);
                            f++;
                        }

                        inputCondSet.Sort();

                        try
                        {
                            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                            {
                                int counter = int.Parse(textBox1.Text);

                                while (counter > 0)
                                {
                                    StartAutomat();

                                    inputSignalSet = lambdaRes.Cast<string>().ToList();

                                    counter--;
                                }

                                StartAutomat();
                            }

                            else
                                StartAutomat();

                            panel1.Update();

                            Refresh();
                        }
                        catch (Exception)
                        {
                            Operations.ShowMessage("Ошибка при вводе!");
                        }
                    }
                    else
                        Operations.ShowMessage("Ошибка при вводе!");
                }
                else
                {
                    if (!string.IsNullOrEmpty(textBox2.Text.Trim()) && !string.IsNullOrEmpty(fileName))
                    {
                        if (radioButtonSetExp.Checked ^ radioButtonDiagnExp.Checked)
                        {
                            Experiments.ExperimentType experimentType;

                            if (radioButtonDiagnExp.Checked)
                                experimentType = Experiments.ExperimentType.Diagnostic;
                            else
                                experimentType = Experiments.ExperimentType.Setting;

                            List<int> initialConditionsSet = new List<int>();

                            foreach (var item in textBox2.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                                initialConditionsSet.Add(int.Parse(item));

                            new Form4(Experiments.StartTheExperiment(
                                initialConditionsSet, condTable, outputTable, experimentType), inputNum)
                                .Show();
                        }
                        else
                            Operations.ShowMessage("Выберите тип эксперимента!");
                    }
                    else
                        Operations.ShowMessage("Ошибка при вводе!");
                }
            }
        }

        void StartAutomat()
        {
            deltaRes = new int[inputCondSet.Count, inputSignalSet.Count + 1];
            lambdaRes = new string[inputCondSet.Count, inputSignalSet.Count];

            for (int j = 0; j < inputCondSet.Count; j++) 
                deltaRes[j, 0] = int.Parse(inputCondSet[j]);

            for (int i = 0; i < inputCondSet.Count; i++)
            {
                for (int elem = 1; elem <= inputSignalSet.Count; elem++)
                {
                    deltaRes[i, elem] = AutomatFunctions.Operations.Delta(condTable, deltaRes[i, elem - 1],
                        int.Parse(inputSignalSet[elem - 1]));

                    lambdaRes[i, elem - 1] = AutomatFunctions.Operations.Lambda(outputTable, deltaRes[i, elem - 1],
                        int.Parse(inputSignalSet[elem - 1]));
                }
            }

            richTextBox2.Text = string.Empty;
            richTextBox2.Width = condNum * 28;

            for (int i = 0; i < inputSignalSet.Count + 1; i++)
            {
                for (int j = 0; j < inputCondSet.Count; j++)
                {
                    if (i == 0)
                        richTextBox2.Text += inputCondSet[j] + " ";
                    else 
                        richTextBox2.Text += lambdaRes[j, i - 1] + " ";
                }

                richTextBox2.Text += "\n";
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (inputSignalSet != null && !string.IsNullOrEmpty(textBox2.Text))
            {
                Graphics g = e.Graphics;
                int sideSize = 35;
                Font f1 = new Font("Times New Roman", 18);
                Font f2 = new Font("Times New Roman", 9);
                Rectangle rect;
                pictureBox1.Width = (inputSignalSet.Count + 1) * (sideSize + 35);
                pictureBox1.Height = (inputCondSet.Count + 1) * (sideSize);
                panel1.Height = pictureBox1.Height;
                Rectangle rect1 = pictureBox1.ClientRectangle;
                for (int j = 0; j < inputCondSet.Count; j++)
                {
                    int b = 10;
                    for (int i = 0; i < inputSignalSet.Count; i++)
                    {
                        rect = new Rectangle(sideSize + b, (j+1) * sideSize, sideSize - 5, sideSize - 5);
                        g.DrawEllipse(Pens.RosyBrown, rect);
                        g.DrawString((deltaRes[j, i] + ""), f1, Brushes.Black,
                            new RectangleF(sideSize + b + 6, 
                            (j + 1) * sideSize + 2, sideSize,sideSize));
                        g.DrawLine(Pens.Black, b - 5 + sideSize * 2,
                            (float)(sideSize * 1.45 + j * sideSize), 
                            b + sideSize * 2 + 25, (float)(sideSize * 1.45 + j * sideSize));
                        g.DrawString(inputSignalSet[i] + "/" + lambdaRes[j, 
                            i / inputCondSet.Count], f2, Brushes.Black,
                            new RectangleF(b + sideSize * 2, (j + 1) * sideSize,
                            sideSize + 10, sideSize));
                        b += 60;
                    }
                    rect = new Rectangle(sideSize + b, (j + 1) * sideSize, sideSize - 5, sideSize - 5);
                    g.DrawEllipse(Pens.RosyBrown, rect);
                    g.DrawString((deltaRes[j, inputSignalSet.Count] + ""), f1, Brushes.Black,
                        new RectangleF(sideSize + b + 6, (j + 1) * sideSize + 2, sideSize, sideSize));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog k = new OpenFileDialog();

            k.Filter = "Text Files(*.txt)|*.txt";

            if (k.ShowDialog() == DialogResult.OK)
            {
                fileName = k.FileName;

                if (autG.Count > 0)
                {
                    AutOptions a = autG[automatNum];
                    a.DataFile = fileName;
                    autG[automatNum] = a;
                }

                DataShow();

                if (!isAutFirst)
                    button1_Click(sender, EventArgs.Empty);

                UpdateUi();
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

                Operations.ShowMessage("Неверно введно число итераций");
            }
        }

    }
}
