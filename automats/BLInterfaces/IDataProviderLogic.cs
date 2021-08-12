using System.Collections.Generic;
using Entities;
using System.Drawing;

namespace BLInterfaces
{
    public interface IDataProviderLogic
    {
        List<string> GetData(string path);

        bool AddAutomatData(string automatTablesFileName, string inputSignalsString, string outputSignalsString, string automatName, string startConditions);

        Automat ParseAutomatDataTables(string pathToFile);

        ChainElementSettings LoadAutomatSettings(string automatName);

        string ReadAllBytesFromFile(string fileName);
    }
}
