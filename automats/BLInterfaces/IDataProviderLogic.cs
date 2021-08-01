using System.Collections.Generic;
using Entities;

namespace BLInterfaces
{
    public interface IDataProviderLogic
    {
        List<string> GetData(string path);

        void SaveAutomatChainAppearance(Dictionary<int, string> elementsLocation);

        Dictionary<int, string> LoadAutomatChainAppearance();

        bool AddAutomatData(string automatTablesFileName, string inputSignalsString, string outputSignalsString);
    }
}
