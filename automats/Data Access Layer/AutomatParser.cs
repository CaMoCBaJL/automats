using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AutomatParser
    {
        public string FileName { get; }

        public AutomatParser(string fileName) => FileName = fileName;

        public (int[,] DeltaTable, string[,] LambdaTable) ParseData()
        {
            string[] data;

            int[,] inputTable = default;

            string[,] outputTable = default;

            List<string> autData = new DataIntegrityDAL().GetData(FileName).ToList();

            for (int i = 0; i < autData.Count; i++)
            {
                data = autData[i].Split();

                if (i == 0)
                {
                    inputTable = new int[int.Parse(data[0]), int.Parse(data[1])];

                    outputTable = new string[int.Parse(data[0]), int.Parse(data[2])];
                }
                else
                {
                    int conditionsNum = inputTable.GetLength(1);

                    int outputsNum = outputTable.GetLength(1);

                    for (int j = 0; j < conditionsNum; j++)
                        inputTable[i - 1, j] = int.Parse(data[j]);

                    for (int j = 0; j < outputsNum; j++)
                        outputTable[i - 1, j] = data[conditionsNum + j];
                }
            }

            return (inputTable, outputTable);
        }

    }
}
