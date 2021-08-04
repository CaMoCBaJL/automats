using System.Collections.Generic;
using Entities;

namespace DalInterfaces
{
    public interface IDataProvider
    {
        (int[,] DeltaTable, string[,] LambdaTable) ParseAutomatData(string pathToFile);

        IEnumerable<string> GetData(string pathToFile);

        void SaveAutomatChainConfiguration(IEnumerable<ChainModellingGroupOfElements> chainConfiguration);

        IEnumerable<ChainModellingGroupOfElements> LoadAutomatChainConfiguration();

        bool SaveAutomatWorkData(ChainElementSettings automatData);
    }
}
