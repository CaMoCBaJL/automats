using System;
using System.Collections.Generic;
using System.Drawing;
using Dependencies;
using System.Text;
using System.Windows.Forms;
using Entities;
using CommonLogic;
using DataValidation;

namespace PresentationLayer
{
    public partial class AutomatChainModellingForm : Form
    {
        bool status = false;

        Graphics globalGraphics;

        public const int labelWidth = 110;

        public const int labelHeight = 50;

        public const int offset = 40;


        public AutomatChainModellingForm()
        {
            InitializeComponent();
        }

        public void LabelMouseDown(object sender, MouseEventArgs e) => status = true;

        public void LabelMouseUp(object sender, MouseEventArgs e)
        {
            status = false;

            DependencyResolver.Instance.ChainModellingBL.SaveAutomatChainAppearance(GetLabelData());

            Refresh();
        }

        void LabelsAreParallel()
        {
            var groups = DependencyResolver.Instance.ChainModellingBL.LoadAutomatGroups();

            var drawer = new DrawingLogic();

            for (int j = 0; j < groups.Count; j++)
            {
                var currentGroup = drawer.GetGroupLabels(groups[j].GroupElements, Controls);

                drawer.AlignGroupByXAxis(currentGroup);

                if (j > 0)
                {
                    var previousGroup = drawer.GetGroupLabels(groups[j - 1].GroupElements, Controls);

                    drawer.ConnectGroups(globalGraphics, currentGroup,
                        previousGroup, -offset, labelWidth);
                }

                drawer.ConnectOneGroupElems(globalGraphics, currentGroup, -offset);

                drawer.ConnectOneGroupElems(globalGraphics, currentGroup, labelWidth + offset);
            }
        }

        void LabelMouseDoubleClick(object sender, MouseEventArgs e)
        {
            DependencyResolver.Instance.ChainModellingBL.SaveAutomatChainAppearance(GetLabelData());

            AutomatModelling(sender as Label);
        }

        Dictionary<string, Point> GetLabelData()
        {
            Dictionary<string, Point> result = new Dictionary<string, Point>();

            foreach (var item in Controls)
            {
                if (item.GetType() == typeof(Label))
                {
                    Label l = (item as Label);
                    result.Add(l.Text, l.Location);
                }
            }

            return result;
        }

        void AutomatModelling(Label automat)
        {
            if (DependencyResolver.Instance.ChainModellingBL.DidAllPreviousGroupsWork(
                DependencyResolver.Instance.ChainModellingBL.GetAutomatGroup(automat.Text)).ValidationPassed())
            {
                this.Hide();

                new ModellingForm(automat.Text).Show();
            }

        }

        public void LabelMouseMove(object sender, MouseEventArgs e)
        {
            if (status)
            {
                Label l1 = (Label)sender;
                l1.Location = new Point((Cursor.Position.X - this.Location.X - 35),
                    (Cursor.Position.Y - this.Location.Y - 35));
            }

            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            new Menu().Show();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e) => Environment.Exit(0);

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.Size = Size;

            globalGraphics = pictureBox1.CreateGraphics();

            if (!DependencyResolver.Instance.ChainModellingBL.IsChainModellingModeActive())
                DependencyResolver.Instance.ChainModellingBL.StartAutomatChainModelling();
            else
            {
                var chainData = DependencyResolver.Instance.ChainModellingBL.LoadAutomatChainAppearance();

                if (chainData.Count > 0)
                    FillTheScreen(chainData);
            }
        }

        void FillTheScreen(Dictionary<string, Point> chainElems)
        {
            foreach (var item in chainElems)
            {
                AddAutomat(item.Key, item.Value);
            }

            DependencyResolver.Instance.ChainModellingBL.SaveAutomatChainAppearance(GetLabelData());
        }

        void AddAutomat(string automatName, Point labelLocation)
        {
            Label l1 = new Label();
            l1.TextAlign = ContentAlignment.MiddleCenter;
            l1.Font = new Font("Verdana; 42pt", 26);
            l1.Text = automatName;
            l1.Location = labelLocation;
            l1.Size = new Size(labelWidth, labelHeight);
            l1.MouseDown += LabelMouseDown;
            l1.MouseMove += LabelMouseMove;
            l1.MouseUp += LabelMouseUp;
            l1.MouseDoubleClick += LabelMouseDoubleClick;
            Controls.Add(l1);
            l1.BringToFront();

            DependencyResolver.Instance.ChainModellingBL.SaveAutomatChainAppearance(GetLabelData());
        }

        private void Form3_Resize(object sender, EventArgs e) => pictureBox1.Size = Size;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            globalGraphics = e.Graphics;

            DependencyResolver.Instance.ChainModellingBL.SaveAutomatChainAppearance(GetLabelData());

            LabelsAreParallel();
        }

        private void addAutomatButtonClick(object sender, EventArgs e)
        => AddAutomat("A" + (DependencyResolver.Instance.ChainModellingBL.LoadAutomatChainAppearance().Count + 1), new Point(100, 100));

    }
}
