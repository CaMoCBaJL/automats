using BLInterfaces;
using DalInterfaces;
using System.Collections.Generic;
using System.Text;
using Entities;

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

        public Dictionary<int, string> LoadAutomatChainAppearance()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            foreach (var dataItem in _DAL.DeserializeAutomatChain())
            {
                result.Add(int.Parse(dataItem.Split()[0]), dataItem.Split()[1]);
            }

            return result;
        }

        public void SaveAutomatChainAppearance(Dictionary<int, string> elementsLocations)
        {
            StringBuilder dataToSerialization = new StringBuilder();

            foreach (var item in elementsLocations)
            {
                dataToSerialization.AppendLine(item.Key + " " + item.Value);
            }

            _DAL.SerializeAutomatChain(dataToSerialization.ToString());
        }
    }
}
