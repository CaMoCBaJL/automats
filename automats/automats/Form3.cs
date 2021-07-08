﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entities;
using CommonLogic;

namespace PresentationLayer
{
    public partial class Form3 : Form
    {
        bool status = false;

        List<AutOptions> PresentationLayer = new List<AutOptions>();

        List<AutOptions> groupsElems = new List<AutOptions>();

        List<int> groups = new List<int>();

        Graphics globalGraphics;

        public const int labelWidth = 110;

        public const int labelHeight = 50;

        public const int offset = 40; 


        public Form3(List<AutOptions> auts)
        {
            InitializeComponent();

            AddAutomats(auts);
        }

        public Form3(Form f) => InitializeComponent();

        void AddAutomats(List<AutOptions> PresentationLayer)
        {
            foreach (AutOptions item in PresentationLayer)
            {
                AutOptions.ResetAutCounter();

                Label l = item.Label;
                Controls.Add(l);
                l.BringToFront();
                PresentationLayer.Add(new AutOptions(l, item.DataFile, item.InputSignals, item.StartCondition, item.OutputSignals));
            }
        }

        public void LabelMouseDown(object sender, MouseEventArgs e) => status = true;

        public void LabelMouseUp(object sender, MouseEventArgs e)
        {
            status = false;

            Refresh();
        }

        void DrawConsistentConnection(Graphics g, List<Label> currentGroup, List<Label> previousGroup, int offsetX)
        {
            var prevGroupCenter = DrawingLogic.GetCentralPoint(previousGroup, labelWidth, offsetX);

            var curGroupCenter = DrawingLogic.GetCentralPoint(currentGroup, labelWidth, offsetX);

            if (currentGroup.Count == 1 && previousGroup.Count == 1)
                g.DrawLine(Pens.Black,
                    new Point(currentGroup[0].Location.X,
                    currentGroup[0].Location.Y + currentGroup[0].Height / 2),

                    new Point(previousGroup[0].Location.X + previousGroup[0].Width - 5,
                    previousGroup[0].Location.Y + previousGroup[0].Height / 2));

            else if (currentGroup.Count == 1 && previousGroup.Count > 1)
                    g.DrawLine(Pens.Black, prevGroupCenter,
                    new Point(currentGroup[0].Location.X, currentGroup[0].Location.Y
                    + currentGroup[0].Height / 2));
            
            else if (currentGroup.Count > 0 && previousGroup.Count == 1)
            { 
                g.DrawLine(Pens.Black,
                    new Point(currentGroup[0].Location.X + offsetX , curGroupCenter.Y),
                    new Point(previousGroup[0].Location.X + previousGroup[0].Width,
                    previousGroup[0].Location.Y + previousGroup[0].Height / 2));
            }
            else
                g.DrawLine(Pens.Black, prevGroupCenter, new Point(curGroupCenter.X - labelWidth - 2 * offset, curGroupCenter.Y));
        }

        void DrawPrallelConnection(Graphics g, List<Label> labels, int offsetX)
        {
            if (labels.Count > 1)
            {
                Label l1 = labels[0];

                Label l2 = labels[labels.Count - 1];

                var value1 = l1.Location.Y + l1.Height / 2;

                var value2 = l2.Location.Y + l2.Height / 2;

                g.DrawLine(Pens.Black, new Point(l1.Location.X + offsetX, value1),
                    new Point(l1.Location.X + offsetX, value2));

                for(int i = 0; i < labels.Count; i++)
                {
                    g.DrawLine(Pens.Black, new Point(labels[i].Location.X,
                        labels[i].Location.Y + labels[i].Height / 2),
                        new Point(labels[i].Location.X + offsetX ,
                        labels[i].Location.Y + labels[i].Height / 2));
                }
            }
        }

        void AutsSortByGroups()
        {
            List<AutOptions> auts = new List<AutOptions>(PresentationLayer);

            auts.Sort((l1, l2) =>
            {
                if (l1.Label.Location.X < l2.Label.Location.X)
                    return -1;
                else if (l1.Label.Location.X > l2.Label.Location.X)
                    return 1;
                return 0;
            });

            groups = new List<int>();
            groupsElems = new List<AutOptions>();
            int prevCount = 0;

            while (auts.Count > 0)
            {
                var group = auts.FindAll((elem) => Math.Abs(elem.Label.Location.X -
                    auts[0].Label.Location.X) < 10);

                groupsElems.AddRange(group);

                groups.Add(groupsElems.Count - prevCount);

                prevCount = groupsElems.Count;

                AutOptions element = auts[0];

                int i = 0;

                while (group.Count > 0)
                {
                    if (auts.Contains(group[i]))
                    {
                        auts.Remove(group[i]);

                        group.Remove(group[i]);
                    }
                    else
                        i++;
                }
            }
        }


