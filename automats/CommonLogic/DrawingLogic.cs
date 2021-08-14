using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using CommonConstants;
using Entities;
using static System.Windows.Forms.Control;

namespace CommonLogic
{
    public class DrawingLogic
    {
        public List<Label> GetGroupLabels(List<ChainElemViewInfo> groupElementsData, ControlCollection formElements)
        {
            List<Label> labels = new List<Label>();

            foreach (var item in formElements)
            {
                if (item.GetType() == typeof(Label))
                    if (groupElementsData.Any((elementInfo) => elementInfo.AutomatName == (item as Label).Text))
                    {
                        labels.Add((item as Label));
                    }

            }

            return labels;
        }

        public void AlignGroupByXAxis(List<Label> group)
        {
            if (group.Count > 1)
                for (int i = 1; i < group.Count; i++)
                {
                    group[i].Location = new Point(group[0].Location.X, group[i].Location.Y);
                }
        }

        public void ConnectOneGroupElems(Graphics g, List<Label> labels, int offsetX)
        {
            labels.Sort((Label l1, Label l2) =>
            {
                if (l1.Location.Y > l2.Location.Y)
                    return 1;
                else if (l2.Location.Y > l1.Location.Y)
                    return -1;
                else
                    return 0;

            });

            if (labels.Count > 1)
            {
                Label l1 = labels[0];

                Label l2 = labels[labels.Count - 1];

                var value1 = l1.Location.Y + l1.Height / 2;

                var value2 = l2.Location.Y + l2.Height / 2;

                g.DrawLine(Pens.Black, new Point(l1.Location.X + offsetX, value1),
                    new Point(l1.Location.X + offsetX, value2));

                for (int i = 0; i < labels.Count; i++)
                {
                    g.DrawLine(Pens.Black, new Point(labels[i].Location.X,
                        labels[i].Location.Y + labels[i].Height / 2),
                        new Point(labels[i].Location.X + offsetX,
                        labels[i].Location.Y + labels[i].Height / 2));
                }
            }
        }

        public void ConnectGroups(Graphics g, List<Label> currentGroup, List<Label> previousGroup, int offsetX, int labelWidth)
        {
            var prevGroupCenter = new DrawingLogic().GetCentralPoint(previousGroup, labelWidth, offsetX);

            var curGroupCenter = new DrawingLogic().GetCentralPoint(currentGroup, labelWidth, offsetX);

            if (currentGroup.Count == 1 && previousGroup.Count == 1)
                g.DrawLine(Pens.Black,
                    new Point(currentGroup[0].Location.X,
                    currentGroup[0].Location.Y + currentGroup[0].Height / 2),

                    new Point(previousGroup[0].Location.X + previousGroup[0].Width - 5,
                    previousGroup[0].Location.Y + previousGroup[0].Height / 2));

            else if (currentGroup.Count == 1 && previousGroup.Count > 1)
                g.DrawLine(Pens.Black,
                new Point(prevGroupCenter.X + 2 * (-offsetX), prevGroupCenter.Y),
                new Point(currentGroup[0].Location.X, currentGroup[0].Location.Y
                + currentGroup[0].Height / 2));

            else if (currentGroup.Count > 0 && previousGroup.Count == 1)
            {
                g.DrawLine(Pens.Black,
                    new Point(currentGroup[0].Location.X + offsetX, curGroupCenter.Y),
                    new Point(previousGroup[0].Location.X + previousGroup[0].Width + offsetX,
                    previousGroup[0].Location.Y + previousGroup[0].Height / 2));
            }
            else
                g.DrawLine(Pens.Black,
                    new Point(prevGroupCenter.X + 2 * (-offsetX), prevGroupCenter.Y),
                    new Point(curGroupCenter.X - labelWidth, curGroupCenter.Y));
        }

        public int FindWidestNode(Dictionary<int, List<string>> data, ExecutionType executionType)
        {
            int nodeWidth = 0;

            if (executionType == ExecutionType.Modeling)
                return CalculateFontWidth(1);

            foreach (var item in data)
            {
                var nodeLayerSize = FindNodeSize(item.Value, executionType);

                if (nodeWidth < nodeLayerSize.nodeWidth)
                    nodeWidth = nodeLayerSize.nodeWidth;
            }

            return nodeWidth;
        }

