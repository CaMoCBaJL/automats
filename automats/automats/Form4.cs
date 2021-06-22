using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using AutomatExperiments;

namespace automats
{
    public partial class Form4 : Form
    {
        Dictionary<int, List<AGroup>> experimentResult;
        
        List<RichTextBox> nodes;

        Dictionary<int, List<int>> pairsToConnect;

        Graphics globalGraphics;

        int nodeWidth = 100;

        int nodeHeight = 50;

        int widestLetter = 20;

        int heighestLetter = 30;


        public Form4(Dictionary<int, List<AGroup>> expRes, int inputsNum)
        {
            InitializeComponent();

            OnScroll(new ScrollEventArgs(ScrollEventType.SmallIncrement, 5));

            MouseWheel += (sender, args) => OnScroll(new ScrollEventArgs(ScrollEventType.ThumbPosition, Location.Y + 50));

            //MouseWheel += (sender, args) => Form4_Scroll(sender, new ScrollEventArgs(ScrollEventType.ThumbPosition,
            //    VerticalScroll.Value, VerticalScroll.Value + 5, ScrollOrientation.VerticalScroll));

            experimentResult = expRes;

            pairsToConnect = Operations.FindAllPairsToConnect(experimentResult, inputsNum);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            nodes = new List<RichTextBox>();

            pictureBox1.Size = Size;

            globalGraphics = pictureBox1.CreateGraphics();

            var data = Operations.ParseAgroups(experimentResult);

            Operations.FindDiagrammCenter(data, out int centerX, nodeWidth, ClientRectangle);

            List<RichTextBox> newNodesLayer = new List<RichTextBox>();

            for (int layerNum = 0; layerNum < data.Count; layerNum++)
            {

                nodeWidth = ((int)(experimentResult[layerNum].Max(group => group.AGroupContent.Max(sigmaSet => sigmaSet.Count)) * 1.5) + 2) * widestLetter;

                nodeHeight = experimentResult[layerNum].Max(group => group.AGroupContent.Count) * heighestLetter + 10;

                int offsetX = Operations.FindLayerOffset(data[layerNum].Count, centerX, nodeWidth);

                for (int i = 0; i < data[layerNum].Count; i++)
                {
                    newNodesLayer.Add(CreateNode(data[layerNum][i]));

                    if (data[layerNum].Count % 2 == 0)
                        newNodesLayer.Last().Location =
                            Operations.FindLabelLocationInEvenLayer(centerX, nodeHeight + 50, nodeWidth,
                            layerNum + 1 + 1, i, offsetX);
                    else
                        newNodesLayer.Last().Location =
                            Operations.FindLabelLocationInOddLayer(centerX, nodeHeight + 50, nodeWidth + offsetX,
                            layerNum + 1 + 1, i, offsetX, nodeWidth);
                }

                newNodesLayer.Sort(SortNodes);

                nodes.AddRange(newNodesLayer);

                newNodesLayer = new List<RichTextBox>();
            }
            ActiveControl = null;
        }

        int SortNodes(Control c1, Control c2)
        {
            if (c1.Location.X > c2.Location.X)
                return 1;
            else if (c2.Location.X > c1.Location.X)
                return -1;
            else
                return 0;
        }

        void ConnectNodes(Dictionary<int, List<int>> pairs)
        {
            foreach (var layer in pairs)
            {
                foreach (var element in layer.Value)
                {
                    DrawLine(nodes[layer.Key - 1], nodes[element - 1]);
                }
            }
        }

        RichTextBox CreateNode(string labelText)
        {
            RichTextBox richTextBox = new RichTextBox()
            {

                ReadOnly = true,

                Font = new Font("Verdana " + ((uint)(widestLetter - 3)).ToString(), widestLetter),

                Text = labelText,

                Height = nodeHeight,

                Width = nodeWidth
            };

            richTextBox.MouseHover += OnMouseHover;

            richTextBox.MouseLeave += (sender, args) =>
            {
                System.Threading.Thread.Sleep(300);

                if (nodes != null)
                    nodes.ForEach(node => node.BackColor = Color.White);
            };

            Controls.Add(richTextBox);

            richTextBox.BringToFront();

            return richTextBox;
        }

        void OnMouseHover(object sender, EventArgs args)
        {
            if (nodes != null)
            {
                var N = nodes.IndexOf((sender as RichTextBox)) + 1;

                (sender as RichTextBox).BackColor = Color.Green;

                var ancestorNum = 1;

                foreach (var pairSet in pairsToConnect)
                {
                    if (pairSet.Value.Contains(N))
                    {
                        ancestorNum = pairSet.Key;

                        break;
                    }
                }

                if (N != 1)
                    OnMouseHover(nodes[ancestorNum - 1], EventArgs.Empty);
                }
        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            pictureBox1.Size = Size;
        }

        void DrawLine(Control l1, Control l2)
        {
            globalGraphics.DrawLine(Pens.Black,
                    new Point(l1.Location.X + l1.Width / 2, l1.Location.Y + l1.Height / 2),
                    new Point(l2.Location.X + l2.Width / 2, l2.Location.Y + l2.Height / 2));
        }

        private void Form4_Scroll(object sender, ScrollEventArgs e)
        {
            ActiveControl = null;

            pictureBox1.Location = ClientRectangle.Location;

            pictureBox1.Size = Size;

            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            globalGraphics = e.Graphics;

            ConnectNodes(pairsToConnect);
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void pictureBox1_LocationChanged(object sender, EventArgs e)
        {
            //Refresh();
        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.OemMinus)
                {
                    if (widestLetter > 1)
                        widestLetter--;

                    if (heighestLetter > 2)
                        heighestLetter--;
                }
                if (e.KeyCode == Keys.Oemplus)
                {
                    if (widestLetter < 18)
                        widestLetter++;

                    if (heighestLetter < 30)
                        heighestLetter++;
                }
            }

            nodes.ForEach(node => Controls.Remove(node));

            Form4_Load(this, EventArgs.Empty);
        }
    }
}
