using AutomatExperiments;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace automats
{
    static class Operations
    {

        static public void ShowMessage(string msg) => MessageBox.Show(msg, "Внимание!", MessageBoxButtons.OK);

        static public List<Label> GetGroupLabels(int groupNum, List<int> groups, List<AutOptions> groupsElems)
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

        static void AlignTheGroupByTheXAxis(List<Label> group)
        {
            if (group.Count > 1)
                for (int i = 1; i < group.Count; i++)
                {
                    group[i].Location = new Point(group[0].Location.X, group[i].Location.Y);
                }
        }

        static public Point GetCentralPoint(List<Label> group)
        {
            int topLine = group[0].Location.Y + group[0].Height / 2;

            int botLine = group[group.Count - 1].Location.Y + group[group.Count - 1].Height / 2;

            return new Point(group[0].Location.X + Form3.labelWidth + Form3.offset, (topLine + botLine) / 2);
        }

        static public T[,] TransposeArray<T>(T[,] sourceArray)
        {

            int width = sourceArray.GetLength(0);

            int height = sourceArray.GetLength(1);

            T[,] destinationArray = new T[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    destinationArray[i, j] = sourceArray[j, i];
                }
            }

            return destinationArray;
        }

        static public void FindDiagrammCenter(Dictionary<int, List<string>> layers, out int center, int labelWidth, Rectangle ClientRectangle)
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

        static public Dictionary<int, List<string>> ParseAgroups(Dictionary<int, List<AGroup>> experimentResult)
        {
            Dictionary<int, List<string>> result = new Dictionary<int, List<string>>();

            foreach (var layer in experimentResult)
            {
                List<string> currentLayer = new List<string>();

                foreach (var group in layer.Value)
                {
                    currentLayer.Add(group.ToString());
                }

                result.Add(layer.Key, currentLayer);
            }

            return result;
        }

        static public Dictionary<int, List<int>> FindAllPairsToConnect(Dictionary<int, List<AGroup>> experimentResult, int inputsNum)
        {
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();

            int counter = 0;

            for (int i = 0; i < experimentResult.Count; i++)
            {
                for (int groupNum = 0; groupNum < experimentResult[i].Count; groupNum++)
                {
                    var prevIndx = 0;

                    if (i > 0)
                        prevIndx = experimentResult[i - 1].IndexOf(experimentResult[i][groupNum].AncestorAGroup) + counter + 1 - experimentResult[i - 1].Count;

                    if (experimentResult[i][groupNum].AncestorAGroup != null)
                    {
                        if (!result.ContainsKey(prevIndx))
                            result.Add(prevIndx, new List<int>());

                        result[prevIndx].Add(groupNum + 1 + counter);
                    }
                }

                counter += experimentResult[i].Count;
            }

            return result;
        }


    }
}