        public (int nodeWidth, int nodeHeight) FindNodeSize(List<string> dataLayer, ExecutionType executionType)
        {
            int maxSymbolsNum = 0;

            int maxLinesNum = 0;

            switch (executionType)
            {
                case ExecutionType.Modeling:
                    maxSymbolsNum = 1;

                    maxLinesNum = 1;
                    break;
                case ExecutionType.Experiment:
                    foreach (var aGroup in dataLayer)
                    {
                        int linesCount = aGroup.Count(c => c == '{');

                        if (linesCount > maxLinesNum)
                            maxLinesNum = linesCount;

                        foreach (var sigmaSet in aGroup.Split(SplitTemplates.newLineToSplit, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (sigmaSet.Length > maxSymbolsNum)
                                maxSymbolsNum = sigmaSet.Length;
                        }
                    }
                    break;
                case ExecutionType.None:
                default:
                    break;
            }

            return (CalculateFontWidth(maxSymbolsNum + 2), CalculateFontHeight(maxLinesNum));
        }

        static int CalculateFontWidth(int symbolsAmount) => (int)(symbolsAmount * FontLogic.LetterWidth * FontLogic.widthScaleCoef);

        static int CalculateFontHeight(int linesAmount) => (int)(linesAmount * FontLogic.LetterHeight * FontLogic.heightScaleCoef) + 13;


        public Point GetCentralPoint(List<Label> group, int labelWidth, int offset)
        {
            int topLine = group[0].Location.Y + group[0].Height / 2;

            int botLine = group[group.Count - 1].Location.Y + group[group.Count - 1].Height / 2;

            return new Point(group[0].Location.X + labelWidth + offset, (topLine + botLine) / 2);
        }

        public void FindDiagrammCenter(Dictionary<int, List<string>> layers, out int center, int labelWidth, Rectangle ClientRectangle)
        {
            int result;

            center = 0;

            foreach (var layer in layers)
            {
                if (layer.Value.Count % 2 == 0)
                {
                    result = 20 + (layer.Value.Count / 2) * (labelWidth + 20);

                    if (result < ClientRectangle.Width / 2)
                        result = ClientRectangle.Width / 2;
                }
                else
                {
                    result = 20 + labelWidth / 2 + (layer.Value.Count / 2) * (labelWidth + 20);

                    if (result < ClientRectangle.Width / 2)
                        result = ClientRectangle.Width / 2 + labelWidth / 2 + 10;
                }

                if (center < result)
                    center = result;
            }
        }

        static public int FindLayerOffset(int labelsNum, int centerX, int labelWidth)
        {
            if (centerX * 2 / labelsNum - labelWidth > 20)
                return ((centerX * 2) / labelsNum - labelWidth);

            return 20;
        }

        /// <summary>
        /// f(labelNum) = centerX + (-1)^[(labelNum + 1) % 2]*( offsetX * (labelNum % 2) + stepX * (labelNum / 2) + labelWidth / 2)
        /// </summary>
        /// <param name=""></param>
        static public Point FindLabelLocationInOddLayer(int centerX, int stepY, int stepX, int layerNum, int labelNum, int offsetX, int labelWidth)
            =>
            new Point((centerX + (int)(Math.Pow(-1, (labelNum + 1) % 2))
                * (labelWidth / 2
                + offsetX * (labelNum % 2)
                + stepX * (labelNum / 2))), stepY * layerNum);

        /// <summary>
        /// f(labelNum) = centerX + (-1)^[(labelNum + 1) % 2]*( offsetX * (labelNum / 2) + stepX * ((labelNum / 2) + 1 - (labelNum % 2)) + offsetX / 2)
        /// </summary>
        /// <param name=""></param>
        static public Point FindLabelLocationInEvenLayer(int centerX, int stepY, int stepX, int layerNum, int labelNum, int offsetX)
        =>
            new Point(centerX + (int)(Math.Pow(-1, (labelNum + 1) % 2))
                * (stepX * ((labelNum / 2) + 1 - (labelNum % 2))
                + offsetX * (labelNum / 2)
                + offsetX / 2), stepY * layerNum);

        static public Point CycleInfoLocation(int cycleNum) => new Point(20, 20 + cycleNum * 50);
    }

}
