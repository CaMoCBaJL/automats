using BLInterfaces;
using DalInterfaces;
using System.Collections.Generic;
using System.Drawing;
using Entities;
using System.Linq;
using System;

namespace BuisnessLogic
{
    public class DataProvidingLogic : IDataProviderLogic
    {
        IDataProvider _DAL;

        public DataProvidingLogic(IDataProvider dal) => _DAL = dal;

        public bool AddAutomatData(string automatTablesFileName, string inputSignalsString, string outputSignalsString, string automatName)
               => _DAL.SaveAutomatWorkData(new ChainElementSettings(automatTablesFileName, inputSignalsString, outputSignalsString, automatName));

        public List<string> GetData(string path)
               => new List<string>(_DAL.GetData(path));

        public Dictionary<string, Point> LoadAutomatChainAppearance()
        {
            Dictionary<string, Point> result = new Dictionary<string, Point>();

            foreach (var automatGroup in _DAL.LoadAutomatChainConfiguration())
            {
                foreach (var element in automatGroup.GroupElements)
                {
                    result.Add(element.AutomatName, element.AutomatLocation);
                }
            }

            return result;
        }

        public void SaveAutomatChainAppearance(Dictionary<string, Point> nameAndLocationPair)
        {
            _DAL.SaveAutomatChainConfiguration(DivideAutomatByGroups(nameAndLocationPair));
        }

        List<ChainModellingGroupOfElements> DivideAutomatByGroups(Dictionary<string, Point> dataToDivision)
        {
            List<ChainModellingGroupOfElements> result = new List<ChainModellingGroupOfElements>();

            while (dataToDivision.Count > 0)
            {
                List<ChainElemViewInfo> group = new List<ChainElemViewInfo>();

                var elemToCompare = dataToDivision.ElementAt(0);

                if (dataToDivision.Count == 1)
                {
                    group.Add(new ChainElemViewInfo(elemToCompare.Value, elemToCompare.Key));

                    break;
                }

                foreach (var item in dataToDivision)
                {
                    if (item.Key == elemToCompare.Key)
                        continue;

                    if (Math.Abs(item.Value.X - elemToCompare.Value.X) < 20)
                        group.Add(new ChainElemViewInfo(item.Value, item.Key));
                }

                if (group.Count == 0)
                    group.Add(new ChainElemViewInfo(elemToCompare.Value, elemToCompare.Key));

                group.ForEach((KeyValuePair) => dataToDivision.Remove(KeyValuePair.AutomatName));

                result.Add(new ChainModellingGroupOfElements(result.Count + 1, group));
            }

            return result;
        }
    }
}