        void LabelsAreParallel()
        {
            AutsSortByGroups();

            var drawer = new DrawingLogic();

            for (int j = 0; j < groups.Count; j++)
            {
                if (j > 0)
                    DrawConsistentConnection(globalGraphics, drawer.GetGroupLabels(j, groups, groupsElems),
                        drawer.GetGroupLabels(j - 1, groups, groupsElems), -offset);

                DrawPrallelConnection(globalGraphics, drawer.GetGroupLabels(j, groups, groupsElems), - offset);

                DrawPrallelConnection(globalGraphics, drawer.GetGroupLabels(j, groups, groupsElems), labelWidth + offset);
            }
        }

        public void LabelMouseDoubleClick(object sender, MouseEventArgs e)
        {
            AutsSortByGroups();

            StringBuilder str = new StringBuilder();
            Label l = sender as Label;
            int indx = 0;

            for (int i = 0; i < groupsElems.Count; i++)
                if (groupsElems[i].Label == (Label)sender)
                {
                    indx = i;
                    break;
                }

            bool autLvl;
            int groupNum = 0;
            int res = indx;

            foreach (int elem in groups)
            {
                res -= elem; 
                if (res >= 0)
                    groupNum++;
                else
                {
                    groupNum++;
                    break;
                }
            }
            
            MessageBox.Show("indx " + indx + "\n groupNum " + groupNum);

            bool isPrevGroupWorked = true;

            StringBuilder prevGroupYs = new StringBuilder();
            int firstIndx = 0;
            if (groupNum != 1)
            {
                for (int i = 0; i < groupNum - 2; i++)
                    firstIndx += groups[i];
                for (int i = firstIndx; i < firstIndx + groups[groupNum - 1]; i++)
                {
                    if (string.IsNullOrEmpty(groupsElems[i].OutputSignals.ToString()))
                    {
                        isPrevGroupWorked = false;
                        break;
                    }
                }
            }
            if (isPrevGroupWorked)
            {
                int autIndx = -1;
                if (groupNum != 1)
                {
                    for (int k = firstIndx; k < firstIndx + groups[groupNum - 1]; k++)
                        prevGroupYs.Append(groupsElems[k].OutputSignals);
                    autIndx = int.Parse(l.Text.Substring(3, l.Text.Length - 3)) - 1;
                    AutOptions a = PresentationLayer[autIndx];
                    a.InputSignals = prevGroupYs;
                    PresentationLayer[autIndx] = a;
                }

                if (indx < groups[0])
                    autLvl = true;
                else
                    autLvl = false;

                Controls.Clear();

                StringBuilder stringa = new StringBuilder();

                if (autIndx != -1) 
                    stringa = PresentationLayer[autIndx].InputSignals;

                this.Hide();

                new Form1(autLvl, PresentationLayer.Find(s => s.Label == l).DataFile, PresentationLayer,
                    (l.Text.Last() - '0') - 1, stringa).Show();
            }
            else
                MessageBox.Show("Предыдущая группа не работала!");
        }

        public void LabelMouseMove(object sender,MouseEventArgs e)
        {
            if(status)
            {
                Label l1 = (Label)sender;
                l1.Location = new Point((Cursor.Position.X - this.Location.X - 35), 
                    (Cursor.Position.Y - this.Location.Y - 35));
            }

            Refresh();
        }

        private void AddAutomat(object sender, EventArgs e)
        {
            Label l1 = new Label();
            l1.TextAlign = ContentAlignment.MiddleCenter;
            l1.Font = new Font("Verdana; 42pt", 26);
            l1.Text = "ABT" + (AutOptions.AutNum+1);
            l1.Location = new Point(100, 100);
            l1.Size = new Size(labelWidth, labelHeight);
            l1.MouseDown += LabelMouseDown;
            l1.MouseMove += LabelMouseMove;
            l1.MouseUp += LabelMouseUp;
            l1.MouseDoubleClick += LabelMouseDoubleClick;
            PresentationLayer.Add(new AutOptions(l1, string.Empty, new StringBuilder(), new StringBuilder(), new StringBuilder()));
            Controls.Add(l1);
            l1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            new Form2().Show();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e) => Environment.Exit(0);

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.Size = Size;

            globalGraphics = pictureBox1.CreateGraphics();
        }

        private void Form3_Resize(object sender, EventArgs e) => pictureBox1.Size = Size;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            globalGraphics = e.Graphics;

            LabelsAreParallel();
        }
    }
}
