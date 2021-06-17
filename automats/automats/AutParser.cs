using System.Collections.Generic;
using System.IO;
using System.Linq; 


namespace automats
{
    class AutParser
    {
        public string FileName { get; }

        public AutParser(string fileName) => FileName = fileName;

        public (int[,] conditions, string[,] outputSignals) ParseData()
        {
            string[] data;

            int[,] conditions = default;

            string[,] outputSignals = default;

            List<string> autData = File.ReadAllText(FileName).Split(new char[] { '\n', '\r' },
                System.StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < autData.Count; i++)
            {
                data = autData[i].Split();

                if (i == 0)
                {
                    conditions = new int[int.Parse(data[0]), int.Parse(data[1])];

                    outputSignals = new string[int.Parse(data[0]), int.Parse(data[2])];
                }
                else
                {
                    int conditionsNum = conditions.GetLength(1);

                    int outputsNum = outputSignals.GetLength(1);

                    for (int j = 0; j < conditionsNum; j++)
                        conditions[i - 1, j] = int.Parse(data[j]);

                    for (int j = 0; j < outputsNum; j++)
                        outputSignals[i - 1, j] = data[conditionsNum + j];
                }
            }

            return (conditions, outputSignals);
        }

    }
}
