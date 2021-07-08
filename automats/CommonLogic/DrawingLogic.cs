using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace CommonLogic
{
    public class DrawingLogic
    {
        public List<Label> GetGroupLabels(int groupNum, List<int> groups, List<AutOptions> groupsElems)
        {
            List<Label> labels = new List<Label>();

            int groupLeftBorder = 0;

            for (int i = 0; i < groupNum; i++)
                groupLeftBorder += groups[i];

            for (int i = groupLeftBorder; i < groups[groupNum] + groupLeftBorder; i++)
                labels.Add(groupsElems[i].Label);

            labels.Sort((l1, l2) =>
            {
                if (l1.Location.Y > l2.Location.Y)
                    return 1;
                else if (l1.Location.Y < l2.Location.Y)
                    return -1;
                return 0;
            });

            AlignTheGroupByTheXAxis(labels);

            return labels;
        }

        static public int FindWidestNode(Dictionary<int, List<string>> data, ExecutionType executionType)
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

        static public (int nodeWidth, int nodeHeight) FindNodeSize(List<string> dataLayer, ExecutionType executionType)
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

                        foreach (var sigmaSet in aGroup.Split(FontLogic.newLineToSplit, StringSplitOptions.RemoveEmptyEntries))
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

        static void AlignTheGroupByTheXAxis(List<Label> group)
        {
            if (group.Count > 1)
                for (int i = 1; i < group.Count; i++)
                {
                    group[i].Location = new Point(group[0].Location.X, group[i].Location.Y);
                }
        }

        static public Point GetCentralPoint(List<Label> group, int labelWidth, int offset)
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
    }
}
