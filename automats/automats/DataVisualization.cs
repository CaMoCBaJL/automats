using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Entities;
using CommonLogic;

namespace PresentationLayer
{
    public partial class DataVisualization : Form
    {
        ExecutionType executionType;


        Dictionary<int, List<string>> receivedData;

        List<RichTextBox> nodes;

        Dictionary<int, List<int>> pairsToConnect;

        Graphics globalGraphics;


        public DataVisualization(Dictionary<int, List<AutomatConfiguration>> processedData, ExecutionType execType)
        {
            InitializeComponent();

            Text = "Результат моделирования";

            executionType = execType;

            MouseWheel += (sender, args) => OnScroll(new ScrollEventArgs(ScrollEventType.ThumbPosition, Location.Y + 50));

            receivedData = new Logic().ParseConfigurations(processedData);

            pairsToConnect = new Logic().FindAllPairsToConnect(processedData);
        }


        public DataVisualization(Dictionary<int, List<AGroup>> processedData, ExecutionType execType)
        {
            InitializeComponent();

            Text = "Результат эксперимента";

            executionType = execType;

            MouseWheel += (sender, args) => OnScroll(new ScrollEventArgs(ScrollEventType.ThumbPosition, Location.Y + 50));

            receivedData = new Logic().ParseAgroups(processedData); ;

            pairsToConnect = new Logic().FindAllPairsToConnect(processedData);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            nodes = new List<RichTextBox>();

            pictureBox1.Size = Size;

            globalGraphics = pictureBox1.CreateGraphics();

            int widestNode = new DrawingLogic().FindWidestNode(receivedData, executionType);

            new DrawingLogic().FindDiagrammCenter(receivedData, out int centerX, widestNode, ClientRectangle);

            var dataToCreateNodeNet = receivedData;

            if (executionType == ExecutionType.Modeling)
                dataToCreateNodeNet = CreateDataForNodeNet(receivedData);

            CreateNodeNet(dataToCreateNodeNet, centerX, widestNode);

            ActiveControl = null;
        }

        Dictionary<int, List<string>> CreateDataForNodeNet(Dictionary<int, List<string>> dataToRebuild)
        {
            Dictionary<int, List<string>> result = new Dictionary<int, List<string>>();

            foreach (var key in dataToRebuild.Keys)
                result.Add(key, new List<string>());

            foreach (var valueSet in dataToRebuild)
            {
                foreach (var value in valueSet.Value)
                {
                    result[valueSet.Key].Add(value.Split()[0]);
                }
            }

            return result;
        }

        void CreateNodeNet(Dictionary<int, List<string>> data, int centerX, int widestNode)
        {
            List<RichTextBox> newNodesLayer = new List<RichTextBox>();

            for (int layerNum = 0; layerNum < data.Count; layerNum++)
            {
                var nodeSize = new DrawingLogic().FindNodeSize(data[layerNum], executionType);

                int nodeWidth = nodeSize.nodeWidth;

                int nodeHeight = nodeSize.nodeHeight;

                int offsetX = DrawingLogic.FindLayerOffset(data[layerNum].Count, centerX, nodeWidth);

                for (int i = 0; i < data[layerNum].Count; i++)
                {
                    newNodesLayer.Add(CreateNode(data[layerNum][i], nodeSize, widestNode));

                    if (data[layerNum].Count % 2 == 0)
                        newNodesLayer.Last().Location =
                            DrawingLogic.FindLabelLocationInEvenLayer(centerX, nodeHeight + 50, nodeWidth,
                            layerNum + 1 + 1, i, offsetX);
                    else
                        newNodesLayer.Last().Location =
                            DrawingLogic.FindLabelLocationInOddLayer(centerX, nodeHeight + 50, nodeWidth + offsetX,
                            layerNum + 1 + 1, i, offsetX, nodeWidth);
                }

                newNodesLayer.Sort(SortNodes);

                nodes.AddRange(newNodesLayer);

                newNodesLayer = new List<RichTextBox>();
            }
        }

        RichTextBox CreateNode(string labelText, (int nodeWidth, int nodeHeight) nodeSize, int widestLetter)
        {
            RichTextBox richTextBox = new RichTextBox()
            {
                ReadOnly = true,

                Font = new Font("Verdana " + FontLogic.LetterWidth.ToString(), FontLogic.LetterHeight),

                Text = labelText,

                Height = nodeSize.nodeHeight,

                Width = nodeSize.nodeWidth
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

        void DrawLine(Control l1, Control l2)
        =>globalGraphics.DrawLine(Pens.Black,
                    new Point(l1.Location.X + l1.Width / 2, l1.Location.Y + l1.Height / 2),
                    new Point(l2.Location.X + l2.Width / 2, l2.Location.Y + l2.Height / 2));
        


        void ConnectNodes(Dictionary<int, List<int>> pairs, Dictionary<int, List<string>> executionData)
        {
            int lastLayerNum = executionData.Count - 1;

            for (int layerNum = 0; layerNum < lastLayerNum; layerNum++)
            {
                int lastElemNum = executionData.First().Value.Count;

                for (int elemNum = 0; elemNum < lastElemNum; elemNum++)
                {
                    DrawModellingDetails(nodes[layerNum * lastElemNum + elemNum], nodes[(layerNum + 1) * lastElemNum + elemNum - 1], receivedData[layerNum + 1][elemNum]);
                }
            }
        }

        void DrawModellingDetails(Control l1, Control l2, string parsedConfiguration)
        {
            var parsedData = parsedConfiguration.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            globalGraphics.DrawString(parsedData[2], l1.Font, Brushes.Black,
                l1.Location.X + (l1.Width / 2 - 21), l1.Location.Y + l1.Height  + 5);

            globalGraphics.DrawString(parsedData[1], l1.Font, Brushes.Black,
                l1.Location.X + (l1.Width / 2), l1.Location.Y + l1.Height + 5);
        }

        void OnMouseHover(object sender, EventArgs args)
        {
            if (nodes != null)
            {
                var N = nodes.IndexOf((sender as RichTextBox)) + 1;

                (sender as RichTextBox).BackColor = Color.Green;

                int ancestorNum = 0;

                foreach (var pairSet in pairsToConnect)
                {
                    if (pairSet.Value.Contains(N))
                    {
                        ancestorNum = pairSet.Key;

                        break;
                    }
                }

                if (ancestorNum > 0)
                    OnMouseHover(nodes[ancestorNum - 1], EventArgs.Empty);

                return;
            }
        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            pictureBox1.Size = Size;
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

            if (executionType == ExecutionType.Modeling)
                ConnectNodes(pairsToConnect, receivedData);
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
                    FontLogic.ReduceLetterWidth();

                    FontLogic.ReduceLetterHeight();
                }
                if (e.KeyCode == Keys.Oemplus)
                {
                    FontLogic.EnlargeLetterWidth();

                    FontLogic.EnlargeLetterHeight();
                }
            }

            nodes.ForEach(node => Controls.Remove(node));

            Form4_Load(this, EventArgs.Empty);

            Refresh();
        }
    }
}
