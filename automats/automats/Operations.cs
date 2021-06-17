using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automats
{
    static class Operations
    {

        static public void ShowMessage(string msg) => MessageBox.Show(msg);

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

    }
}
