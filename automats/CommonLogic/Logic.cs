using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using DataAccessLayer;

namespace CommonLogic
{
    public class Logic
    {
        public Dictionary<int, List<string>> ParseConfigurations(Dictionary<int, List<AutomatConfiguration>> processedData)
        {
            Dictionary<int, List<string>> result = new Dictionary<int, List<string>>();

            for (int i = 0; i < processedData.First().Value.Count; i++)
            {
                List<string> currentLayer = new List<string>();

                foreach (var key in processedData.Keys)
                {
                    currentLayer.Add(processedData[key][i].ToString());
                }

                result.Add(i, currentLayer);
            }

            return result;
        }

        public Dictionary<int, List<string>> ParseAgroups(Dictionary<int, List<AGroup>> experimentResult)
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

        public Dictionary<int, List<int>> FindAllPairsToConnect(Dictionary<int, List<AutomatConfiguration>> modellingResult)
        {
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();

            int lastElem = modellingResult.Keys.Count * (modellingResult.First().Value.Count);

            for (int i = 0; i < lastElem - modellingResult.Keys.Count; i++)
            {
                result.Add(i + 1, new List<int>(new int[] { i + 1 + modellingResult.Keys.Count }));
            }

            return result;
        }

        public Dictionary<int, List<int>> FindAllPairsToConnect(Dictionary<int, List<AGroup>> experimentResult)
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
