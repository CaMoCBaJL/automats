using System.Collections.Generic;
using Entities;
using System.Drawing;

namespace BLInterfaces
{
    public interface IDataProviderLogic
    {
        List<string> GetData(string path);

        bool AddAutomatData(string automatTablesFileName, string inputSignalsString, string outputSignalsString, string automatName);

        Automat ParseAutomatDataTables(string pathToFile);
    }
}
