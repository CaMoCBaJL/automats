using System.Collections.Generic;
using Entities;
using System.Drawing;

namespace BLInterfaces
{
    public interface IDataProviderLogic
    {
        List<string> GetData(string path);

        void SaveAutomatChainAppearance(Dictionary<string, Point> nameAndLocationPair);

        Dictionary<string, Point> LoadAutomatChainAppearance();

        bool AddAutomatData(string automatTablesFileName, string inputSignalsString, string outputSignalsString, string automatName);

        Automat ParseAutomatDataTables(string pathToFile);
    }
}
