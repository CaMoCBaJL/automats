using System.Collections.Generic;
using Entities;

namespace DalInterfaces
{
    public interface IDataProvider
    {
        (int[,] DeltaTable, string[,] LambdaTable) ParseAutomatData(string pathToFile);

        IEnumerable<string> GetData(string pathToFile);

        bool SaveAutomatWorkData(ChainElementSettings automatData);

        ChainElementSettings LoadAutomatSettings(string automatName);

        byte[] ReadAllBytes(string fileName);
    }
}
