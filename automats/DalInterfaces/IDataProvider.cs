using System.Collections.Generic;
using Entities;

namespace DalInterfaces
{
    public interface IDataProvider
    {
        IEnumerable<string> GetData(string pathToFile);

        void SerializeAutomatChain(string data);

        IEnumerable<string> DeserializeAutomatChain();

        bool SaveAutomatWorkData(ChainElementSettings automatData);
    }
}
